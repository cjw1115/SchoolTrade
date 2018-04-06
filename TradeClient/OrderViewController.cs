using Foundation;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TradeClient.Controls;
using TradeClient.Models;
using UIKit;

namespace TradeClient
{
    public partial class OrderViewController : UIViewController
    {
        public OrderViewController (IntPtr handle) : base (handle)
        {
            this.TabBarItem = new UITabBarItem(UITabBarSystemItem.Favorites, 1);
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


        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var orders=await GetOrderHistory();
            listOrder.Source = new OrderSource(orders);
            listOrder.ReloadData();
        }
        public async Task<OrderFormModel[]> GetOrderHistory()
        {
            IsLoading = true;
            try
            {
                
                //dic.Add("DepartmentId", College.Key);
                //dic.Add("DepartmentName", College.Value);
                //dic.Add("Sex", ((int)Gender).ToString());
                string url = $"http://www.xiandanke.cn/api/myorderform?userid={Services.StatusService.CurrentUser.Id}";
                var re = await Services.StatusService.GetHttpService().SendRequst(url, HttpMethod.Get);

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultModel>(re);
                var orders=Newtonsoft.Json.JsonConvert.DeserializeObject<Models.OrderFormModel[]>(result.data.ToString());

                return orders;
            }
            catch (Exception ex)
            {
                Services.NotityService.Notify("获取订单失败:" + ex.Message);
                return new OrderFormModel[0];
            }
            finally
            {
                IsLoading = false;
            }
        }
    }


    public class OrderSource : UITableViewSource
    {

        Models.OrderFormModel[] TableItems;
        string CellIdentifier = "TableCell";

        public OrderSource(Models.OrderFormModel[] items)
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
            //cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

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