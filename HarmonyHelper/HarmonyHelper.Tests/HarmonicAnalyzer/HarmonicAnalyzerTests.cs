using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class HarmonicAnalyzerTests
	{
		[TestMethod()]
		public void HarmonicAnalyzer_Test()
		{
		}

		[TestMethod()]
		public void Analyze_Test()
		{
			var str = "Dm7 g7 cmaj7";
			var chords = this.GetChords(str);
			var analysisResults = HarmonicAnalyzer.Analyze(chords);
			foreach (var analysisResult in analysisResults)
			{
				if (analysisResult.Success)
					Debug.WriteLine(analysisResult.Message);
			}
			Assert.IsNotNull(analysisResults);
			Assert.Fail();
		}

		[TestMethod()]
		public void SecondaryDominantRule_Test()
		{
			var str = "Dm7 g7 cmaj7 A7 Dm7 g7 cmaj7 A7";
			var chords = this.GetChords(str);
			var analysisResults = HarmonicAnalyzer.Analyze(chords);
			foreach (var analysisResult in analysisResults)
			{
				if (null != analysisResult && analysisResult.Success)
					Debug.WriteLine(analysisResult.Message);
			}
			Assert.IsNotNull(analysisResults);
			Assert.Fail();
		}


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

		List<Song> LoadSongs()
		{
			var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
			path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(path))));
			path = Path.Combine(path, "songs.json");

			var json = File.OpenText(path).ReadToEnd();

			var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Song>>(json);
			return result;
		}

		[TestMethod()]
		public void BorrowedChordHarmonicAnalysisRule_Test02()
		{
			var songs = this.LoadSongs();
			foreach (var song in songs)
			{
				var str = string.Join(" ", song.Chords);
				var keyStr = song.Key;
				var title = song.Title;

				if (keyStr.Length == 1)
				{
					var key = KeySignature.MajorKeys.Where(x => x.NoteName.Name == keyStr).First();
					var chords = this.GetChords(str, key);
					var analysisResults = HarmonicAnalyzer.Analyze(chords);
					foreach (var analysisResult in analysisResults)
					{
						if (null != analysisResult && analysisResult.Success)
							Debug.WriteLine(analysisResult.Message);
					}
					Assert.IsNotNull(analysisResults);
				}

			}
		}



		[TestMethod()]
		public void BorrowedChordHarmonicAnalysisRule_Test()
		{
			var str = "Dm7 g7 cmaj7 AbMaj7";
			var chords = this.GetChords(str);
			var analysisResults = HarmonicAnalyzer.Analyze(chords);
			foreach (var analysisResult in analysisResults)
			{
				if (null != analysisResult && analysisResult.Success)
					Debug.WriteLine(analysisResult.Message);
			}
			Assert.IsNotNull(analysisResults);
		}

		List<ChordFormula> GetChords(string chords, KeySignature key = null)
		{
			if (!ChordParser.TryParse(chords, out List<ChordFormula> result, out string message, key))
				Assert.Fail("Couldn't parse chords.");
			return result;
		}



	}//class
}//ns