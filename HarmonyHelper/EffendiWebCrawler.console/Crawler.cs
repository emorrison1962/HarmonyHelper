using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SMuFLScraper.console
{
    internal class Crawler
    {
        const string ROOT_URL = @"https://effendi.me/jazz/repo/";
        const string DST_DIR = @"c:\temp\Effendi MusicXml Files";

        public async Task Crawl()
        {
            if (!Directory.Exists(DST_DIR))
            { 
                Directory.CreateDirectory(DST_DIR); 
            }
            var cli = new HttpClient();
            cli.BaseAddress = new Uri(ROOT_URL);

            var hrefs = await this.GetHrefs(ROOT_URL);
            foreach (var href in hrefs)
            {
                var xmls = await this.GetHrefs(href.Value);
                foreach (var xml in xmls)
                { 
                    await this.DownloadXml(xml, href);
                }
                new object();
            }

            new object();
        }

        async Task<Dictionary<string, string>> GetHrefs(string url)
        {
            var result = new Dictionary<string, string>();

            var response = await new HttpClient().GetStringAsync(url);
            var doc = new HtmlDocument();
            doc.LoadHtml(response);
            doc.OptionOutputAsXml = true;

            foreach (var anchor in doc.DocumentNode.Descendants("a").ToList())
            {
                var attrs = anchor.Attributes.ToList();
                foreach (var attr in attrs)
                {
                    var href = attr.Value;
                    if (!href.StartsWith("?")
                        && !href.StartsWith("/")
                        && href != "README")
                    {
                        Debug.WriteLine(href);
                        result.Add(anchor.InnerText.Replace("/", "\\"), url + href);
                    }
                }
            }

            return result;
        }

        async Task DownloadXml(KeyValuePair<string, string> kvp,
            KeyValuePair<string, string> subfolder)
        {
            var response = await new HttpClient().GetStringAsync(kvp.Value);


            if (!Directory.Exists(Path.Combine(DST_DIR, subfolder.Key)))
            {
                Directory.CreateDirectory(Path.Combine(DST_DIR, subfolder.Key));
            }

            var filename = Path.Combine(DST_DIR, subfolder.Key, kvp.Key);

            File.WriteAllText(filename, response);

            new object();
        }
    }//class
}//ns
