using CoreGraphics;
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
        public bool IsLowest { get; set; } = true;
        public GoodsViewController (IntPtr handle) : base (handle)
        {
        }
        UIButton btnLatest;
        UIButton btnPrice;
        public void InitButton()
        {

            btnLatest = new UIButton(new CGRect(0, 0, viewHeader.Frame.Width / 2, viewHeader.Frame.Height));
            btnLatest.SetTitle("最新发布", UIControlState.Normal);
            btnLatest.SetTitleColor(UIColor.White, UIControlState.Normal);
            btnLatest.BackgroundColor = UIColor.FromRGB(00, 0x86, 0xff);
            btnLatest.TouchUpInside += BtnLatest_TouchUpInside;

            viewHeader.Add(btnLatest);

            btnPrice = new UIButton(new CGRect(viewHeader.Frame.Width / 2, 0, viewHeader.Frame.Width / 2, viewHeader.Frame.Height));
            btnPrice.SetTitle("价格最低", UIControlState.Normal);
            btnPrice.SetTitleColor(UIColor.White, UIControlState.Normal);
            btnPrice.BackgroundColor = UIColor.FromRGB(00, 0x86, 0xff);
            btnPrice.TouchUpInside += BtnPrice_TouchUpInside;

            viewHeader.Add(btnPrice);

        }

        private void BtnPrice_TouchUpInside(object sender, EventArgs e)
        {
            IsLowest = true;
            Refresh();
        }

        private void BtnLatest_TouchUpInside(object sender, EventArgs e)
        {
            IsLowest = false;
            Refresh();
        }

        public async void Refresh()
        {
            var re = await GetGoodsList();
            listGoods.Source = new TableSource(re);
            listGoods.ReloadData();
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            InitButton();
            Refresh();
        }
        public async Task<Models.OrderFormModel[]> GetGoodsList()
        {
            try
            {
                string url = $"http://www.xiandanke.cn/api/orderform/get?order={(IsLowest ? 1 : 0).ToString()}";
                var httpService = Services.StatusService.GetHttpService();
                var re = await httpService.SendRequst(url, HttpMethod.Get);
                var result=Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ResultModel>(re);
                var goods= Newtonsoft.Json.JsonConvert.DeserializeObject<Models.OrderFormModel[]>(result.data.ToString());
                return goods;
            }
            catch
            {
                return new Models.OrderFormModel[0];
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
            NavigationViewController.Loactor.DetailView.OrderDetail = TableItems[indexPath.Row];
            NavigationViewController.NavigationView.PushViewController(NavigationViewController.Loactor.DetailView, true);
            //NavigationController.PushViewController(LoginViewController.LoginView, true);
        }
    }
}