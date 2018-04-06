using Foundation;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TradeClient.Models;
using UIKit;
using System.Linq;
using TradeClient.Controls;

namespace TradeClient
{
    public partial class SignupViewController : UIViewController
    {
        public static SignupViewController SignupView { get; set; }
        public SignupViewController(IntPtr handle) : base(handle)
        {
            SignupView = this;
        }
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            //this.AutomaticallyAdjustsScrollViewInsets = false;
            //this.scrollViewer.ContentSize = new CoreGraphics.CGSize(this.scrollViewer.Frame.Width, this.scrollViewer.Frame.Height);
            this.btnSignup.TouchUpInside += BtnSignup_TouchUpInside;
            this.tbGender.EditingDidBegin += TbGender_EditingDidBegin;
            this.tbCollege.EditingDidBegin += TbCollege_EditingDidBegin;

            this.tbTel.EditingDidEndOnExit += EditingDidEnd;
            this.tbUsername.EditingDidEndOnExit += EditingDidEnd;
            this.tbPassword.EditingDidEndOnExit += EditingDidEnd;
            this.tbPasswordRe.EditingDidEndOnExit += EditingDidEnd;
            this.tbTel.EditingDidEndOnExit += EditingDidEnd;
            //this.dataPicker.Hidden = true;
            CollegeSet = await GetColleges();
        }

        private void EditingDidEnd(object sender, EventArgs e)
        {
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);
        }

        private void TbCollege_EditingDidBegin(object sender, EventArgs e)
        {
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);
            tbCollege.EndEditing(true);

            var uiView = new UIView(new CoreGraphics.CGRect(0, this.View.Frame.Height / 4 * 3, this.View.Frame.Width, this.View.Frame.Height / 4));
            uiView.Tag = 10010;

            var uiButton = new UIButton(new CoreGraphics.CGRect(0, 0, uiView.Frame.Width, 40));
            uiButton.SetTitle("确认", UIControlState.Normal);
            uiButton.SetTitleColor(UIColor.FromRGB(00,0x86,0xff), UIControlState.Normal);
            uiButton.TouchUpInside += (o, param) => { View.ViewWithTag(10010).RemoveFromSuperview(); };
            uiButton.BackgroundColor = UIColor.Gray;
            uiView.Add(uiButton);

            var picker = new UIPickerView(new CoreGraphics.CGRect(0, 40, uiView.Frame.Width, uiView.Frame.Height - 40));
            picker.Hidden = false;
            picker.Model = new CollegeModel(this,CollegeSet);
            picker.BackgroundColor = UIColor.White;
            uiView.Add(picker);

            View.Add(uiView);
        }

        private void TbGender_EditingDidBegin(object sender, EventArgs e)
        {
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);
            var uiView = new UIView(new CoreGraphics.CGRect(0, this.View.Frame.Height / 4 * 3, this.View.Frame.Width, this.View.Frame.Height / 4));
            uiView.Tag = 10086;

            var uiButton = new UIButton(new CoreGraphics.CGRect(0, 0, uiView.Frame.Width, 40));
            uiButton.SetTitle("确认", UIControlState.Normal);
            uiButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            uiButton.TouchUpInside += (o, param) => { View.ViewWithTag(10086).RemoveFromSuperview(); };
            uiButton.BackgroundColor = UIColor.Gray;
            uiView.Add(uiButton);

            var picker = new UIPickerView(new CoreGraphics.CGRect(0, 40 , uiView.Frame.Width, uiView.Frame.Height - 40));
            picker.Hidden = false;
            picker.Model = new GenderModel(this);
            picker.BackgroundColor = UIColor.White;
            uiView.Add(picker);

            View.Add(uiView);
        }

        private Indicator indicator;
        private bool _isLoadiang;
        public bool IsLoading
        {
            get => _isLoadiang;
            set
            {
                _isLoadiang = value;
                if(value==true)
                {
                    indicator = new Indicator(View,View.Frame);
                    indicator.Show();
                }
                else
                {
                    indicator?.Hide();
                }
            }
        }
        private async void BtnSignup_TouchUpInside(object sender, EventArgs e)
        {
            IsLoading = true;

            var tel = tbTel.Text.Trim();

            var username = tbUsername.Text.Trim();

            var password = tbPassword.Text.Trim();

            var repassword = tbPasswordRe.Text.Trim();

            if (string.IsNullOrEmpty(tel) ||
                string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(repassword))
            {
                Services.NotityService.Notify("注册信息不完整");
                IsLoading = false;
                return;
            }
            if (password != repassword)
            {
                Services.NotityService.Notify("密码不一致");
                IsLoading = false;
                return;
            }
            try
            {
                Dictionary<string, string> dic = new Dictionary<string, string>(0);
               
                //dic.Add("DepartmentId", College.Key);
                //dic.Add("DepartmentName", College.Value);
                //dic.Add("Sex", ((int)Gender).ToString());
                string url = $"http://www.xiandanke.cn/api/user/register?name={username}&password={password}&tel={tel}";
                var re = await Services.StatusService.GetHttpService().SendRequst(url, HttpMethod.Post, dic);
                
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultModel>(re);
                if ( (bool)result.data == true)
                {
                    Services.NotityService.Notify("注册成功");
                    this.NavigationController.PopViewController(true);
                }
                else
                {
                    Services.NotityService.Notify(result.msg);

                }
            }
            catch ( Exception ex)
            {
                Services.NotityService.Notify("注册失败:"+ex.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }
        public Dictionary<string, string> CollegeSet { get; set; }
        public async Task<Dictionary<string, string>> GetColleges()
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            try
            {
                string url = $"http://www.xiandanke.cn/api/scholldepartment";
                var httpService = Services.StatusService.GetHttpService();
                var re = await httpService.SendRequst(url, HttpMethod.Get);
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ResultModel>(re);
                var str = result.data.ToString();
                str=str.Replace("{", "").Replace("}", "").Replace("\"", "").Replace(" ", "").Replace("\n","");
                var colleages = str.Split(',');
                foreach (var item in colleages)
                {
                    var pair = item.Split(':');
                    list[pair[0]] = pair[1];
                }
                return list;
            }
            catch
            {
                return list;
            }
            
        }

        private Gender _gender;
        public Gender Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                this.tbGender.Text = value == Gender.Female ? "男" : "女";
            }
        }

        private KeyValuePair<string, string> _college;
        public KeyValuePair<string,string> College
        {
            get => _college;
            set
            {
                _college = value;
                this.tbCollege.Text = value.Value;
            } }



        public void Register()
        {

        }
    }

    public class GenderModel : UIPickerViewModel
    {
        string[] genders = { "男", "女" };
        SignupViewController signupViewController;
        public GenderModel(SignupViewController controller)
        {
            signupViewController = controller;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return genders.Length;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return genders[row];
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            if (genders[row] == "男")
            {
                signupViewController.Gender = Gender.Female;
            }
            else
                signupViewController.Gender = Gender.Male;
        }

        public override nfloat GetComponentWidth(UIPickerView picker, nint component)
        {
            return 240f;
        }

        public override nfloat GetRowHeight(UIPickerView picker, nint component)
        {
            return 40f;
        }
    }

    public class CollegeModel : UIPickerViewModel
    {
        List<KeyValuePair<string, string>> colleges;
        SignupViewController signupViewController;
        public CollegeModel(SignupViewController controller,Dictionary<string,string> dic)
        {
            signupViewController = controller;
            if(dic!=null&&dic.Count>0)
            {
                colleges = new List<KeyValuePair<string, string>>(dic.Count);
                foreach (var item in dic)
                {
                    colleges.Add(item);
                }
            }
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            if (colleges != null)
            {
                return colleges.Count;
            }
            return 0;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return colleges[(int)row].Value;
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            signupViewController.College = colleges[(int)row];
        }

        public override nfloat GetComponentWidth(UIPickerView picker, nint component)
        {
            return 240f;
        }

        public override nfloat GetRowHeight(UIPickerView picker, nint component)
        {
            return 40f;
        }
    }
}