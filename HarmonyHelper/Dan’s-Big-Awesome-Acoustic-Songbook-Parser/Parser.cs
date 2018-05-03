using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dan_s_Big_Awesome_Acoustic_Songbook_Parser
{
	public class Parser
	{
		HtmlDocument HtmlDocument { get; set; } = new HtmlDocument();
		virtual public bool TryParse(string html, out List<string> chords)
		{
			chords = new List<string>();
			bool success = false;

			this.HtmlDocument.LoadHtml(html);

			//this.HtmlDocument.Save(string.Format(@"c:\temp\{0}.html", new UriBuilder(url).Host));

			//Debug.WriteLine(this.HtmlDocument.DocumentNode.InnerHtml);

			success = this.GetTitle();


			if (success)
			{
				success = false;
				success = this.GetChords();
			}

			//if (success)
			//{
			//	success = false;
			//	this.GetIngredients();
			//	if (0 < this.IngredientGroups.Count)
			//	{
			//		success = true;
			//	}
			//}

			//if (success)
			//{
			//	success = false;
			//	this.GetProcedures();
			//	if (0 < this.ProcedureGroups.Count)
			//	{
			//		success = true;
			//	}
			//}


			//result = new Recipe()
			//{
			//	Name = this.Title,
			//	IngredientGroups = this.IngredientGroups,
			//	ProcedureGroups = this.ProcedureGroups,
			//	Uri = url,
			//	ImageUri = this.ImageUrl,
			//	Source = new UriBuilder().Host
			//};

			return success;
		}

		string Title { get; set; }
		List<string> Chords { get; set; } = new List<string>();


		const string CLASS_SONG_TITLE = "sg_title";
		virtual protected bool GetTitle()
		{
			bool result = false;
			var titleNode = this.HtmlDocument.DocumentNode.Descendants().ByClass(CLASS_SONG_TITLE).First();
			if (null != titleNode)
			{
				this.Title = WebUtility.HtmlDecode(titleNode.InnerText.FromHtml());
				this.Title = this.Title.Trim();
				result = true;
			}
			return result;
		}

		const string CLASS_CHORD = "ch";
		bool GetChords()
		{
			bool result = false;
			var chordNodes = this.HtmlDocument.DocumentNode.GetNodes("tr", CLASS_CHORD);
			foreach (var chordNode in chordNodes)
			{
				var chords = this.GetChords(chordNode);
				this.Chords.AddRange(chords);
			}
			Debug.WriteLine(string.Join(", ", this.Chords));
			new object();

			//if (null != chordNodes)
			//{
			//	this.Title = WebUtility.HtmlDecode(chordNodes.InnerText.FromHtml());
			//	this.Title = this.Title.Trim();
			//	result = true;
			//}
			return result;
		}

		List<string> GetChords(HtmlNode parent)
		{
			var result = new List<string>();
			//Debug.WriteLine(parent.InnerHtml);
			var tds = parent.GetNodes("td");
			foreach (var td in tds)
			{
				var txt = td.InnerText.FromHtml().Trim();
				if (string.Empty != txt)
					result.Add(txt);
			}
			return result;
		}

		virtual protected HtmlNode GetNode(string nodeType, string className)
		{
			var nodes = this.HtmlDocument.DocumentNode.Descendants(nodeType);
			var result = nodes.ByClass(className).FirstOrDefault();

			return result;
		}


	}//class

	public static class HtmlNodeExtensions
	{
		static public IEnumerable<HtmlNode> ByClass(this IEnumerable<HtmlNode> nodes, string classname)
		{
			var seq = nodes.Where(x => x.HasAttributes);
			var result = seq.Where(x =>
				x.Attributes.Where(a => "class" == a.Name && a.Value.Contains(classname)).FirstOrDefault() != null);

#if false
			foreach (var div in seq)
			{
				foreach (var att in div.Attributes)
				{
					if (att.Name == "class")
					{
						//Debug.WriteLine(att.Value);
						if (att.Value.IndexOf("ingredient") > 0)
						{
							new object();
						}
					}
				}
			}

#endif
			return result;
		}
		static public IEnumerable<HtmlNode> ByID(this IEnumerable<HtmlNode> nodes, string id)
		{
			var seq = nodes.Where(x => x.HasAttributes);
			var result = seq.Where(x =>
				x.Attributes.Where(a => "id" == a.Name && a.Value.Contains(id)).FirstOrDefault() != null);

#if false
			foreach (var div in seq)
			{
				foreach (var att in div.Attributes)
				{
					if (att.Name == "id")
					{
						Debug.WriteLine(att.Value);
						if (att.Value.IndexOf("ingredient") > 0)
						{
							new object();
						}
					}
				}
			}

#endif
			return result;
		}

		static public string FromHtml(this string innerText)
		{
			var result = HttpUtility.HtmlDecode(innerText);
			result = result.Trim();
			return result;
		}

		static public HtmlNode GetNode(this HtmlNode parent, string nodeType, string className = null)
		{
			var result = parent.GetNodes(nodeType, className).FirstOrDefault();
			return result;
		}

		static public List<HtmlNode> GetNodes(this HtmlNode parent, string nodeType, string className = null)
		{
			var result = parent.Descendants(nodeType).ToList();
			if (null != className)
			{
				result = result.ByClass(className).ToList();
			}

			return result;
		}

		#region HtmlDocument Extensions

		static public HtmlNode GetNode(this HtmlDocument doc, string nodeType, string className = null)
		{
			var result = doc.GetNodes(nodeType, className).FirstOrDefault();
			return result;
		}

		static public List<HtmlNode> GetNodes(this HtmlDocument doc, string nodeType, string className = null)
		{
			var result = doc.DocumentNode.Descendants(nodeType).ToList();
			if (null != className)
			{
				result = result.ByClass(className).ToList();
			}
			return result;
		}

		#endregion

	}//class

}//ns
