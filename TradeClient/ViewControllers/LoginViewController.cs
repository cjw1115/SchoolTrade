using Foundation;
using System;
using System.Net.Http;
using TradeClient.Controls;
using TradeClient.Models;
using UIKit;

namespace TradeClient
{
    public partial class LoginViewController : UIViewController,IUITextFieldDelegate
    {
        public static LoginViewController LoginView { get; set; }
        public LoginViewController (IntPtr handle) : base (handle)
        {
            LoginView = this;
        }
        public override void LoadView()
        {
            base.LoadView();
            this.btnLogin.TouchUpInside += BtnLogin_TouchUpInside;
            this.btnSignup.TouchUpInside += BtnSignup_TouchUpInside;


            //this.tbUsername.Delegate = this;
            this.tbUsername.EditingDidEndOnExit += TbUsername_EditingDidEnd;

            //this.tbPassword.Delegate = this;
            //this.tbPassword.ShouldReturn = textFieldShouldReturn;

            this.tbPassword.EditingDidEndOnExit += TbPassword_EditingDidEnd;
        }

        private void TbPassword_EditingDidEnd(object sender, EventArgs e)
        {
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);
        }

        private void TbUsername_EditingDidEnd(object sender, EventArgs e)
        {
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);
        }

        public bool textFieldShouldReturn(UITextField textField)
        {
            return textField.ResignFirstResponder();
        }

        private void BtnLogin_TouchUpInside(object sender, EventArgs e)
        {
            Login();
        }

        private Indicator indicator;
        private bool _isLoadiang;
        public bool IsLoading
        {
            get => _isLoadiang;
            set
            {
                _isLoadiang = value;
                if (value == true)
                {
                    indicator = new Indicator(View, View.Frame);
                    indicator.Show();
                }
                else
                {
                    indicator?.Hide();
                }
            }
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public async void Login()
        {
            IsLoading = true;

            Username = this.tbUsername.Text.Trim();
            Password = this.tbPassword.Text.Trim();

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Services.NotityService.Notify("登录信息不完整");
                IsLoading = false;
                return;
            }

            try
            {
                string url = $"http://www.xiandanke.cn/api/user/login?name={Username}&password={Password}";
                var re = await Services.StatusService.GetHttpService().SendRequst(url, HttpMethod.Get);

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultModel>(re);
                if (result.code==0)//登陆成功
                {
                    Services.NotityService.Notify("登录成功");
                    var user=Newtonsoft.Json.JsonConvert.DeserializeObject<Models.UserInfoModel>(result.data.ToString());
                    Services.StatusService.CurrentUser = user;
                    this.NavigationController.PopViewController(true);
                }
                else
                {
                    Services.NotityService.Notify("登录失败：" + result.msg);

                }
            }
            catch (Exception ex)
            {
                Services.NotityService.Notify("登录失败:" + ex.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void BtnSignup_TouchUpInside(object sender, EventArgs e)
        {
            NavigationViewController.NavigationView.PushViewController(NavigationViewController.Loactor.SignupView, true);
        }
    }
}