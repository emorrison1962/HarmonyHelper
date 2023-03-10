using System;
using System.Diagnostics;
using System.Linq;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Intervals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoteName_Tests
{
	[TestClass()]
	public class NoteNameTests
	{
		[TestMethod]
		public void NoteName_Transpose()
		{
			var i = NoteName.CSharp - NoteName.BSharp;
			//Assert.AreEqual(Interval.DiminishedOctave.Value, i.Value);

			foreach (var noteName in NoteName.Catalog)
			{
				var intervals = Interval.Catalog.Where(x => x != Interval.Unison && x != Interval.PerfectOctave);
				foreach (var interval in intervals)
				{
					if (NoteName.IsValidTransposition(noteName, interval))
					{
                        var txposedUp = NoteName.TransposeUp(noteName, interval, true);

						var expectedInterval = txposedUp - noteName;

						var eq = expectedInterval == interval;
						Assert.AreEqual(expectedInterval, interval);

						Assert.IsTrue(expectedInterval.Value == interval.Value);
						Assert.IsFalse(txposedUp == noteName);

						var inversion = interval.GetInversion();
						if (NoteName.IsValidTransposition(txposedUp, inversion))
						{
                            var txposedDown = NoteName.TransposeUp(txposedUp, inversion, true);

							expectedInterval = (txposedDown) - noteName;

							//Assert.IsTrue(expectedInterval == Interval.Unison);
							Assert.IsFalse(txposedDown == txposedUp);
							Assert.IsTrue(txposedDown == noteName);
						}
					}
				}
			}
		}


		[TestMethod()]
		public void NoteName_Interval_AdditionTest()
		{
			var intervals = Interval.Catalog.Where(x => x > Interval.Unison);
			foreach (var note in NoteName.Catalog)
			{
				foreach (var interval in intervals)
				{
					if (NoteName.IsValidTransposition(note, interval))
					{
                        var txposed = NoteName.TransposeUp(note, interval);

						var actual = txposed - interval;
						if (actual.RawValue != note.RawValue)
							Assert.Fail();
					}
				}
			}
			new object();
		}

		[TestMethod()]
		public void NoteName_Interval_SubtractionTest()
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
                        var success = false;
                        var txposed = NoteName.TransposeUp(note, inversion, true);

						if (NoteName.IsValidTransposition(txposed, inversion))
						{
							var actual = NoteName.TransposeUp(txposed, interval, true);
							if (actual != note)
							{
								var msg = $"note= {note.Name}, inversion={inversion}, txposed= {txposed.Name}, actual={actual.Name}, expected {note.Name}";
								Debug.WriteLine(msg);

								Assert.Fail();
							}
						}
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
						Assert.IsTrue(nn1.RawValue == nn2.RawValue);
					}
					else
					{
						Assert.IsTrue(nn1 != nn2);
						Assert.IsTrue(interval.Value == interval2.GetInversion().Value);
					}
				}
			}
			new object();
		}

		[TestMethod()]
		public void NoteName_Subtraction_Test02()
		{
			{
				var intervals = ChordToneInterval.Catalog
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
			}
			{
				var intervals = ScaleToneInterval.Catalog
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
				Assert.IsTrue(ee.All(x => x.RawValue == nn.RawValue));
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
						Assert.IsTrue(equivalents.All(x => x.RawValue == nn2.RawValue));
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
						Assert.IsTrue(ee.All(x => x.RawValue == nn1.RawValue));
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

        [TestMethod()]
        public void NoteName_TransposeUp_Test()
        {
            #region NoteName.Eb
            var nn = NoteName.Eb;
			var tx = nn.TransposeUp(Interval.AugmentedUnison);
			Assert.AreEqual(NoteName.E, tx);

			nn = NoteName.Eb;
			tx = nn.TransposeUp(Interval.AugmentedUnison, true);
			Assert.AreEqual(NoteName.E, tx);

			nn = NoteName.Eb;
			tx = nn.TransposeUp(Interval.Minor2nd, false);
			Assert.AreEqual(NoteName.Fb, tx);

			nn = NoteName.Eb;
			tx = nn.TransposeUp(Interval.Minor2nd, true);
			Assert.AreEqual(NoteName.Fb, tx);

			nn = NoteName.Eb;
			tx = nn.TransposeUp(Interval.Diminished2nd, true);
			Assert.IsTrue(tx.NameAscii == "Fbb");

			nn = NoteName.Eb;
			tx = nn.TransposeUp(Interval.Diminished2nd, false);
			Assert.AreEqual(NoteName.Eb, tx);//Enharmonic equivalent

			nn = NoteName.Eb;
			tx = nn.TransposeUp(Interval.Diminished2nd, true);
			Assert.IsTrue(tx.NameAscii == "Fbb");

            #endregion

            #region NoteName.E
            nn = NoteName.E;
			tx = nn.TransposeUp(Interval.AugmentedUnison);
			//Assert.AreEqual(NoteName.F, tx);

			nn = NoteName.E;
			tx = nn.TransposeUp(Interval.AugmentedUnison, true);
            //Assert.AreEqual(NoteName.ESharp, tx);

            #endregion

            #region NoteName.ESharp

            nn = NoteName.ESharp;
            tx = nn.TransposeUp(Interval.AugmentedUnison);
            Assert.AreEqual(NoteName.FSharp, tx);

            nn = NoteName.ESharp;
            tx = nn.TransposeUp(Interval.AugmentedUnison, true);
            Assert.IsTrue(tx.NameAscii == "E##");

			//Minor2nd
			//Diminished2nd
            #endregion

            #region NoteName.Fb
            nn = NoteName.Fb;
			tx = nn.TransposeUp(Interval.AugmentedUnison);
			Assert.AreEqual(NoteName.F, tx); //We don't support Gbb.

			nn = NoteName.Fb;
			tx = nn.TransposeUp(Interval.AugmentedUnison, true);
            Assert.AreEqual(NoteName.F, tx); //We don't support Gbb.

            #endregion
            
			#region NoteName.F

            nn = NoteName.F;
			tx = nn.TransposeUp(Interval.AugmentedUnison);
			Assert.AreEqual(NoteName.FSharp, tx);

			nn = NoteName.F;
			tx = nn.TransposeUp(Interval.AugmentedUnison, true);
			Assert.AreEqual(NoteName.FSharp, tx);

			#endregion

			#region NoteName.FSharp
			nn = NoteName.FSharp;
			"start here."
			tx = nn.TransposeUp(Interval.AugmentedUnison);
			Assert.AreEqual(NoteName.G, tx);

			nn = NoteName.FSharp;
			tx = nn.TransposeUp(Interval.AugmentedUnison, true);
			Assert.IsTrue(tx.NameAscii == "F##");

            #endregion

            #region NoteName.Cb

            nn = NoteName.Cb;
			tx = nn.TransposeUp(Interval.AugmentedUnison);
			Assert.AreEqual(NoteName.C, tx);

			nn = NoteName.Cb;
			tx = nn.TransposeUp(Interval.AugmentedUnison, true);
            Assert.AreEqual(NoteName.C, tx);

            nn = NoteName.Cb;
            tx = nn.TransposeUp(Interval.AugmentedUnison.GetInversion());
            Assert.AreEqual(NoteName.D, tx);

            nn = NoteName.Cb;
            tx = nn.TransposeUp(Interval.AugmentedUnison.GetInversion(), true);
            Assert.IsTrue(tx.NameAscii == "Cbb");

            #endregion

            #region NoteName.C
            nn = NoteName.C;
			tx = nn.TransposeUp(Interval.AugmentedUnison);
            //Assert.AreEqual(NoteName.E, tx);

            #endregion

            #region NoteName.CSharp
            nn = NoteName.CSharp;
			tx = nn.TransposeUp(Interval.AugmentedUnison);
            //Assert.AreEqual(NoteName.E, tx);

            #endregion

            #region NoteName.Gb
            nn = NoteName.Gb;
			tx = nn.TransposeUp(Interval.AugmentedUnison);
			//Assert.AreEqual(NoteName.E, tx);

			#endregion
			
			nn = NoteName.G;
            tx = nn.TransposeUp(Interval.AugmentedUnison);
            //Assert.AreEqual(NoteName.E, tx);

            nn = NoteName.GSharp;
            tx = nn.TransposeUp(Interval.AugmentedUnison);
            //Assert.AreEqual(NoteName.E, tx);

            nn = NoteName.Bb;
            tx = nn.TransposeUp(Interval.AugmentedUnison);
            //Assert.AreEqual(NoteName.E, tx);

            nn = NoteName.B;
            tx = nn.TransposeUp(Interval.AugmentedUnison);
            //Assert.AreEqual(NoteName.E, tx);

            nn = NoteName.BSharp;
            tx = nn.TransposeUp(Interval.AugmentedUnison);
            //Assert.AreEqual(NoteName.E, tx);


            new object();
        }

    }//class
}//ns