using System;
using System.Collections.Generic;
using System.Text;

namespace TradeClient.Services
{
    public class StatusService
    {
        //private static bool _isLogin;
        //public static bool GetIsLogin()
        //{
        //    return _isLogin;
        //}
        //public static void SetIsLogin(bool value)
        //{
        //    _isLogin = value;
        //    Plugin.Settings.CrossSettings.Current.AddOrUpdateValue("Userinfo",)
        //}
        public static Models.UserInfoModel CurrentUser
        {
            get
            {
                try
                {
                    var re = Plugin.Settings.CrossSettings.Current.GetValueOrDefault("UserInfoModel", null);
                    if (re != null)
                    {
                        var user = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.UserInfoModel>(re);
                        return user;
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
                
            }
            set
            {
                try
                {
                    var str = Newtonsoft.Json.JsonConvert.SerializeObject(value);
                    Plugin.Settings.CrossSettings.Current.AddOrUpdateValue("UserInfoModel", str);
                }
                catch
                {
                    throw;
                }
                
            }
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
