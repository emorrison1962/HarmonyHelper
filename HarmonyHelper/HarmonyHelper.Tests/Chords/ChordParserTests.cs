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
		public void Bug_Parse_Bbm7_Test()
		{

			var s = "bbm7";
			var success = ChordParser.TryParse(s, KeySignature.CMajor, out List<Chord> result, out string message);
			Assert.IsTrue(success);
			Assert.IsTrue(ChordType.Minor7th == result.First().Formula.ChordType);
			Assert.IsTrue(NoteName.Bb == result.First().Root.NoteName);

			new object();
		}


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

		[TestMethod()]
		public void GuitarPro_TryParse_Test()
		{
			#region chordsStr
			var chordsStr = @"Am, Em, D, G, C, C/B, Am/D, D/F#, Bm, F, A, Aaug, E/A, E, A/C#, G/D, A/D, E/G#, F#m, C#m/E, E7, G/A, Em7, C7, Fm6/Ab, C/G, F#m7b5, C/E, G7, D7, G/B, Dm7, C/F, D#5, F5, A#5, C5, G#, D#, C#, Bm7, Cmaj7, AmM6, B7, B/F#, G#m7, Bsus4, F#m7, C#m, C#m7, Dmaj7, Esus4, Am7, Asus4, Gadd9, Am/G, Cm, A#, Gdim7, G#m, B, A7, Gmaj7, D/A, A7/E, C#7, F#m/E, D/C#, D/B, A/G#, A/F#, A/E, Em6/G, Fmaj7, Amaj7, E7sus, Dmin, Dm, E5, E5/C, E5/B, A5, G5, C#5, C#dim, Bb, Eb, B/D#, Gm, Cadd9, Em/G, G6, E6, G6/B, Bb(#11), C6/9, Gm7, Edim, C9, F9, F#, F#7, Bm/A, E7sus4, Bdim7, F/A, F/G, F/C, Fadd9/A, Fadd9, G/F, G7/D, Dm/F, G7/F, Bb/F, Gm7/F, C/Bb, Bb/C, Bb/D, Bbmaj7, Ebmaj7, Abmaj7, C/D, D/G, G9, G7/B, A9, F/E, Ab, D/Eb, Em/D, A7sus4, D9, A7/Bb, G/F#, E7/G#, B7sus4, D7sus, Dsus4, Amaj7/E, G#7, D6, E/F#, B/A, GmM7, Bbaug, A6, F7, Cm/G#, G#dim7, G+, G9+/F, F#dim7, Am7b5/D#, B9, D#9, Em7/A, D5, Am, Gm/Bb, Fm/Ab, D9/F#, C+, D/C, C7/G, Cm7, Bb6, Dbdim, Dbm, Gb7, B6, B/Eb, Ddim, C6, Ebdim, Db6, Ebm, Ab7, Db/F, D/Gb, Fdim, Eb6, Fm, Bb7, Eb/G, Gbdim, Fm7, Db7, Eb7#9, Faug, Bbm, D#m, Am7/G, F#dim, G#/C, A#m, A#m7/G#, D#m7, Dsus2, Eaug, Dm/A, Bm7b5/A, Ebdim7, Db, A#sus4, Gsus4, F/D, G/E, Asus2, Gsus2, C/A, AMm9, AMm6, Cadd5, D11add5, Bbadd5, D11, C1, B5, B(b5), NC, Fmaj, Edim/Bb, Fdim7/D, D7#9, Em9/G, E7#9, Gbm, Amsus4, Dsus4/F#, Esus4/G#, E9, A/B, Badd4, E/B, Esus2/G#, F#9, B7sus, Esus/G#, E7/B, Cdim7, Gaug, Baug, Ddim7, B7/D#, Asus4/E, F#7b9, B/E, C#m7/B, C#m/A#, Gb, D11/A, A#dim, Bm7b5, Em7b5, Fdim7, E/D, B7#9, Gm/F, F#5, G#5, Esus2, Em/B, Esus, C#/G#, B/A#, E+, F#7sus4, C#m7b5/G, Dm/G, E7+5, Am/E, Fma7, D/#F, Dsus2/A, D7/C, D#/G, A#7/D, Emaj7, Fmaj7b5, Aadd9, Emaj9, Eadd9, Amaj9, C#m11, Em11, A2, Aadd11, Add9, Amin9, Aadd9alt, Fmaj7b5/G, Fsus4, Gm9/F, G9sus4, Bbm6/Db, Cmaj9, Cm9, Gm6/C, Dadd9, A7/G, D/E, Em/C, D#dim7, Edim7, E/G, C#7sus4, C#7/F, Bm/Ab, Cmaj7/G#, Ab6, C7/Bb, Bm7b5/F, B/C#, D#m7b5, Cm6, A#maj7, Fm7b5, Gm11, Bm11, Fsus2, G#sus2, A#7, B/G#, Am7/D, Em/A#, Asus2/G, Asus2/F#, Asus2/E, E/F, B11/A, Daug, Bm/D, Bmaj7, B(#9), C/A#, Gm13/A#, Gbdim7, B+7, Fmaj7/A, Em7sus4, Am11, Caug/G#, F/B, Em9, Cdim/Eb, G6/A, Dmadd9, Cm/D#, F#m/C#, Gm/A#, F#dim7/G, EmMaj7, A7#9, A7#9/G, D7/F#, Am7sus4, Bm/F#, D9, Bdim, Csus2, Cadd, EMb5, A#/F, Dmaj9, Dmaj7/F#, C#m7/E, Ab/C, C#7/B, A#m7b5, F#m11/7, Eb7/D, Ebmaj7/G, Em7/B, Am9, Em7/D, G#augadd7add9, C#m/C, D7/A, D7/E, Fm/G#, Csus4, Dm7/G, G13, D+, EmM7, D7/G, BmM7, Bm/G#, Am6, Emadd9, Dm6, Esus2/D, D#/D, C#m7b5, Bmadd11, Bb/A, Bb/G, Bbm7, Eb7, F6, A/G, Dadd9/F#, Am/C, Dm/E, E7b9, AmM7, A7b9, D#+, Dm/C, CmM7, Fmadd9, Adim, D7b9, Bm6, Gm/D, C#m/B, A+, D#7, G#6, F#6, D7sus4, C#m/G#, Dmaug, A#/C, F#7m, Bm/G, Dm7/C, D, Cmaj7/E, G#dim, A(b9), A7sus9, EmM6, Am/F#";
			#endregion

			var strings = chordsStr.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

			bool success = false;
			foreach (var chordStr in strings)
			{
				success = ChordParser.TryParse(chordStr, out List<Chord> result, out string message);
				if (success)
				{
					Debug.WriteLine($"{chordStr} : {result[0]}");
				}
				else
				{
					//Debug.WriteLine(message);
				}
				//Assert.IsTrue(success);
			}

			new object();

		}
	}//class
}//ns