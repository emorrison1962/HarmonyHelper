using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class KeySignatureTests
	{
		[TestMethod()]
		public void KeySignature_TransposeUp_Test()
		{
			//public static KeySignature GetTransposed(KeySignature key, Interval interval)


			var intervals = Interval.Catalog.Where(x => x > Interval.None);
			foreach (var key in KeySignature.Catalog)
			{
				Debug.WriteLine($"Key = {key.NoteName.Name}");
				Debug.Indent();
				foreach (var interval in intervals)
				{
					var expected = KeySignature.GetTransposed(key, (Interval)interval);
					Debug.WriteLine($"transposed by {interval.ToString()} = {expected.NoteName.Name}");
					new object();

					//var expectedValue = key.Value;
					//var ctx = new IntervalContext(KeySignature.CMajor, (Interval)interval);
					//var result = key + ctx;

					//ValidateTransposeUp(key, (Interval)interval, expected);
				}
				Debug.Unindent();

			}
			new object();
		}

		[TestMethod()]
		public void KeySignature_TransposeDown_Test()
		{
			//public static KeySignature GetTransposed(KeySignature key, Interval interval)
			NoteName root = null;
			KeySignature key = null;
			const int CYCLE_MAX = 11;

			for (int i = 0; i <= CYCLE_MAX; ++i)
			{
				if (null == root)
				{
					root = NoteName.C;
					key = KeySignature.CMajor;
				}
				else
				{
					key = key - Interval.Perfect5th;
					root = root - new IntervalContext(key, Interval.Perfect5th);
				}

				Debug.WriteLine($"key={key.ToString()} : {root.Name}");

				new object();

			}

			/*
						var intervals = Enum.GetValues(typeof(Interval));
						foreach (var key in KeySignature.Catalog)
						{
							Debug.WriteLine($"Key = {key.NoteName.Name}");
							Debug.Indent();
							foreach (var interval in intervals)
							{
								var expected = KeySignature.GetTransposed(key, (Interval)interval);
								Debug.WriteLine($"transposed by {interval.ToString()} = {expected.NoteName.Name}");
								new object();

								//var expectedValue = key.Value;
								//var ctx = new IntervalContext(KeySignature.CMajor, (Interval)interval);
								//var result = key + ctx;

								//ValidateTransposeUp(key, (Interval)interval, expected);
							}
							Debug.Unindent();
						}
						*/
			new object();
		}

	}//class
}//ns