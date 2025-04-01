﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SK {
    /// <summary>App.config配置类
    /// </summary>
    public class AppConfigHelper {

        #region appSetting节点

        /// <summary>修改AppSettings中配置
        /// </summary>
        /// <param name="key">key值</param>
        /// <param name="value">相应值</param>
        public static bool SetConfigValue(string key, string value) {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings[key] != null)
                    config.AppSettings.Settings[key].Value = value;
                else
                    config.AppSettings.Settings.Add(key, value);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>获取AppSettings中某一节点值
        /// </summary>
        /// <param name="key"></param>
        public static string GetConfigValue(string key) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] != null)
                return config.AppSettings.Settings[key].Value;
            else
                return string.Empty;
        }
        #endregion

        #region ConnectionStrings节点
        /// <summary>
        /// 获取连接节点值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionValue(string key) {
            if (ConfigurationManager.ConnectionStrings[key] != null)
                return ConfigurationManager.ConnectionStrings[key].ConnectionString;
            return string.Empty;
        }

        /// <summary>修改或新增ConnectionStrings节点
        /// </summary>
        /// <param name="key"></param>
        /// <param name="conString"></param>
        public static void UpdateConnectionStringsConfig(string key, string conString) {
            bool isModified = false;    //记录该连接串是否已经存在 
            if (ConfigurationManager.ConnectionStrings[key] != null)
            {
                isModified = true;
            }
            //新建一个连接字符串实例 
            ConnectionStringSettings mySettings = new ConnectionStringSettings(key, conString);

            // 打开可执行的配置文件*.exe.config 
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // 如果连接串已存在，首先删除它 
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(key);
            }
            // 将新的连接串添加到配置文件中. 
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // 保存对配置文件所作的更改 
            config.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节  
            ConfigurationManager.RefreshSection("connectionStrings");
        }


        #endregion
    }
}
