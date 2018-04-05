using System;
using System.Collections.Generic;
using System.Text;

namespace TradeClient.Models
{
    public class ResultModel
    {
        public object data { get; set;}
        public int code { get; set; }
        public string msg { get; set; }
    }
}
