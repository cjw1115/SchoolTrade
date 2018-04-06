using Foundation;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UIKit;

namespace TradeClient
{
    public partial class GoodsViewController : UIViewController
    {
        public bool IsHighToLow { get; set; } = false;
        public GoodsViewController (IntPtr handle) : base (handle)
        {
            
        }
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            var re = await GetGoodsList();
            listGoods.Source = new TableSource(re);

        }

        public async Task<Models.OrderFormModel[]> GetGoodsList()
        {
            try
            {
                string url = $"http://www.xiandanke.cn/api/orderform/get?order={(IsHighToLow ? 1 : 0).ToString()}";
                var httpService = Services.StatusService.GetHttpService();
                var re = await httpService.SendRequst(url, HttpMethod.Get);
                var result=Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ResultModel>(re);
                var goods= Newtonsoft.Json.JsonConvert.DeserializeObject<Models.OrderFormModel[]>(result.data.ToString());
                return goods;
            }
            catch
            {
                return null;
            }
        }
    }
    public class TableSource : UITableViewSource
    {

        Models.OrderFormModel[] TableItems;
        string CellIdentifier = "TableCell";

        public TableSource(Models.OrderFormModel[] items)
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
            Models.OrderFormModel item = TableItems[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Value1, CellIdentifier);
            }
            cell.TextLabel.Text = item.Name;
            cell.DetailTextLabel.Text = item.Price.ToString();
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