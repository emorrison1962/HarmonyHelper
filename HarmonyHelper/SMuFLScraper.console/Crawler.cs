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
        const string ROOT_URL = @"https://w3c.github.io/smufl/latest/tables/index.html";
        private bool _capture;

        public async Task Crawl()
        {
            var cli = new HttpClient();
            cli.BaseAddress = new Uri(ROOT_URL);

            var hrefs = await this.GetHrefs(ROOT_URL);

            foreach (var href in hrefs)
            {
                this.GetGlyphs(href);
            }

            new object();
        }

        async private void GetGlyphs(string url)
        {
            var response = await new HttpClient().GetStringAsync(url);
            var doc = new HtmlDocument();
            doc.LoadHtml(response);
            doc.OptionOutputAsXml = true;

            foreach (var table in doc.DocumentNode.Descendants("table").ToList())
            {
                foreach (var tr in table.Descendants("tr").ToList())
                {
                    foreach (var td in tr.Descendants("td").ToList())
                    {
#if false
<td>
<strong>U+E000</strong>&nbsp;(and U+1D114)
<br><em>brace</em><br>
Brace</td>
#endif

                        if (td.Descendants("strong").Any())
                        {
                            var nstrong = td.Descendants("strong").First();
                            Debug.WriteLine(nstrong.InnerText);
                        }
                        new object();
                    }
                }
            }
        }

        async Task<HashSet<string>> GetHrefs(string url)
        {
            var result = new HashSet<string>();

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
                        && href.StartsWith(".."))
                    {
                        if (_capture)
                        {
                            Debug.WriteLine(anchor.InnerText);
                            Debug.WriteLine(href);

                            var target = $"https://w3c.github.io/smufl/latest{href.Replace("..", "")}";
                            result.Add(target);

                            //https://w3c.github.io/smufl/latest/tables/staff-brackets-and-dividers.html
                            //https://w3c.github.io/smufl/latest
                        }
                        if (!_capture && anchor.InnerText == "4. Glyph tables")
                        {
                            _capture = true;
                        }
                    }
                }
            }

            return result;
        }

    }//class
}//ns
