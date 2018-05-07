using Konves.ChordPro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
			path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(path)));
			var filename = "Beatles (The) - A Hard Day's Night.gp3";
			path = Path.Combine(path, filename);
			this.Open(path);
			new object();
		}

		void Open(string path)
		{
			using (Stream stream = new FileStream(path, FileMode.Open))
			{
				var doc = ChordProSerializer.Deserialize(stream);
				foreach (var line in doc.Lines)
				{
					new object();


				}
				new object();
			}
		}
	}//class
}//ns
