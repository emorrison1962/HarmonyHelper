using Konves.ChordPro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChordProParser
{
	class Program
	{
		static void Main(string[] args)
		{
			new Program().MainImpl(args);
		}
		void MainImpl(string[] args)
		{
			var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
			path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(path))));
			path = Path.Combine(path, "chordpro", "b", "beatles", "ADayInALife.chopro");
			var contents = this.Open(path);
			var result = this.Parse(contents);
			new object();
		}

		string Open(string path)
		{
			var result = File.OpenText(path).ReadToEnd();
			return result;
		}

		string Parse(string input)
		{
			var sb = new StringBuilder();
			const string REGEX = "\\[(.*?)\\]";
			var matches = Regex.Matches(input, REGEX);//.Match(input, REGEX);
			foreach (var ob in matches)
			{
				var match = ob as Match;
				sb.AppendFormat(" {0}", match.Groups[1].ToString());
				new object();
			}
			sb.Replace("?", string.Empty);

			var result = sb.ToString();
			return result;
		}
	}//class
}//ns
