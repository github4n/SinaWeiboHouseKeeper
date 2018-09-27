using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinaWeiboHouseKeeper.IOTools
{
    public static class AppConfigRWTool
    {
        /// <summary>
        /// 向app.congfig写入设置
        /// </summary>
        /// <param name="key">需要设置的key</param>
        /// <param name="value">设置的值</param>
        public static void WriteConfig(string key, string value)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            file.ExeConfigFilename = System.Windows.Forms.Application.ExecutablePath + ".config";
            Configuration config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
            var myApp = (AppSettingsSection)config.GetSection("appSettings");
            myApp.Settings[key].Value = value;
            config.Save();
        }
    }
}
