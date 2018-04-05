using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeClient.Models
{
    public interface IToastNotificator
    {
        void Notify(string message);
    }
}
