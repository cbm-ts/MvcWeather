using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWeather.Common
{
    public static class ConfigurationSettings
    {
        public static string ConnectionString { get; set; }

        public static void LoadSettings()
        {
            ConnectionString = GetConnectionStringValue("SqlConn");
        }

        private static string GetAppSettingValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        private static string GetConnectionStringValue(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
    }
}
