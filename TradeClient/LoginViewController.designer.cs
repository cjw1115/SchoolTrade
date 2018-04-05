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
    [Register ("LoginViewController")]
    partial class LoginViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLogin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbUsername { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnLogin != null) {
                btnLogin.Dispose ();
                btnLogin = null;
            }

            if (tbPassword != null) {
                tbPassword.Dispose ();
                tbPassword = null;
            }

            if (tbUsername != null) {
                tbUsername.Dispose ();
                tbUsername = null;
            }
        }
    }
}