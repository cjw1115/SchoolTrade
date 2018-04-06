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
    [Register ("EditUserViewController")]
    partial class EditUserViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSignup { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationBar tbNavigationBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbPasswordRe { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbTel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnSignup != null) {
                btnSignup.Dispose ();
                btnSignup = null;
            }

            if (tbName != null) {
                tbName.Dispose ();
                tbName = null;
            }

            if (tbNavigationBar != null) {
                tbNavigationBar.Dispose ();
                tbNavigationBar = null;
            }

            if (tbPassword != null) {
                tbPassword.Dispose ();
                tbPassword = null;
            }

            if (tbPasswordRe != null) {
                tbPasswordRe.Dispose ();
                tbPasswordRe = null;
            }

            if (tbTel != null) {
                tbTel.Dispose ();
                tbTel = null;
            }
        }
    }
}