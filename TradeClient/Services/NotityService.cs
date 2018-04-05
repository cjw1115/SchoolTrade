using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeClient.Models;

namespace TradeClient.Services
{
    public class NotityService
    {
        private static IToastNotificator _toastNotificator;
        public static void Notify(string message)
        {
            if (_toastNotificator == null)
            {
                _toastNotificator = new ToastNotificator();
            }
            _toastNotificator?.Notify(message) ;
        }
    }
}
