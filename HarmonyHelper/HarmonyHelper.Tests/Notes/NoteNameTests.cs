using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class NoteNameTests
	{


		[TestMethod()]
		public void NoteName_IntervalContext_AdditionTest()
		{
			var intervals = Enum.GetValues(typeof(IntervalsEnum));
			foreach (var note in NoteName.Catalog)
			{
				foreach (var interval in intervals)
				{
					var expected = NoteName.TransposeUp(note, (IntervalsEnum)interval);
					var expectedValue = note.Value;
					var ctx = new IntervalContext(KeySignature.CMajor, (IntervalsEnum)interval);
					var result = note + ctx;

					ValidateTransposeUp(note, (IntervalsEnum)interval, expected);
				}
			}
			new object();
		}

		void ValidateTransposeUp(NoteName input, IntervalsEnum interval, NoteName expected)
		{
			#region VALIDATION
			if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}

			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}

			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}

			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}

			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}

			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}

			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}

			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}

			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}

			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}

			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}

			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}

			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}

			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}

			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}

			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}

			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}

			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}

			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}

			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}

			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}


			#endregion
		}

		[TestMethod()]
		public void NoteName_IntervalContext_SubtractionTest()
		{
			var intervals = Enum.GetValues(typeof(IntervalsEnum));
			foreach (var note in NoteName.Catalog)
			{
				foreach (var interval in intervals)
				{
					var expected = NoteName.TransposeDown(note, (IntervalsEnum)interval);
					var expectedValue = note.Value;
					var ctx = new IntervalContext(KeySignature.CMajor, (IntervalsEnum)interval);
					var result = note + ctx;

					ValidateTransposeDown(note, (IntervalsEnum)interval, expected);
				}
			}
			new object();
		}

		void ValidateTransposeDown(NoteName input, IntervalsEnum interval, NoteName expected)
		{
			#region VALIDATION
			if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.BSharp && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.C && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.CSharp && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Db && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.D && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.DSharp && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Eb && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.E && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Fb && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.ESharp && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.F && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.FSharp && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Gb && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.G && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.GSharp && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Ab && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.A && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.ASharp && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Bb && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.B && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.None)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Major6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Cb && (IntervalsEnum)interval == IntervalsEnum.Major7th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			#endregion VALIDATION
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
					//Debug.WriteLine($"{nn1} - {nn2} = {interval}");
					var interval2 = nn2 - nn1;
					//Debug.WriteLine($"{nn2} - {nn1} = {interval}");
					if (interval == IntervalsEnum.None)
					{
						Assert.IsTrue(nn1.Value == nn2.Value);
					}
					else
					{
						Assert.IsTrue(nn1.Value != nn2.Value);
						Assert.IsTrue(interval.GetInversion() == interval2);
					}
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
				var ee = NoteName.GetEnharmonicEquivalent(nn);
				Assert.AreEqual(nn, ee);
			}
			new object();
		}

		[TestMethod()]
		public void ToString_Test()
		{
			foreach (var nn in NoteName.Catalog)
			{
				var s = nn.ToString();
				Assert.IsNotNull(s);
				Assert.AreNotEqual(string.Empty, s);
			}
		}

		[TestMethod()]
		public void CompareTo_Test()
		{
			var count = NoteName.Catalog.Count;
			var lessThan = 0;
			var greaterThan = 0;
			for (int i = 0; i < count; ++i)
			{
				var nn1 = NoteName.Catalog[i];
				foreach (var nn2 in NoteName.Catalog)
				{
					int compare = nn1.CompareTo(nn2);
					if (0 == compare)
					{
						var ee = NoteName.GetEnharmonicEquivalent(nn1);
						Assert.AreEqual(ee, nn2);
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
			var count = NoteName.Catalog.Count;
			var lessThan = 0;
			var greaterThan = 0;
			for (int i = 0; i < count; ++i)
			{
				var nn1 = NoteName.Catalog[i];
				foreach (var nn2 in NoteName.Catalog)
				{
					int compare = NoteName.Compare(nn1, nn2);
					if (0 == compare)
					{
						var ee = NoteName.GetEnharmonicEquivalent(nn1);
						Assert.AreEqual(ee, nn2);
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