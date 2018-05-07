using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using HtmlAgilityPack;

namespace Dan_s_Big_Awesome_Acoustic_Songbook_Parser
{
	public class Song
	{
		public string Title { get; private set; }
		public string Key { get; private set; }
		public List<string> Chords { get; private set; } = new List<string>();
		public Song(string title, string key, List<string> chords)
		{
			this.Title = title;
			this.Key = key;
			this.Chords = chords;
		}
	}

	public class Parser
	{
		const string CLASS_SONG_TITLE = "sg_title";
		const string CLASS_CHORD = "ch";
		const string CLASS_SONG = "sg_song";

		HtmlDocument HtmlDocument { get; set; } = new HtmlDocument();
		public bool TryParse(string html, out List<Song> songs)
		{
			songs = new List<Song>();
			this.HtmlDocument.LoadHtml(html);

			bool result = false;

			var songNodes = this.HtmlDocument.DocumentNode.GetNodes("div", CLASS_SONG);
			foreach (var songNode in songNodes)
			{
				this.GetTitle(songNode, out string title);
				this.GetKey(songNode, out string key);
				var chordNodes = songNode.GetNodes("tr", CLASS_CHORD);
				List<string> chords = new List<string>();
				foreach (var chordNode in chordNodes)
				{
					chords.AddRange(this.GetChords(chordNode));
				}

				var song = new Song(title, key, chords);
				songs.Add(song);
			}

			var json = Newtonsoft.Json.JsonConvert.SerializeObject(songs);
			var path = Assembly.GetExecutingAssembly().Location;

			path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(path))));
			path = Path.Combine(path, "songs.json");
			using (var fs = File.CreateText(path))
			{
				fs.Write(json);
			}



			return result;
		}

		private bool GetKey(HtmlNode songNode, out string key)
		{
			key = string.Empty;
			key = songNode.GetAttributeValue("data-key", string.Empty);
			var result = false;
			if (string.Empty != key)
				result = true;
			return result;

		}

		bool GetTitle(HtmlNode parentNode, out string title)
		{
			title = null;
			bool result = false;
			var titleNode = parentNode.ChildNodes.ByClass(CLASS_SONG_TITLE).First();
			if (null != titleNode)
			{
				title = WebUtility.HtmlDecode(titleNode.InnerText.FromHtml());
				title = title.Trim();
				result = true;
			}
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
