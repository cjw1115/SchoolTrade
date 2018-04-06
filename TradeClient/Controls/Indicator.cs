using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TradeClient.Controls
{
    public class Indicator : UIView
    {
        UIView parentView;
        UIActivityIndicatorView activitySpinner;
        public Indicator(UIView parent, CGRect frame) :base(frame)
        {
            parentView = parent;
            activitySpinner =new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge);
            activitySpinner.Color = UIColor.FromRGB(00, 0x86, 0xff);
            this.Add(activitySpinner);
        }
        public void Show()
        {
            var x = (this.Frame.Width - this.activitySpinner.Frame.Width) / 2;
            var y = (this.Frame.Height - this.activitySpinner.Frame.Height) / 2;
            var width = activitySpinner.Frame.Width;
            var height = activitySpinner.Frame.Height;
            activitySpinner.Frame = new CGRect(x, y, width, height);

            this.BackgroundColor = UIColor.FromRGBA(20, 20, 20, 20);
            activitySpinner.Hidden = false;
            parentView.Add(this);
            
        }
        public void Hide()
        {
            activitySpinner.Hidden = true;
            this.RemoveFromSuperview();
        }
    }
}


