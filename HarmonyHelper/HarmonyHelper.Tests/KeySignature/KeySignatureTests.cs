using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class KeySignatureTests
	{
		[TestMethod()]
		public void KeySignature_TransposeUp_Test()
		{
			//public static KeySignature GetTransposed(KeySignature key, IntervalsEnum interval)


			var intervals = Enum.GetValues(typeof(IntervalsEnum));
			foreach (var key in KeySignature.Catalog)
			{
				Debug.WriteLine($"Key = {key.NoteName.Name}");
				Debug.Indent();
				foreach (var interval in intervals)
				{
					var expected = KeySignature.GetTransposed(key, (IntervalsEnum)interval);
					Debug.WriteLine($"transposed by {interval.ToString()} = {expected.NoteName.Name}");
					new object();

					//var expectedValue = key.Value;
					//var ctx = new IntervalContext(KeySignature.CMajor, (IntervalsEnum)interval);
					//var result = key + ctx;

					//ValidateTransposeUp(key, (IntervalsEnum)interval, expected);
				}
				Debug.Unindent();

			}
			new object();
		}
	}
}