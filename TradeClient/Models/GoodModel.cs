using System;
using System.Collections.Generic;
using System.Text;

namespace TradeClient.Models
{
    public class OrderFormModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        //发布物品的用户ID
        public int UserId { get; set; }
        //物品类型
        public int GoodsTypeId { get; set; }
        //物品名称
        public string Name { get; set; } // PassWord
        //价格
        public double Price { get; set; }
        //交易地点
        public string Address { get; set; } //交易地点
        //浏览人数
        public int ViewCount { get; set; }
        //喜欢有意向人数
        public int LikeCount { get; set; }
        //联系电话
        public string Tel { get; set; } // Tel
        //发布时间
        public DateTime AddTime { get; set; }
        //订单交易状态进行中，已被购买，成交成功
        public string OrderStatus { get; set; }
        //物品新旧程度
        public int Degree { get; set; }

        public string GoodsTypeName { get; set; }
    }
}
