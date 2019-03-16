using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectGenConsole
{
    class ConfigFileHelper
    {
        public static JObject ParseConfigFile(string path)
        {
            path = @"..\..\WebElementConfig.json";
            string jsonstr = "";
            JObject configJson = null;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        jsonstr = jsonstr+ sr.ReadLine();
                    }
                }
                configJson = JObject.Parse(jsonstr);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return configJson;
        }


        public static List<ElementAtttribute> DeserializingJson(string path)
        {
            JObject json = ParseConfigFile(path);
            IList<JToken> configuration = json["WebElement"].Children().ToList();
            List<ElementAtttribute> ConfigList = new List<ElementAtttribute>();
            foreach (JToken c in configuration)
            {
                ElementAtttribute wec = c.ToObject<ElementAtttribute>();
                ConfigList.Add(wec);
            }

            return ConfigList;

        }

    }
}
