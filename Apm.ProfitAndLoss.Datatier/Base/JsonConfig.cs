﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Apm.ProfitAndLoss.Datatier.Base
{
    public static class JsonConfig
    {
        private static JObject configuration;

        private static Dictionary<string, string> cache;

        public static void LoadFile(string path = null)
        {
            if (path == null)
            {
                path = AppDomain.CurrentDomain.BaseDirectory + "\appConfig.json";
            }

            cache = new Dictionary<string, string>();
            configuration = JObject.Parse(File.ReadAllText(path));
        }

        public static string GetSetting(string settingName)
        {
            string actualSettingValue = null;
            JObject actualJsonNode = configuration;
            if (!cache.TryGetValue(settingName, out actualSettingValue))
            {
                try
                {
                    foreach (string setting in settingName.Split('.'))
                    {
                        actualSettingValue = actualJsonNode[setting].ToString();
                        actualJsonNode = actualJsonNode[setting] as JObject;
                    }
                    cache.Add(settingName, actualSettingValue);
                }
                catch
                {
                }
            }
            return actualSettingValue;
        }

        public static void SetSetting(string settingName, string value)
        {
            try
            {
                JArray contentobject = (JArray)JsonConvert.DeserializeObject(configuration.ToString());
                JObject voicgObj = contentobject.Children().FirstOrDefault(ce => ce["code"].ToString() == "GENDER") as JObject;
                JProperty voicgProp = voicgObj.Property("value");
            }
            catch
            {
            }
        }
    }
}
