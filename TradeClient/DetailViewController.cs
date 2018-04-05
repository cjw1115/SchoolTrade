using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;
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

            listDetail.Source = new DetailTableSource(GetDetailList());
            
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
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

            return cell;
        }
    }
}