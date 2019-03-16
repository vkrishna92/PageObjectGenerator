using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectGenConsole
{
    class HtmlScrapper
    {
        public static HtmlDocument htmldoc;

        public void LoadHtml(string path)
        {
            path = @"..\..\htmlSample.txt";
            var htmlstring = readeHtmlTxt(path);
            htmldoc = new HtmlDocument();
            htmldoc.LoadHtml(htmlstring);
        }

        public string readeHtmlTxt(string path)
        {
            string htmlDoc = "";
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    htmlDoc += sr.ReadLine();
                }

            }

            return htmlDoc;
        }


        public void crawlHtml()
        {
            var config = ConfigFileHelper.DeserializingJson("");
            List<string> xpaths = new List<string>();
            Dictionary<string,string> vairables = new Dictionary<string, string>();
            foreach (var k in config)
            {
                var htmlBody = htmldoc.DocumentNode.SelectNodes("//" + k.HtmlElement);
                
                //Console.WriteLine(htmlBody.Count);
                foreach (var element in htmlBody)
                {
                    if (element.Attributes[k.Attribute[0]] != null)
                    {
                        var attValue = element.Attributes[k.Attribute[0]].Value;
                     //   Console.WriteLine(element.Attributes[k.Attribute[0]].Value);
                        xpaths.Add(XpathConvertor.GetXpath(k.HtmlElement, k.Attribute[0], attValue));
                    }
                    else if (element.Attributes[k.Attribute[1]] != null)
                    {
                        var attValue = element.Attributes[k.Attribute[1]].Value;
                       // Console.WriteLine(element.Attributes[k.Attribute[1]].Value);
                        xpaths.Add(XpathConvertor.GetXpath(k.HtmlElement, k.Attribute[1], attValue));
                    }

                    //Console.WriteLine(element.InnerHtml);
                                    
                }
                
            }

            foreach (var x in xpaths)
            {
                Console.WriteLine(x);
            }

            //Check if xpaths List is not empty and add variable names
            if(xpaths.Count>0)
            {
                foreach(var x in xpaths)
                {

                }
            }

        }
    }
}
