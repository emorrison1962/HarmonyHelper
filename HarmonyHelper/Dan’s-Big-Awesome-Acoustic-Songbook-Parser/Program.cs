using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dan_s_Big_Awesome_Acoustic_Songbook_Parser
{
	class Program
	{
		static void Main(string[] args)
		{
			new Program().MainImpl(args);
		}

		void MainImpl(string[] args)
		{
			var html = this.LoadEmbeddedResourceHtml();
			new Parser().TryParse(html, out List<Song> songs);

			var chords = songs.SelectMany(x => x.Chords.Distinct()).Distinct();

			var chordsStr = string.Join(", ", chords);
			var codeStr = $"var chordsStr = @\"{chordsStr}\";";
			Debug.WriteLine(codeStr);
		}

		string LoadEmbeddedResourceHtml()
		{
			var result = string.Empty;
			var assembly = Assembly.GetExecutingAssembly();
			//using (var sr = new StreamReader(assembly.GetManifestResourceStream("Dan_s_Big_Awesome_Acoustic_Songbook_Parser.SingleSongTemplate.html")))
			using (var sr = new StreamReader(assembly.GetManifestResourceStream("Dan_s_Big_Awesome_Acoustic_Songbook_Parser.DansSongbook.html")))
			{
				result = sr.ReadToEnd();
			}
			return result;
		}
	}
}
