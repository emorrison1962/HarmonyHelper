using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;
using Eric.Morrison.Harmony.Intervals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;

namespace KeySignature_Tests
{
	[TestClass()]
	public class KeySignatureTests
	{
		[TestMethod()]
		public void KeySignature_TransposeUp_Test()
		{
			var intervals = Interval.Catalog.Where(x => x > Interval.Unison);
			foreach (var key in KeySignature.InternalCatalog)
			{
				//Debug.WriteLine($"Key = {key.NoteName.Name}");
				//Debug.Indent();
				foreach (var interval in intervals)
				{
					try
					{
						var expected = KeySignature.GetTransposed(key, (Interval)interval);
						//Debug.WriteLine($"transposed by {interval.ToString()} = {expected.NoteName.Name}");
						new object();

					}
					catch (ArgumentOutOfRangeException)
					{
                        Debug.WriteLine($"Couldn't tranpose {key} by {interval}");
                    }
                }
				//Debug.Unindent();

			}
			new object();
		}

		[TestMethod()]
		public void KeySignature_TransposeDown_Test()
		{
			//public static KeySignature GetTransposed(KeySignature key, Interval interval)
			NoteName root = null;
			KeySignature key = null;
			const int CYCLE_MAX = 11;

			for (int i = 0; i <= CYCLE_MAX; ++i)
			{
				if (null == root)
				{
					root = NoteName.C;
					key = KeySignature.CMajor;
				}
				else
				{
					key -= Interval.Perfect5th;
					root += ChordToneInterval.Perfect5th;
				}

				Debug.WriteLine($"key={key.ToString()} : {root.Name}");

				new object();

			}

			new object();
		}

		[TestMethod()]
		public void TryDetermineKey_Test()
		{
			{
				var sChords = $"cmaj7 dm em7 fMaj7 g7 a- bm7b5";
				if (!ChordFormulaParser.TryParse(sChords, out var key, out var chords, out var msg))
				{
					Assert.Fail(msg);
				}
				else
				{
					key = KeySignature.DetermineKey(chords);
					Assert.AreEqual(KeySignature.CMajor, key);
				}
			}
			{
				var sChords = $"cmaj7 bm7b5 e7 am7 d7 gm7 c7 f7 fm7 bb7 ebm7 ab7 dm7 g7 cmaj7 a7 dm7 g7";
				if (!ChordFormulaParser.TryParse(sChords, out var key, out var chords, out var msg))
				{
					Assert.Fail(msg);
				}
				else
				{
					key = KeySignature.DetermineKey(chords);
					Assert.IsNotNull(key);
                }
			}
		}

        [TestMethod()]
        public void TryDetermineKey_Test2()
        {
            {// A harmonic minor. UGH.
                var txt = "amMaj7 bm7b5 cmaj7#5 dm7 e7 fmaj7 g#dim7";
                var chords = ChordFormulaParser.Parse(txt);

                var key = KeySignature.DetermineKey(chords);
				Assert.IsTrue(KeySignature.CMajor == key); //F* it. cmaj7#5 is the first major chord.
                new object();
            }
            {
                var txt = "cmaj7 dm7 em7 fmaj7 g7 am7 bm7b5";
                var chords = ChordFormulaParser.Parse(txt);

                var key = KeySignature.DetermineKey(chords);
                
				Assert.IsTrue(KeySignature.CMajor == key);
                new object();
            }
        }

    }//class
}//ns