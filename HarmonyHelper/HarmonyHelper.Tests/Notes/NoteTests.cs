﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}