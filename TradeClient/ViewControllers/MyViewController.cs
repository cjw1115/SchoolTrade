using Foundation;
using System;
using TradeClient.Services;
using UIKit;

namespace TradeClient
{
    public partial class MyViewController : UIViewController
    {
        public MyViewController (IntPtr handle) : base (handle)
        {
           
        }
        public override void LoadView()
        {
            base.LoadView();


            if (StatusService.CurrentUser == null)
            {
                NavigationViewController.NavigationView.PushViewController(NavigationViewController.Loactor.LoginView, true);
            }
        }
    }
}