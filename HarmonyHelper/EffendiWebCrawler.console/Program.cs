using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffendiWebCrawler.console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Crawler().Crawl().Wait();
        }
    }
}
