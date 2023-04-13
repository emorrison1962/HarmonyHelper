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
            //hrefs.ToList().ForEach(x => Debug.WriteLine(x));

            foreach (var href in hrefs)
            {
                var x = this.GetGlyphs(href).Result;
            }
            
            this.GeneratedCode
                .ToList()
                .ForEach(x => Debug.WriteLine(x));

            new object();
        }

        HashSet<string> Schemas = new HashSet<string>();
        HashSet<string> GeneratedCode = new HashSet<string>();

        async private Task<bool> GetGlyphs(string url)
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
                        var identifier = string.Empty;
                        var codePoint = string.Empty;
                        var comment = string.Empty;

                        this.Schemas.Add(string.Join(", ", td.ChildNodes.Select(x => x.Name)));

                        if (1 == td.ChildNodes.Count(x => x.Name == "#text"))
                        {

                            var txt01 = td.ChildNodes.First(x => x.Name == "#text");
                            identifier = txt01.InnerText;

                            if (td.Descendants("strong").Any())
                            {
                                var nstrong = td.Descendants("strong").First();
                                codePoint = nstrong.InnerText;
                                codePoint = codePoint.Replace("U+", "0x");
                            }
                        }
                        else if (2 == td.ChildNodes.Count(x => x.Name == "#text"))
                        {
                            var txt01 = td.ChildNodes.First(x => x.Name == "#text");
                            var txt02 = td.ChildNodes.Last(x => x.Name == "#text");
                            if (txt01 != txt02)
                            {
                                comment = "//" + txt01.InnerText;
                                identifier = txt02.InnerText;
                            }
                            else
                            {
                                identifier = txt01.InnerText;
                            }

                            if (td.Descendants("strong").Any())
                            {
                                var nstrong = td.Descendants("strong").First();
                                codePoint = nstrong.InnerText;
                                codePoint = codePoint.Replace("U+", "0x");
                            }
                        }
                        else
                        {
                            continue;
                        }


                        if (!string.IsNullOrEmpty(identifier)
                            && !string.IsNullOrEmpty(codePoint))
                        {
                            identifier = this.CoerceIdentifier(identifier);
                            if (!this.IsFiltered(identifier, codePoint))
                            {
                                var code = $"public Rune {identifier} = new Rune({codePoint}); {comment}";
                                this.GeneratedCode.Add(code);
                                //this.GeneratedCode.Add($"_Catalog.Add({identifier});" );
                            }
                            new object();
                        }
                    }
                }
            }
            var result = await Task.FromResult(true);
            return result;
        }

        string CoerceIdentifier(string input)
        {
            if (input.Contains("Double whole note (breve)"))
            {
                //Debug.WriteLine(identifier);
                new object();
            }

            var identifier = input;

            identifier = identifier.Replace(" ", "_");
            identifier = identifier.Replace(".", "");
            identifier = identifier.Replace("[", "");
            identifier = identifier.Replace("]", "");
            
            identifier = identifier.Replace("(", "");
            identifier = identifier.Replace(")", "");
            identifier = identifier.Replace(",", "_");
            identifier = identifier.Replace("/", "_");
            identifier = identifier.Replace("-", "_");
            identifier = identifier.Replace(";", "_");
            identifier = identifier.Replace("+", "_plus_");

            identifier = identifier.Replace("¼", "_one_fourth");
            identifier = identifier.Replace("½", "_one_half");
            identifier = identifier.Replace("¾", "_three_fourths");
            identifier = identifier.Replace("⅓", "_one_third");
            identifier = identifier.Replace("⅔", "two_thirds");
            
            identifier = identifier.Replace("1", "One");
            identifier = identifier.Replace("2", "Two");
            identifier = identifier.Replace("3", "Three");
            identifier = identifier.Replace("4", "Four");
            identifier = identifier.Replace("5", "Five");
            identifier = identifier.Replace("6", "Six");
            identifier = identifier.Replace("7", "Seven");
            identifier = identifier.Replace("8", "Eight");
            identifier = identifier.Replace("9", "Nine");

            if (identifier.Contains("Double_whole_note_breve"))
            {
                //Debug.WriteLine($"{input}:");
                //Debug.WriteLine($"\t{identifier}");
                new object();
            }
            
            return identifier;
        }

        Rune Brace = new Rune(0xE000);

        async Task<HashSet<string>> GetHrefs(string url)
        {
            var result = new HashSet<string>();

            result.Add("https://w3c.github.io/smufl/latest/tables/staff-brackets-and-dividers.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/staves.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/barlines.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/repeats.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/clefs.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/time-signatures.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/noteheads.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/slash-noteheads.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/round-and-square-noteheads.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/note-clusters.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/note-name-noteheads.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/shape-note-noteheads.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/individual-notes.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/beamed-groups-of-notes.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/stems.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/flags.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/standard-accidentals-12-edo.html");
            //result.Add("https://w3c.github.io/smufl/latest/tables/other-accidentals.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/articulation.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/holds-and-pauses.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/rests.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/bar-repeats.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/octaves.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/dynamics.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/lyrics.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/common-ornaments.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/guitar.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/chord-diagrams.html");
            //result.Add("https://w3c.github.io/smufl/latest/tables/analytics.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/chord-symbols.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/tuplets.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/beams-and-slurs.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/figured-bass.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/function-theory-symbols.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/combining-staff-positions.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/simplified-music-notation.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/time-signatures-supplement.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/octaves-supplement.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/metronome-marks.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/figured-bass-supplement.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/shape-note-noteheads-supplement.html");
            //result.Add("https://w3c.github.io/smufl/latest/tables/turned-time-signatures.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/fingering.html");
            //result.Add("https://w3c.github.io/smufl/latest/tables/stockhausen-accidentals-24-edo.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/standard-accidentals-for-chord-symbols.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/clefs-supplement.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/fingering-supplement.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/other-accidentals-supplement.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/techniques-noteheads.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/noteheads-supplement.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/note-name-noteheads-supplement.html");
            result.Add("https://w3c.github.io/smufl/latest/tables/scale-degrees.html");
            //result.Add("https://w3c.github.io/smufl/latest/print.html");
            result.Add("https://w3c.github.io/smufl/latest/specification/font-metadata-locations.html");


            return result;


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
                            var target = $"https://w3c.github.io/smufl/latest{href.Replace("..", "")}";
                            result.Add(target);
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

        bool IsFiltered(string identifier, string codePoint)
        {
            var result = false;
            if (codePoint.Contains('.'))
            {
                result = true;
            }
            var lowered = identifier.ToLower();
            if (lowered.Contains("arrow")
                || lowered.Contains("cowell")
                || lowered.Contains("swiss_")
                || lowered.Contains("alois_hába")
                || lowered.Contains("fingering_")
                || lowered.Contains("_walker_")
                || lowered.Contains("_aikin_")
                || lowered.Contains("_history_sign")
                || lowered.Contains("function_theory_")
                || lowered.Contains("figured_bass_")
                || lowered.Contains("_seven_")
                || lowered.Contains("triangle_notehead_")
                || lowered.Contains("square_notehead")
                || lowered.Contains("_x")
                || lowered.Contains("x_")
                    ) 
            {
                result = true;
            }

            return result;  
        }

    }//class
}//ns
