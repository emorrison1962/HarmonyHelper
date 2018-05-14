using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Eric.Morrison.Harmony.Intervals.Tests
{
	[TestClass()]
	public class IntervalBaseTests
	{
		[TestMethod()]
		public void GetNames_Debug()
		{
			foreach (var scaleInterval in ScaleToneInterval.Catalog)
				Debug.WriteLine($"ScaleToneInterval.{scaleInterval.Name}");
		}

		[TestMethod()]
		public void InvertTest()
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
		public void ToStringTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void ToIndexTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetInversionTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetHashCodeTest()
		{
			Assert.Fail();
		}
	}
}