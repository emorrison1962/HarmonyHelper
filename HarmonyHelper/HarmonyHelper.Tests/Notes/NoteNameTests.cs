﻿using System;
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
					var valid = true;
					if (
						(note == NoteName.BSharpSharp && interval == Interval.AugmentedUnison)
						|| (note == NoteName.BSharpSharp && interval == Interval.Major2nd)
						|| (note == NoteName.BSharpSharp && interval == Interval.Major3rd)
						|| (note == NoteName.BSharpSharp && interval == Interval.Augmented4th)
						|| (note == NoteName.BSharpSharp && interval == Interval.Perfect5th)
						|| (note == NoteName.BSharpSharp && interval == Interval.Augmented5th)
						|| (note == NoteName.BSharpSharp && interval == Interval.Major6th)
						|| (note == NoteName.BSharpSharp && interval == Interval.Augmented6th)
						|| (note == NoteName.BSharpSharp && interval == Interval.Major7th)
						
						|| (note == NoteName.CSharpSharp && interval == Interval.AugmentedUnison)
						|| (note == NoteName.CSharpSharp && interval == Interval.Augmented4th)
						|| (note == NoteName.CSharpSharp && interval == Interval.Augmented5th)
						|| (note == NoteName.CSharpSharp && interval == Interval.Augmented6th)

						|| (note == NoteName.Ebb && interval == Interval.Diminished3rd)
						|| (note == NoteName.Ebb && interval == Interval.Diminished4th)
						|| (note == NoteName.Ebb && interval == Interval.Diminished5th)
						|| (note == NoteName.Ebb && interval == Interval.Diminished7th)
						|| (note == NoteName.Ebb && interval == Interval.DiminishedOctave)

						|| (note == NoteName.Fbb && interval == Interval.Minor2nd)
						|| (note == NoteName.Fbb && interval == Interval.Diminished3rd)
						|| (note == NoteName.Fbb && interval == Interval.Augmented2nd)
						|| (note == NoteName.Fbb && interval == Interval.Minor3rd)
						|| (note == NoteName.Fbb && interval == Interval.Diminished4th)
						|| (note == NoteName.Fbb && interval == Interval.Perfect4th)
						|| (note == NoteName.Fbb && interval == Interval.Diminished5th)
						|| (note == NoteName.Fbb && interval == Interval.Minor6th)
						|| (note == NoteName.Fbb && interval == Interval.Diminished7th)
						|| (note == NoteName.Fbb && interval == Interval.Minor7th)
						|| (note == NoteName.Fbb && interval == Interval.DiminishedOctave)

						|| (note == NoteName.DSharpSharp && interval == Interval.AugmentedUnison)
						|| (note == NoteName.DSharpSharp && interval == Interval.Major3rd)
						|| (note == NoteName.DSharpSharp && interval == Interval.Augmented4th)
						|| (note == NoteName.DSharpSharp && interval == Interval.Augmented5th)
						|| (note == NoteName.DSharpSharp && interval == Interval.Augmented6th)
						|| (note == NoteName.DSharpSharp && interval == Interval.Major7th)
						
						|| (note == NoteName.Fb && interval == Interval.Diminished3rd)
						|| (note == NoteName.Fb && interval == Interval.Diminished4th)
						|| (note == NoteName.Fb && interval == Interval.Diminished7th)
						
						|| (note == NoteName.ESharp && interval == Interval.Augmented6th)
						
						|| (note == NoteName.Gbb && interval == Interval.Minor2nd)
						|| (note == NoteName.Gbb && interval == Interval.Diminished3rd)
						|| (note == NoteName.Gbb && interval == Interval.Augmented2nd)
						|| (note == NoteName.Gbb && interval == Interval.Minor3rd)
						|| (note == NoteName.Gbb && interval == Interval.Diminished4th)
						|| (note == NoteName.Gbb && interval == Interval.Diminished5th)
						|| (note == NoteName.Gbb && interval == Interval.Minor6th)
						|| (note == NoteName.Gbb && interval == Interval.Diminished7th)
						|| (note == NoteName.Gbb && interval == Interval.DiminishedOctave)
						
						|| (note == NoteName.ESharpSharp && interval == Interval.AugmentedUnison)
						|| (note == NoteName.ESharpSharp && interval == Interval.Major2nd)
						|| (note == NoteName.ESharpSharp && interval == Interval.Major3rd)
						|| (note == NoteName.ESharpSharp && interval == Interval.Augmented4th)
						|| (note == NoteName.ESharpSharp && interval == Interval.Augmented5th)
						|| (note == NoteName.ESharpSharp && interval == Interval.Major6th)
						|| (note == NoteName.ESharpSharp && interval == Interval.Augmented6th)
						|| (note == NoteName.ESharpSharp && interval == Interval.Major7th)
						
						|| (note == NoteName.Gb && interval == Interval.Diminished3rd)
						
						|| (note == NoteName.FSharpSharp && interval == Interval.AugmentedUnison)
						|| (note == NoteName.FSharpSharp && interval == Interval.Augmented5th)
						|| (note == NoteName.FSharpSharp && interval == Interval.Augmented6th)
						
						|| (note == NoteName.Abb && interval == Interval.Minor2nd)
						|| (note == NoteName.Abb && interval == Interval.Diminished3rd)
						|| (note == NoteName.Abb && interval == Interval.Diminished4th)
						|| (note == NoteName.Abb && interval == Interval.Diminished5th)
						|| (note == NoteName.Abb && interval == Interval.Diminished7th)
						|| (note == NoteName.Abb && interval == Interval.DiminishedOctave)
						
						|| (note == NoteName.GSharpSharp && interval == Interval.AugmentedUnison)
						|| (note == NoteName.GSharpSharp && interval == Interval.Augmented4th)
						|| (note == NoteName.GSharpSharp && interval == Interval.Augmented5th)
						|| (note == NoteName.GSharpSharp && interval == Interval.Augmented6th)
						|| (note == NoteName.GSharpSharp && interval == Interval.Major7th)
						
						|| (note == NoteName.Bbb && interval == Interval.Diminished3rd)
						|| (note == NoteName.Bbb && interval == Interval.Diminished4th)
						|| (note == NoteName.Bbb && interval == Interval.Diminished7th)
						|| (note == NoteName.Bbb && interval == Interval.DiminishedOctave)
						
						|| (note == NoteName.ASharp && interval == Interval.Augmented6th)
						
						|| (note == NoteName.Cbb && interval == Interval.Minor2nd)
						|| (note == NoteName.Cbb && interval == Interval.Diminished3rd)
						|| (note == NoteName.Cbb && interval == Interval.Augmented2nd)
						|| (note == NoteName.Cbb && interval == Interval.Minor3rd)
						|| (note == NoteName.Cbb && interval == Interval.Diminished4th)
						|| (note == NoteName.Cbb && interval == Interval.Diminished5th)
						|| (note == NoteName.Cbb && interval == Interval.Minor6th)
						|| (note == NoteName.Cbb && interval == Interval.Diminished7th)
						|| (note == NoteName.Cbb && interval == Interval.Minor7th)
						|| (note == NoteName.Cbb && interval == Interval.DiminishedOctave)
						
						|| (note == NoteName.ASharpSharp && interval == Interval.AugmentedUnison)
						|| (note == NoteName.ASharpSharp && interval == Interval.Major3rd)
						|| (note == NoteName.ASharpSharp && interval == Interval.Augmented4th)
						|| (note == NoteName.ASharpSharp && interval == Interval.Augmented5th)
						|| (note == NoteName.ASharpSharp && interval == Interval.Major6th)
						|| (note == NoteName.ASharpSharp && interval == Interval.Augmented6th)
						|| (note == NoteName.ASharpSharp && interval == Interval.Major7th)
						
						|| (note == NoteName.Cb && interval == Interval.Diminished3rd)
						|| (note == NoteName.Cb && interval == Interval.Diminished7th)

						|| (note == NoteName.BSharp && interval == Interval.Augmented5th)
						|| (note == NoteName.BSharp && interval == Interval.Augmented6th)
						
						|| (note == NoteName.Dbb && interval == Interval.Minor2nd)
						|| (note == NoteName.Dbb && interval == Interval.Diminished3rd)
						|| (note == NoteName.Dbb && interval == Interval.Diminished4th)
						|| (note == NoteName.Dbb && interval == Interval.Diminished5th)
						|| (note == NoteName.Dbb && interval == Interval.Minor6th)
						|| (note == NoteName.Dbb && interval == Interval.Diminished7th)
						|| (note == NoteName.Dbb && interval == Interval.DiminishedOctave)
						)
					{
						valid = false;
					}
					if (valid)
					{
                        var expected = NoteName.TransposeUp(note, (Interval)interval);
                        var expectedValue = note.Value;
                        var ctx = new IntervalContext(KeySignature.CMajor, (Interval)interval);
                        var result = note + ctx;

                        ValidateTransposeUp(note, (Interval)interval, expected);
					}
				}
			}
			new object();
		}

		void ValidateTransposeUp(NoteName input, Interval interval, NoteName expected)
		{
			#region VALIDATION
			if (input == NoteName.BSharp && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}

			else if (input == NoteName.C && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}

			else if (input == NoteName.CSharp && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}

			else if (input == NoteName.Db && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}

			else if (input == NoteName.D && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}

			else if (input == NoteName.DSharp && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}

			else if (input == NoteName.Eb && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}

			else if (input == NoteName.E && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}

			else if (input == NoteName.Fb && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}

			else if (input == NoteName.ESharp && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}

			else if (input == NoteName.F && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}

			else if (input == NoteName.FSharp && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}

			else if (input == NoteName.Gb && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}

			else if (input == NoteName.G && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}

			else if (input == NoteName.GSharp && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}

			else if (input == NoteName.Ab && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}

			else if (input == NoteName.A && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}

			else if (input == NoteName.ASharp && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}

			else if (input == NoteName.Bb && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}

			else if (input == NoteName.B && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}

			else if (input == NoteName.Cb && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.AugmentedUnison)
			{
				Assert.IsTrue(expected == NoteName.BSharpSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.CSharpSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.DSharpSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.ESharpSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.AugmentedUnison)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Dbb && (Interval)interval == Interval.AugmentedUnison)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Dbb && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Dbb && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Dbb && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Dbb && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.Dbb);
			}
			else if (input == NoteName.BSharpSharp && (Interval)interval == Interval.Diminished3rd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.BSharpSharp && (Interval)interval == Interval.Augmented2nd)
			{
				Debug.Assert(false);
				//Assert.IsTrue(expected == NoteName.);
			}
			else if (input == NoteName.BSharpSharp && (Interval)interval == Interval.Diminished7th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.BSharpSharp && (Interval)interval == Interval.DiminishedOctave)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.BSharpSharp && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.BSharpSharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Diminished3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Diminished7th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.DiminishedOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Diminished3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Diminished7th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.DiminishedOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.CSharpSharp && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.CSharpSharp && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.CSharpSharp && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Ebb && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Ebb && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Ebb && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.AugmentedUnison)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Augmented5th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Augmented6th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.AugmentedUnison)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Augmented5th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Augmented6th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Fbb && (Interval)interval == Interval.AugmentedUnison)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Fbb && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Fbb && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Fbb && (Interval)interval == Interval.Augmented5th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Fbb && (Interval)interval == Interval.Augmented6th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Fbb && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.DSharpSharp && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.DSharpSharp && (Interval)interval == Interval.DiminishedOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.DSharpSharp && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.DiminishedOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.DiminishedOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.AugmentedUnison)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Augmented5th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.AugmentedUnison)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Augmented5th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Gbb && (Interval)interval == Interval.AugmentedUnison)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Gbb && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Gbb && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Gbb && (Interval)interval == Interval.Augmented5th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Gbb && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ESharpSharp && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ESharpSharp && (Interval)interval == Interval.Diminished7th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ESharpSharp && (Interval)interval == Interval.DiminishedOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ESharpSharp && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Diminished7th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.DiminishedOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Diminished7th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.DiminishedOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.FSharpSharp && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.FSharpSharp && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.FSharpSharp && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.FSharpSharp && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Abb && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Abb && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Abb && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Abb && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.AugmentedUnison)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Diminished3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Augmented5th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Augmented6th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Diminished7th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.DiminishedOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.AugmentedUnison)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Diminished3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Augmented5th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Augmented6th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Diminished7th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.DiminishedOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.GSharpSharp && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.GSharpSharp && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.GSharpSharp && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Bbb && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Bbb && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Bbb && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.AugmentedUnison)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Augmented5th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.AugmentedUnison)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Augmented5th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Cbb && (Interval)interval == Interval.AugmentedUnison)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Cbb && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Cbb && (Interval)interval == Interval.Augmented4th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Cbb && (Interval)interval == Interval.Augmented5th)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Cbb && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ASharpSharp && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ASharpSharp && (Interval)interval == Interval.DiminishedOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.ASharpSharp && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.DiminishedOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Augmented2nd)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.DiminishedOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.PerfectOctave)
			{
				Assert.IsTrue(expected == NoteName.junk);
			}


			else
			{
				throw new NotImplementedException();
				var msg = $@"			else if (input == NoteName.{input.Name} && (Interval)interval == Interval.{interval.Name})
			{{
				Assert.IsTrue(expected == NoteName.junk);
			}}";
				Debug.WriteLine(msg);

			}


			#endregion
		}

		[TestMethod()]
		public void NoteName_IntervalContext_SubtractionTest()
		{
			var intervals = Interval.Catalog.Where(x => x > Interval.Unison);
			foreach (var note in NoteName.Catalog)
			{
				foreach (var interval in intervals)
				{
					if (note == NoteName.BSharp && (Interval)interval == Interval.Diminished4th)
					{
						new object();
					}
					var expected = NoteName.TransposeDown(note, (Interval)interval);
					var expectedValue = note.Value;
					var ctx = new IntervalContext(KeySignature.CMajor, (Interval)interval);
					if (note == NoteName.BSharp && (Interval)interval == Interval.Diminished4th)
					{
						new object();
					}
					var result = note + ctx;

					ValidateTransposeDown(note, (Interval)interval, expected);
				}
			}
			new object();
		}

		void ValidateTransposeDown(NoteName input, Interval interval, NoteName expected)
		{
			#region VALIDATION
			if (input == NoteName.BSharp && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.CSharpSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Major3rd)
			{
				Assert.IsTrue(expected == NoteName.DSharpSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.ESharpSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.FSharpSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Augmented5th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.BSharp && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.C && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.CSharp && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Db && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.D && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.DSharp && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Eb && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.E && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Fb && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.ESharp && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.F && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.FSharp && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Gb && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.G && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.GSharp && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Ab && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.A && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.ESharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.BSharp);
			}
			else if (input == NoteName.ASharp && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Bb && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.B);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.ASharp);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.GSharp);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.FSharp);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.E);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.DSharp);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.CSharp);
			}
			else if (input == NoteName.B && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Unison)
			{
				Assert.IsTrue(expected == NoteName.Cb);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Minor2nd)
			{
				Assert.IsTrue(expected == NoteName.Bb);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Major2nd)
			{
				Assert.IsTrue(expected == NoteName.A);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Minor3rd)
			{
				Assert.IsTrue(expected == NoteName.Ab);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Diminished4th)
			{
				Assert.IsTrue(expected == NoteName.G);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Perfect4th)
			{
				Assert.IsTrue(expected == NoteName.Gb);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Diminished5th)
			{
				Assert.IsTrue(expected == NoteName.F);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Perfect5th)
			{
				Assert.IsTrue(expected == NoteName.Fb);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Minor6th)
			{
				Assert.IsTrue(expected == NoteName.Eb);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Major6th)
			{
				Assert.IsTrue(expected == NoteName.D);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Minor7th)
			{
				Assert.IsTrue(expected == NoteName.Db);
			}
			else if (input == NoteName.Cb && (Interval)interval == Interval.Major7th)
			{
				Assert.IsTrue(expected == NoteName.C);
			}
			else
			{ 
				throw new NotImplementedException();
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
				var subtrahend = NoteName.C + new IntervalContext(key, interval);
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
				Assert.IsTrue(ee.All(x => x == nn));
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
						Assert.IsTrue(equivalents.All(x => x == nn2));
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
						Assert.IsTrue(ee.All(x => x == nn1));
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