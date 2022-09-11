using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class KeySignatureTests
	{
		[TestMethod()]
		public void KeySignature_TransposeUp_Test()
		{
			//public static KeySignature GetTransposed(KeySignature key, Interval interval)


			var intervals = Interval.Catalog.Where(x => x > Interval.Unison);
			foreach (var key in KeySignature.Catalog)
			{
				Debug.WriteLine($"Key = {key.NoteName.Name}");
				Debug.Indent();
				foreach (var interval in intervals)
				{
					var expected = KeySignature.GetTransposed(key, (Interval)interval);
					Debug.WriteLine($"transposed by {interval.ToString()} = {expected.NoteName.Name}");
					new object();
				}
				Debug.Unindent();

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
					if (KeySignature.TryDetermineKey(chords, out key, out var probableKey))
					{
						Assert.AreEqual(KeySignature.CMajor, key);
						Assert.IsNull(probableKey);
					}
					else
					{
						Assert.Fail();
					}
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
					if (KeySignature.TryDetermineKey(chords, out key, out var probableKey))
					{
						Assert.IsNull(key);
						Assert.IsNotNull(probableKey);
					}
					else
					{
						Assert.Fail();
					}
				}
			}
		}

	}//class
}//ns