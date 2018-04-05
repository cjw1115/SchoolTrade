using Foundation;
using System;
using UIKit;

namespace TradeClient
{
    public partial class SignupViewController : UIViewController
    {
        public static SignupViewController SignupView{get;set;}
        public SignupViewController (IntPtr handle) : base (handle)
        {
            SignupView = this;

            
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.btnSignup.TouchUpInside += BtnSignup_TouchUpInside;
        }
        private void BtnSignup_TouchUpInside(object sender, EventArgs e)
        {
            var tel = tbTel.Text.Trim();

            var username = tbName.Text.Trim();

            var password = tbPassword.Text.Trim();

            var repassword = tbPasswordRe.Text.Trim();

            if(string.IsNullOrEmpty(tel)||
                string.IsNullOrEmpty(username)||
                string.IsNullOrEmpty(password)||
                string.IsNullOrEmpty(repassword))
            {
                Services.NotityService.Notify("注册信息不完整");
                return;
            }
            if(password!=repassword)
            {
                Services.NotityService.Notify("密码不一致");
                return;
            }


        }
    }
}