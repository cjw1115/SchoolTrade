using Foundation;
using System;
using TradeClient.Services;
using UIKit;

namespace TradeClient
{
    public partial class TradeTabController : UITabBarController
    {
        public TradeTabController (IntPtr handle) : base (handle)
        {
        }
        public override void LoadView()
        {
            base.LoadView();

            var re = StatusService.GetIsLogin();
            if (re == false)
            {
                NavigationViewController.NavigationView.PushViewController(NavigationViewController.Loactor.LoginView, true);
            }
        }
    }
}