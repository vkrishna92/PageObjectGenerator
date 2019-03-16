using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectGenConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            HtmlScrapper html = new HtmlScrapper();
            html.LoadHtml("");
            html.crawlHtml();
            Console.ReadLine();
        }
    }
}
