using Foundation;
using System;
using UIKit;

namespace TradeClient
{
    public partial class LoginViewController : UIViewController
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
        }

        

        private void BtnLogin_TouchUpInside(object sender, EventArgs e)
        {
            Login();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public void Login()
        {
            Username = this.tbUsername.Text.Trim();
            Password = this.tbPassword.Text.Trim();

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Services.NotityService.Notify("登陆信息不完整");
            }
        }

        private void BtnSignup_TouchUpInside(object sender, EventArgs e)
        {
            NavigationViewController.NavigationView.PushViewController(NavigationViewController.Loactor.SignupView, true);
        }
    }
}