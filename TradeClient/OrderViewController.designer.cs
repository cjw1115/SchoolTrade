﻿// WARNING
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
    [Register ("OrderViewController")]
    partial class OrderViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView listOrder { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (listOrder != null) {
                listOrder.Dispose ();
                listOrder = null;
            }
        }
    }
}