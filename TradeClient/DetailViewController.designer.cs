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
    [Register ("DetailViewController")]
    partial class DetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnGet { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView listDetail { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnGet != null) {
                btnGet.Dispose ();
                btnGet = null;
            }

            if (listDetail != null) {
                listDetail.Dispose ();
                listDetail = null;
            }
        }
    }
}