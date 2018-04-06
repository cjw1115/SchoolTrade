using Foundation;
using System;
using System.Collections.Generic;
using TradeClient.Controls;
using UIKit;

namespace TradeClient
{
    public partial class BalanceViewController : UIViewController
    {
        public static BalanceViewController BalanceView { get; set; }
        public BalanceViewController (IntPtr handle) : base (handle)
        {
            BalanceView = this;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.btnCharge.TouchUpInside += BtnCharge_TouchUpInside;
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
        private async void BtnCharge_TouchUpInside(object sender, EventArgs e)
        {
            IsLoading = true;

            var money = tbBalance.Text.Trim();

            if (string.IsNullOrEmpty(money))
            {
                Services.NotityService.Notify("请输入充值金额");
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
                if ((bool)result.data == true)
                {
                    Services.NotityService.Notify("注册成功");
                    this.NavigationController.PopViewController(true);
                    NavigationController.PopViewController(true);
                }
                else
                {
                    Services.NotityService.Notify(result.msg);

                }
            }
            catch (Exception ex)
            {
                Services.NotityService.Notify("注册失败:" + ex.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}