using Foundation;
using System;
using System.Collections.Generic;
using TradeClient.Services;
using UIKit;

namespace TradeClient
{
    public partial class MyViewController : UIViewController
    {
        public MyViewController (IntPtr handle) : base (handle)
        {

        }
        public List<KeyValuePair<string, string>> GetMyInfo()
        {
            List<KeyValuePair<string, string>> dic = new List<KeyValuePair<string, string>>();
            if (Services.StatusService.CurrentUser!=null)
            {
                dic.Add(new KeyValuePair<string,string>("用户名", Services.StatusService.CurrentUser.Name));
                dic.Add(new KeyValuePair<string, string>("手机号", Services.StatusService.CurrentUser.Tel));
                dic.Add(new KeyValuePair<string, string>("学院", Services.StatusService.CurrentUser.DepartmentName));
                dic.Add(new KeyValuePair<string, string>("性别", Services.StatusService.CurrentUser.Sex?"女":"男"));

                dic.Add(new KeyValuePair<string, string>("余额", ""));

                dic.Add(new KeyValuePair<string, string>("编辑信息", ""));

            }
            return dic;
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            var info = GetMyInfo();
        }
        
    }
    public class UserinfoSource : UITableViewSource
    {

        List<KeyValuePair<string,string>> info;
        string CellIdentifier = "TableCell";

        public UserinfoSource(List<KeyValuePair<string, string>> valuePairs)
        {
            info = valuePairs;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return info.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            var  item = info[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Value1, CellIdentifier);
            }
            cell.TextLabel.Text = item.Key;
            cell.DetailTextLabel.Text = item.Value;
            if(indexPath.Row>=4)
            {
                cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
            }
            

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            switch (indexPath.Row)
            {
                case 4://余额充值
                    NavigationViewController.NavigationView.PushViewController(NavigationViewController.Loactor.BalanceView, true);
                    break;
                case 5://信息编辑
                    break;
                default:
                    break;
            }
            
            //NavigationController.PushViewController(LoginViewController.LoginView, true);
        }
    }
}