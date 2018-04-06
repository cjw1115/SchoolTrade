// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TradeClient
{
    [Register ("BalanceViewController")]
    partial class BalanceViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCharge { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbBalance { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnCharge != null) {
                btnCharge.Dispose ();
                btnCharge = null;
            }

            if (tbBalance != null) {
                tbBalance.Dispose ();
                tbBalance = null;
            }
        }
    }
}