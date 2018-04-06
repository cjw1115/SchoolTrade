using Foundation;
using System;
using UIKit;

namespace TradeClient
{
    public partial class OrderViewController : UIViewController
    {
        public OrderViewController (IntPtr handle) : base (handle)
        {
            this.TabBarItem = new UITabBarItem(UITabBarSystemItem.Favorites, 1);
        }
    }
}