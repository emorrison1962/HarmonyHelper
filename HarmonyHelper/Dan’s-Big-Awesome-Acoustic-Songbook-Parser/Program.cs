using System;
using System.Collections.Generic;
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
			new Parser().TryParse(html, out List<string> chords);
		}

		string LoadEmbeddedResourceHtml()
		{
			var result = string.Empty;
			var assembly = Assembly.GetExecutingAssembly();
			using (var sr = new StreamReader(assembly.GetManifestResourceStream("Dan_s_Big_Awesome_Acoustic_Songbook_Parser.SingleSongTemplate.html")))
			{
				result = sr.ReadToEnd();
			}
			return result;
		}
	}
}
