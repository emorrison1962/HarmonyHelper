using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eric.Morrison.Harmony
{
	[TestClass]
	public class BUGS
	{
		[TestMethod]
		public void TestMethod1()
		{
			var indexes = new List<int>();
			foreach (var interval in Interval.Catalog)
			{
				var ndx = interval.ToIndex();
				indexes.Add(ndx);
			}
			Assert.IsTrue(indexes.Count == indexes.Distinct().Count());
			new object();
		}
	}
}
