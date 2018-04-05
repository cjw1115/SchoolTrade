using System;
using System.Collections.Generic;
using System.Text;

namespace TradeClient.Models
{
    public class UserInfoModel
    {

        public string Tel { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public bool Sex { get; set; }
        public string PassWord { get; set; } // PassWord
        public string DepartmentName { get; set; }

        public string Remark { get; set; }

        public DateTime Birthday { get; set; }
    }
}
