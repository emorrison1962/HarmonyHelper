using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class ChordParserTests
	{
		[TestMethod()]
		public void TryParse_Test()
		{
			#region chords
			var chords = @"

Maj

min
-

dim

Aug
+
+7

Maj7

min7
-7
m7

m7b5
-7b5

dim7
minMaj7
Aug7

Maj6

m9
Maj9
9

7b9
7#9

11
7+11

13
7b13
";
			#endregion

			var cleansed = chords.Split(new string[] { " ", "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

			var strings = new List<string>();
			cleansed.ForEach(x => strings.Add("Bb" + x));


			bool success = false;
			foreach (var s in strings)
			{
				success = ChordParser.TryParse(s, out List<Chord> result, out string message);
				if (success)
					Debug.WriteLine($"{result[0]}");
				else
					Debug.WriteLine(message);
				//Assert.IsTrue(success);
			}

			new object();
			//success = ChordParser.TryParse(chords, out List<Chord> result2, out string message2);
			//Assert.IsTrue(success);


		}
	}
}