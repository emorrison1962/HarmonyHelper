using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Intervals;
using System.Diagnostics;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class NoteTests
	{
		[TestMethod()]
		public void Note_Test()
		{
			var octaves = Enum.GetValues(typeof(OctaveEnum))
				.Cast<OctaveEnum>()
				.Where(x => OctaveEnum.Unknown != x)
				.ToList();
			foreach (var nn in NoteName.Catalog)
			{
				foreach (var octave in octaves)
				{
					var n = new Note(nn, octave);
					Assert.IsNotNull(n);
				}
			}
		}

		[TestMethod()]
		public void Note_Test1()
		{
			var octaves = Enum.GetValues(typeof(OctaveEnum))
				.Cast<OctaveEnum>()
				.Where(x => OctaveEnum.Unknown != x)
				.ToList();
			foreach (var nn in NoteName.Catalog)
			{
				foreach (var octave in octaves)
				{
					var n1 = new Note(nn, octave);
					var n2 = new Note(n1);
					Assert.AreEqual(n1, n2);
				}
			}
		}

		[TestMethod()]
		public void Copy_Test()
		{
			var octaves = Enum.GetValues(typeof(OctaveEnum))
				.Cast<OctaveEnum>()
				.Where(x => OctaveEnum.Unknown != x)
				.ToList();
			foreach (var nn in NoteName.Catalog)
			{
				foreach (var octave in octaves)
				{
					var n1 = new Note(nn, octave);
					var n2 = n1.Copy();
					Assert.AreEqual(n1, n2);
				}
			}
		}

		[Ignore]
		[TestMethod()]
		public void SetNoteName_Test()
		{
			Assert.Fail();
		}

		[Ignore]
		[TestMethod()]
		public void ToString_Test()
		{
			Assert.Fail();
		}

		[Ignore]
		[TestMethod()]
		public void Equals_Test()
		{
			Assert.Fail();
		}

		[Ignore]
		[TestMethod()]
		public void Equals_Test1()
		{
			Assert.Fail();
		}

		[Ignore]
		[TestMethod()]
		public void CompareTo_Test()
		{
			Assert.Fail();
		}

		[Ignore]
		[TestMethod()]
		public void Compare_Test()
		{
			Assert.Fail();
		}

		[Ignore]
		[TestMethod()]
		public void GetHashCode_Test()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void Bug_B_Minus_C_Test()
		{
			var b = new Note(NoteName.B, OctaveEnum.Octave2);
			var cSharp = new Note(NoteName.CSharp, OctaveEnum.Octave3);

			var interval = b - cSharp;
			Assert.IsTrue(Interval.Minor7th == interval);
			var i2 = cSharp - b;
			Assert.IsTrue(Interval.Major2nd == i2);
		}

		[TestMethod()]
		public void NoteTest_GSharpGreaterThanAFlat_Test()
		{
			var gSharp = new Note(NoteName.GSharp, OctaveEnum.Octave2);
			var aFlat = new Note(NoteName.Ab, OctaveEnum.Octave2);

			Assert.IsFalse(aFlat == gSharp);
			Assert.IsFalse(gSharp.NoteName.RawValue > aFlat.NoteName.RawValue);
			Assert.IsFalse(aFlat.NoteName.RawValue > gSharp.NoteName.RawValue);
		}

	}//class
}//ns