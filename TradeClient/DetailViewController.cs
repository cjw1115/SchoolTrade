using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TradeClient.Controls;

namespace TradeClient
{
    public partial class DetailViewController : UIViewController
    {
        public static DetailViewController DetailView { get; set; }
        public Models.OrderFormModel OrderDetail { get; set; }

        public int ID { get; set; }

        public DetailViewController (IntPtr handle) : base (handle)
        {
            DetailView = this;

        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.btnGet.TouchUpInside += BtnGet_TouchUpInside;
        }
        private Indicator indicator;
        private bool _isLoadiang;
        public bool IsLoading
        {
            get => _isLoadiang;
            set
            {
                _isLoadiang = value;
                if (value == true)
                {
                    indicator = new Indicator(View, View.Frame);
                    indicator.Show();
                }
                else
                {
                    indicator?.Hide();
                }
            }
        }
        private async void BtnGet_TouchUpInside(object sender, EventArgs e)
        {
            IsLoading = true;

            if (Services.StatusService.CurrentUser == null)
            {
                IsLoading = false;
                NavigationViewController.NavigationView.PushViewController(NavigationViewController.Loactor.LoginView, true);
                return;
            }
            try
            {
                
                Dictionary<string, string> dic = new Dictionary<string, string>();
                //dic.Add("orderformId", OrderDetail.Id.ToString());
                //dic.Add("id", Services.StatusService.CurrentUser.Id.ToString());

                string url = $"http://www.xiandanke.cn/api/myorderform?id={Services.StatusService.CurrentUser.Id.ToString()}&orderformId={OrderDetail.Id.ToString()}";

                var httpService = Services.StatusService.GetHttpService();
                var re = await httpService.SendRequst(url, HttpMethod.Put,dic);
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ResultModel>(re);
                
                if((bool)result.data==true)
                {
                    Services.NotityService.Notify("购买成功");
                }
                else
                {
                    Services.NotityService.Notify(result.msg);
                }
            }
            catch(Exception ex)
            {
                Services.NotityService.Notify($"购买出错:{ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            //OrderDetail = await GetGoodsDetail();
            listDetail.Source = new DetailTableSource(GetDetailList());
            listDetail.ReloadData();
        }
        public async Task<Models.OrderFormModel> GetGoodsDetail()
        {
            try
            {   
                string url = $"http://xiandanke.cn/api/orderform/detail?id={ID}";
                var httpService = Services.StatusService.GetHttpService();
                var re = await httpService.SendRequst(url, HttpMethod.Get);
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ResultModel>(re);
                var goodDetail = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.OrderFormModel>(result.data.ToString());
                return goodDetail;
            }
            catch
            {
                return null;
            }
        }
        public Dictionary<string,string> GetDetailList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (OrderDetail != null)
            {
                dic.Add("物品名称", OrderDetail.Name);
                dic.Add("价格", OrderDetail.Price.ToString());
                dic.Add("交易地点", OrderDetail.Address);
                dic.Add("新旧程度", OrderDetail.Degree.ToString());
                dic.Add("发布时间", OrderDetail.AddTime.ToString());
                dic.Add("状态", OrderDetail.OrderStatus);

            }
            return dic;
        }
    }
    public class DetailTableSource : UITableViewSource
    {

        Dictionary<string, string>  TableItems;
        string CellIdentifier = "TableCell";

        public DetailTableSource(Dictionary<string,string> items)
        {
            TableItems = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            var item=TableItems.Skip(indexPath.Row).Take(1).First();
            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Value1, CellIdentifier);
            }
            cell.TextLabel.Text = item.Key;
            cell.DetailTextLabel.Text = item.Value;
            //cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

            return cell;
        }
    }
}