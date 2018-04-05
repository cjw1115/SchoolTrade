using Foundation;
using System;
using System.Net.Http;
using UIKit;

namespace TradeClient
{
    public partial class GoodsViewController : UIViewController
    {
        public bool IsHighToLow { get; set; } = false;
        public GoodsViewController (IntPtr handle) : base (handle)
        {
            
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            string[] tableItems = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
            listGoods.Source = new TableSource(tableItems);

        }

        public void GetGoodsList()
        {
            string url = $"http://www.xiandanke.cn/api/orderform?order={(IsHighToLow ? 1 : 0).ToString()}";
            var httpService=Services.StatusService.GetHttpService();
            var re=httpService.SendRequst(url, HttpMethod.Get);
        }
    }
    public class TableSource : UITableViewSource
    {

        string[] TableItems;
        string CellIdentifier = "TableCell";

        public TableSource(string[] items)
        {
            TableItems = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            string item = TableItems[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Value1, CellIdentifier);
            }
            cell.TextLabel.Text = item;
            cell.DetailTextLabel.Text = "300.0";
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            NavigationViewController.Loactor.DetailView.ID = indexPath.Row;
            NavigationViewController.NavigationView.PushViewController(NavigationViewController.Loactor.DetailView, true);
            //NavigationController.PushViewController(LoginViewController.LoginView, true);
        }
    }
}