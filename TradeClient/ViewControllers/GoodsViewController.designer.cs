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
    [Register ("GoodsViewController")]
    partial class GoodsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView listGoods { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewHeader { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (listGoods != null) {
                listGoods.Dispose ();
                listGoods = null;
            }

            if (viewHeader != null) {
                viewHeader.Dispose ();
                viewHeader = null;
            }
        }
    }
}