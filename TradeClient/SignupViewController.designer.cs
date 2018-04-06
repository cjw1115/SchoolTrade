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
    [Register ("SignupViewController")]
    partial class SignupViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSignup { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ContentView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView scrollViewer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbCollege { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbGender { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbPasswordRe { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbTel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbUsername { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnSignup != null) {
                btnSignup.Dispose ();
                btnSignup = null;
            }

            if (ContentView != null) {
                ContentView.Dispose ();
                ContentView = null;
            }

            if (scrollViewer != null) {
                scrollViewer.Dispose ();
                scrollViewer = null;
            }

            if (tbCollege != null) {
                tbCollege.Dispose ();
                tbCollege = null;
            }

            if (tbGender != null) {
                tbGender.Dispose ();
                tbGender = null;
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

            if (tbUsername != null) {
                tbUsername.Dispose ();
                tbUsername = null;
            }
        }
    }
}