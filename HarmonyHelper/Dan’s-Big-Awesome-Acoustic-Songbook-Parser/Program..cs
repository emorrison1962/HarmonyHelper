using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison;

namespace Dan_s_Big_Awesome_Acoustic_Songbook_Parser
{
	public partial class Program
	{
		static void Main(string[] args)
		{
			new Program().MainImpl(args);
		}

		void MainImpl(string[] args)
		{
            var html = Helpers.LoadEmbeddedResource("260427");

            new Parser().TryParse(html, out List<Song> songs);

			var chords = songs.SelectMany(x => x.Chords.Distinct()).Distinct();

			var chordsStr = string.Join(", ", chords);
			var codeStr = $"var chordsStr = @\"{chordsStr}\";";
			Debug.WriteLine(codeStr);
		}
	}
}
