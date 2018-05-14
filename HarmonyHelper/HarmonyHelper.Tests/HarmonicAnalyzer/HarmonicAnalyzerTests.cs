﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.HarmonicAnalysis;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;
using Eric.Morrison.Harmony.Chords;

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
			var analysisResults = HarmonicAnalyzer.Analyze(chords, KeySignature.CMajor);
			Assert.IsNotNull(analysisResults);
			var expected = analysisResults.First(x => x.Rule is DiatonicToKeyRule);
			Assert.IsInstanceOfType(expected.Rule, typeof(DiatonicToKeyRule));
			foreach (var analysisResult in analysisResults)
			{
				if (analysisResult.Success)
					Debug.WriteLine(analysisResult.Message);
			}
		}

		[TestMethod()]
		public void SecondaryDominantRule_Test()
		{
			var str = "Dm7 g7 cmaj7 A7 Dm7 g7 cmaj7 A7";
			var chords = this.GetChords(str);
			var analysisResults = HarmonicAnalyzer.Analyze(chords, KeySignature.CMajor);
			Assert.IsNotNull(analysisResults);
			var expected = analysisResults.First(x => x.Rule is SecondaryDominantRule);
			Assert.IsInstanceOfType(expected.Rule, typeof(SecondaryDominantRule));

			foreach (var analysisResult in analysisResults)
			{
				if (null != analysisResult && analysisResult.Success)
					Debug.WriteLine(analysisResult.Message);
			}
		}
		[TestMethod()]
		public void ADayInTheLife_Test()
		{
			var str = " G Bm Em Em7 C C G Bm Em C Em Am Cmaj7 G Bm Em C F Em E C F Em Cmaj7 G Bm Em C Em Am Cmaj7 G Bm Em C F Em E C G Bm Em C Em Am Cmaj7 G Bm Em C F Em E C Bm G G E E D E F#m7 E F#m7 E D E F#m7 E F#m7 C G D A C G D A G Bm Em C Em Am Cmaj7 G Bm Em C F Em E C Bm G G E";
			var chords = this.GetChords(str);
			var analysisResults = HarmonicAnalyzer.Analyze(chords, KeySignature.CMajor);
			foreach (var analysisResult in analysisResults)
			{
				if (null != analysisResult && analysisResult.Success)
					Debug.WriteLine(analysisResult.Message);
				else
					Debug.WriteLine(analysisResult.Message);
			}
			Assert.IsNotNull(analysisResults);
			Assert.Fail();

		}

		public class Song
		{
			public string Title { get; private set; }
			public string Key { get; private set; }
			public List<string> Chords { get; set; } = new List<string>();
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

		List<string> Cleanse(List<string> chords)
		{
			//var bad = chords.Where(x =>
			//	!x.ToLower().StartsWith("a") &&
			//	!x.ToLower().StartsWith("b") &&
			//	!x.ToLower().StartsWith("c") &&
			//	!x.ToLower().StartsWith("d") &&
			//	!x.ToLower().StartsWith("e") &&
			//	!x.ToLower().StartsWith("f") &&
			//	!x.ToLower().StartsWith("g")).ToList();
			//if (bad.Count < 0)
			//	new object();

			var result = chords.Where(x =>
				x.ToLower() != "nc" &&
				x.ToLower() != "(hard stop)").ToList();
			return result;
		}

		[TestMethod()]
		public void BorrowedChordHarmonicAnalysisRule_Test02()
		{
			var songs = this.LoadSongs();
			foreach (var song in songs)
			{
				//song.Chords.ForEach(x => Debug.WriteLine(x));
				song.Chords = this.Cleanse(song.Chords);

				var str = string.Join(" ", song.Chords);
				var keyStr = song.Key;
				var title = song.Title;

				if (keyStr.Length == 1)
				{
					var key = KeySignature.MajorKeys.Where(x => x.NoteName.Name == keyStr).First();
					var chords = this.GetChords(str, key);
					var analysisResults = HarmonicAnalyzer.Analyze(chords, key);
					Debug.WriteLine($"Analysis: {song.Title} in {song.Key}:");
					Debug.WriteLine(str);
					Debug.Indent();
					foreach (var analysisResult in analysisResults)
					{
						if (null != analysisResult && analysisResult.Success)
							Debug.WriteLine(analysisResult.Message);
					}
					Assert.IsNotNull(analysisResults);
					Debug.Unindent();
					Debug.WriteLine(string.Empty);
				}

			}
		}



		[TestMethod()]
		public void BorrowedChordHarmonicAnalysisRule_Test()
		{
			var str = "Dm7 g7 cmaj7 AbMaj7";
			var chords = this.GetChords(str);
			var analysisResults = HarmonicAnalyzer.Analyze(chords, KeySignature.CMajor);
			foreach (var analysisResult in analysisResults)
			{
				if (null != analysisResult && analysisResult.Success)
					Debug.WriteLine(analysisResult.Message);
			}
			Assert.IsNotNull(analysisResults);
		}

		[TestMethod()]
		public void BorrowedChordHarmonicAnalysisRuleDebug()
		{
			var rule = new BorrowedChordHarmonicAnalysisRule();
			var chords = this.GetChords("am7");
			rule.Analyze(chords, KeySignature.CMajor);
		}

		
		[TestMethod()]
		public void TritoneSubstitutionRuleDebug()
		{
			var rule = new TritoneSubstitutionRule();
			var chords = this.GetChords("dm7 c#7 cmaj7");
			var results = rule.Analyze(chords, KeySignature.CMajor);
			foreach (var result in results)
				Debug.WriteLine(result.Message);
			new object();
		}

		[TestMethod()]
		public void Dim7ForDom7SubstitutionRuleDebug()
		{
			var rule = new Dim7ForDom7SubstitutionRule();
			var chords = this.GetChords("dm7 g#dim7 cmaj7");
			var results = rule.Analyze(chords, KeySignature.CMajor);
			foreach (var result in results)
				Debug.WriteLine(result.Message);
			new object();
		}

		List<ChordFormula> GetChords(string chords, KeySignature key = null)
		{
			if (!ChordFormulaParser.TryParse(chords, out List<ChordFormula> result, out string message, key))
				Assert.Fail("Couldn't parse chords.");
			return result;
		}



	}//class
}//ns