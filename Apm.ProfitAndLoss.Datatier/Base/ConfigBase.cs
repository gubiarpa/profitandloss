using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Apm.ProfitAndLoss.Datatier.Base
{
    public static class ConfigBase
    {
        public static string GetValueInAppSettings(string key, string defaultValue = null)
        {
            try
            {
                return ConfigurationManager.AppSettings[key].ToString();
            }
            catch (Exception ex)
            {
                if (defaultValue == null)
                {
                    throw ex;
                }
                else
                {
                    return defaultValue;
                }
            }
        }

        public static string GetValueInConnectionString(string key, string defaultValue = null)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[key].ToString();
            }
            catch (Exception ex)
            {
                if (defaultValue == null)
                {
                    throw ex;
                }
                else
                {
                    return defaultValue;
                }
            }
        }

        public static void SetValueinAppSettings(string key, string value)
        {
            try
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
