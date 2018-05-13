using System;
using System.Diagnostics;
using System.Linq;
using Eric.Morrison.Harmony.Scales;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class ScaleFormulaTests
	{
		[TestMethod()]
		public void GenerateModalScaleFormulaIntervals()
		{
			var keys = KeySignature.MinorKeys;
			foreach (var key in keys)
			{
				var modes = Enum.GetValues(typeof(ModeEnum)).Cast<ModeEnum>().ToList();

				foreach (var mode in modes)
				{
					var scale = new MajorModalScaleFormula(key, mode);
					Debug.WriteLine($"{key.NoteName}m: {string.Join(",", key.Accidentals)}\t{scale.ToString()}");
					new object();

					foreach (var nn in scale.NoteNames)
					{
						foreach (var nn2 in scale.NoteNames)
						{
							var interval = nn2 - nn;
							Debug.WriteLine($"{nn2} - {nn} = {interval.Name}");
						}
						Debug.WriteLine("");
					}
					break;
				}
			}
			//Debug.WriteLine(scale.ToString());
			new object();
		}




		[TestMethod()]
		public void MelodicMinorScaleFormulaTest()
		{
			var keys = KeySignature.MinorKeys;
			foreach (var key in keys)
			{
				var scale = new MelodicMinorScaleFormula(key);
				Debug.WriteLine($"{key.NoteName}m: {string.Join(",", key.Accidentals)}\t{scale.ToString()}");
				new object();
			}
			//Debug.WriteLine(scale.ToString());
			new object();
		}

	}//class
}//ns