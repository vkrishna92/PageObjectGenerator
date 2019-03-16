using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PageObjectGenConsole
{
    class XpathConvertor
    {
        public static string GetXpath(string htmltag, string attribute,string attValue)
        {
            string xpathStr = "//" + htmltag;
            List<string> xpathElements = new List<string>();
            //check if the value has special charecter 
            var regExItem = new Regex("^[a-zA-Z0-9_]*$");
            if(regExItem.IsMatch(attValue))
            {
                //split the string at special expression 
                var attArr = splitAttributeValue(attValue);
                
                string attComb = "";
                foreach(var k in attArr)
                {
                    string temp = "contains(@" + attribute + ",'" + k + "')";
                    xpathElements.Add(temp);
                }
            }

            if (xpathElements.Count > 0)
                xpathStr = xpathStr + "[";

            for(int i =0;i<xpathElements.Count;i++)
            {
                if(i==xpathElements.Count-1)
                {
                    xpathStr +=xpathElements[i]+ "]";
                }
                else
                {
                    xpathStr += xpathElements[i] + " and ";
                }

                
            }
            //Console.WriteLine(xpathStr);
            return xpathStr;

        }

        public static List<string> splitAttributeValue(string attributeValue)
        {
            string[] attArr = attributeValue.Split('_');
            List<string> splitValues = new List<string>();
            foreach(var k in attArr)
            {
                int num;
                bool isNum = int.TryParse(k, out num);
                if(!isNum)
                {
                    splitValues.Add(k);
                }
            }

            return splitValues;
        }
    }
}
