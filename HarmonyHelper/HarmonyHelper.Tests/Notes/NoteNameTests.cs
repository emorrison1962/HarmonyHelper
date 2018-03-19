using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

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
# warning ******  next test KeySignature Transpose, the Gg7ModulationTest. ******
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

		// Test this
		//public static IntervalsEnum operator -(NoteName a, NoteName b)
		//{
		//	var result = IntervalsEnum.None;
		//	if (null != a && null != b)
		//	{
		//		var notes = NoteName.GetNoteNames()
		//			.Distinct(new NoteNameValueEqualityComparer())
		//			.OrderBy(x => x.Value)
		//			.ToList();

		//		var ndxA = notes.FindIndex(x => x.Value == a.Value);
		//		var ndxB = notes.FindIndex(x => x.Value == b.Value);

		//		var diff = Math.Abs(ndxA - ndxB);
		//		var pow = 1 << diff;
		//		result = (IntervalsEnum)pow;
		//	}
		//	return result;
		//}

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
		public void CopyTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void CopyTest1()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetEnharmonicEquivalentTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetNoteNamesTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void ToStringTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void CompareToTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void CompareTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void EqualsTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void EqualsTest1()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetHashCodeTest()
		{
			Assert.Fail();

		}
	}

	static partial class Extensions
	{


	}


}