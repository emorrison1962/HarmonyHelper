using System;
using System.Diagnostics;
using System.Linq;
using Eric.Morrison.Harmony.Intervals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class NoteNameTests
	{


		[TestMethod()]
		public void NoteName_IntervalContext_AdditionTest()
		{
			var intervals = Interval.Catalog.Where(x => x > Interval.Unison);
			foreach (var note in NoteName.Catalog)
			{
				foreach (var interval in intervals)
				{
					if (NoteName.IsValidTransposition(note, interval))
					{
                        var success = NoteName.TryTransposeUp(note, interval, out var txposed, out var unused);
						Assert.IsTrue(success);

						var actual = txposed - interval;
						if (actual.Value != note.Value)
							Assert.Fail();
					}
				}
			}
			new object();
		}

		[TestMethod()]
		public void NoteName_IntervalContext_SubtractionTest()
		{
			var intervals = Interval.Catalog.Where(x => x != Interval.Unison 
				&& x != Interval.PerfectOctave);
			foreach (var note in NoteName.Catalog)
			{
				foreach (var interval in intervals)
				{
					var inversion = interval.GetInversion();
					if (NoteName.IsValidTransposition(note, inversion))
					{
						var success = NoteName.TryTransposeUp(note, inversion, out var txposed, out var unused);
						Assert.IsTrue(success);

						var actual = txposed - inversion;
						if (actual != note)
							Assert.Fail();
					}
				}
			}
			new object();
		}

		[TestMethod()]
		public void NoteName_Subtraction_Test()
		{
			var cat1 = NoteName.Catalog;
			var cat2 = NoteName.Catalog;

			foreach (var nn1 in cat1)
			{
				foreach (var nn2 in cat2)
				{
					var interval = nn1 - nn2;
					Debug.WriteLine($"{nn1} - {nn2} = {interval}");
					var interval2 = nn2 - nn1;
					Debug.WriteLine($"{nn2} - {nn1} = {interval}");
					if (interval == Interval.Unison)
					{
						Assert.IsTrue(nn1.Value == nn2.Value);
					}
					else
					{
						Assert.IsTrue(nn1.Value != nn2.Value);
						Assert.IsTrue(interval.Value == interval2.GetInversion().Value);
					}
				}
			}
			new object();
		}

		[TestMethod()]
		public void NoteName_Subtraction_Test02()
		{
			var intervals = Interval.Catalog
				.Where(x => x > Interval.Unison)
				.ToList();

			foreach (var interval in intervals)
			{
				var key = KeySignature.BbMajor;
				var subtrahend = NoteName.C + interval;
				var result = NoteName.C - subtrahend;
				var expected = interval;
				Assert.AreEqual(interval.Value, expected.Value);
			}

			new object();
		}

		[TestMethod()]
		public void Copy_Test()
		{
			foreach (var nn in NoteName.Catalog)
			{
				var copy = nn.Copy();
				Assert.AreEqual(nn, copy);
			}
		}

		[TestMethod()]
		public void Static_Copy_Test()
		{
			foreach (var nn in NoteName.Catalog)
			{
				var copy = NoteName.Copy(nn);
				Assert.AreEqual(nn, copy);
			}
		}

		[TestMethod()]
		public void GetEnharmonicEquivalent_Test()
		{
			foreach (var nn in NoteName.Catalog)
			{
				var ee = NoteName.GetEnharmonicEquivalents(nn);
				Assert.IsTrue(ee.All(x => x.Value == nn.Value));
			}
			new object();
		}

		[TestMethod()]
		public void ToString_Test()
		{
			foreach (var nn in NoteName.Catalog)
			{
				var s = nn.ToString();
				// Debug.WriteLine($"case \"{s}\": step = Step; break;");
				Assert.IsNotNull(s);
				Assert.AreNotEqual(string.Empty, s);
			}
			new Object();
		}

		[TestMethod()]
		public void CompareTo_Test()
		{
			var count = NoteName.Catalog.Count();
			var lessThan = 0;
			var greaterThan = 0;
			for (int i = 0 ; i < count ; ++i)
			{
				var nn1 = NoteName.Catalog.ElementAt(i);
				foreach (var nn2 in NoteName.Catalog)
				{
					int compare = nn1.CompareTo(nn2);
					if (0 == compare)
					{
						var equivalents = NoteName.GetEnharmonicEquivalents(nn1);
						Assert.IsTrue(equivalents.All(x => x.Value == nn2.Value));
					}
					if (compare < 0)
						++lessThan;
					if (compare > 0)
						++greaterThan;
				}
			}
			Assert.AreEqual(lessThan, greaterThan);
		}

		[TestMethod()]
		public void Compare_Test()
		{
			var count = NoteName.Catalog.Count();
			var lessThan = 0;
			var greaterThan = 0;
			for (int i = 0 ; i < count ; ++i)
			{
				var nn1 = NoteName.Catalog.ElementAt(i);
				foreach (var nn2 in NoteName.Catalog)
				{
					int compare = NoteName.Compare(nn1, nn2);
					if (0 == compare)
					{
						var ee = NoteName.GetEnharmonicEquivalents(nn1);
						Assert.IsTrue(ee.All(x => x.Value == nn1.Value));
					}
					if (compare < 0)
						++lessThan;
					if (compare > 0)
						++greaterThan;
				}
			}
			Assert.AreEqual(lessThan, greaterThan);
		}

		[Ignore]
		[TestMethod()]
		public void EqualsTest()
		{
			Assert.Fail();
		}

		[Ignore]
		[TestMethod()]
		public void EqualsTest1()
		{
			Assert.Fail();
		}

	}


}