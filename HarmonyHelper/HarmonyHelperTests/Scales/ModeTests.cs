using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Mode_Tests
{
	[TestClass()]
	public class ModeTests
	{
		List<KeySignature> GetKeySignatures()
		{
			return new List<KeySignature>() {
				KeySignature.CMajor,
				KeySignature.FMajor,
				KeySignature.BbMajor,
				KeySignature.EbMajor,
				KeySignature.AbMajor,
				KeySignature.DbMajor,
				KeySignature.FSharpMajor,
				KeySignature.BbMajor,
				KeySignature.EMajor,
				KeySignature.AMajor,
				KeySignature.DMajor,
				KeySignature.GMajor,
			};
		}

		List<ModeEnum> GetModeEnums()
		{
			var result = new List<ModeEnum>();
			var arr = Enum.GetValues(typeof(ModeEnum));
			foreach (var val in arr)
				result.Add((ModeEnum)val);
			return result;
		}

		[TestMethod()]
		public void ModeTest()
		{
			var keys = this.GetKeySignatures();
			var modes = this.GetModeEnums();
			foreach (var key in keys)
			{
				foreach (var formula in modes)
				{
					var mode = new Mode(key, formula, NoteRange.Default);
					Debug.WriteLine(mode.ToString());
					new object();
				}
				Debug.WriteLine("");
				new object();
			}
		}

		[TestMethod()]
		public void ToStringTest()
		{
			var keys = this.GetKeySignatures();
			var modes = this.GetModeEnums();
			foreach (var key in keys)
			{
				foreach (var formula in modes)
				{
					var mode = new Mode(key, formula, NoteRange.Default);
					Debug.WriteLine(mode.ToString());
					Assert.IsFalse(string.IsNullOrEmpty(mode.Name));

					Debug.WriteLine($"{string.Join(",", mode.Formula.NoteNames)}");
					Debug.WriteLine($"{string.Join(",", mode.Notes)}");
					new object();
				}
				Debug.WriteLine("");
			}
			new Object();
		}
	}
}