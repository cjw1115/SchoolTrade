using System;
using System.Collections.Generic;
using System.Text;

namespace TradeClient.Services
{
    public class StatusService
    {
        private static bool _isLogin;
        public static bool GetIsLogin()
        {
            return _isLogin;
        }
        public static void SetIsLogin(bool value)
        {
            _isLogin = value;
            
        }

        private static Services.HttpBaseService _httpService;
        public static Services.HttpBaseService GetHttpService()
        {
            if(_httpService==null)
            {
                _httpService = new HttpBaseService();
            }
            return _httpService;
        }
    }
}
