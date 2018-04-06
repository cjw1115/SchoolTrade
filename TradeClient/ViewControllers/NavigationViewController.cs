using Foundation;
using System;
using UIKit;

namespace TradeClient
{
    public partial class NavigationViewController : UINavigationController
    {
        public static NavigationViewController NavigationView { get; private set; }
        public static ViewControllerLocator Loactor { get; } = new ViewControllerLocator();
        public NavigationViewController (IntPtr handle) : base (handle)
        {
            NavigationView = this;

        }
    }
}