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

        List<ModeFormula> GetModeFormulas()
        {
            var result = new List<ModeFormula>(ModeFormula.Catalog);
            return result;
        }

        [TestMethod()]
        public void ModeTest()
        {
            var keys = this.GetKeySignatures();
            var modes = this.GetModeFormulas();
            foreach (var key in keys)
            {
                foreach (var formula in modes)
                {
                    var mode = new Mode(formula, key);
                }
            }
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var keys = this.GetKeySignatures();
            var modes = this.GetModeFormulas();
            foreach (var key in keys)
            {
                foreach (var formula in modes)
                {
                    var mode = new Mode(formula, key);
                    Debug.WriteLine(mode);
                }
                Debug.WriteLine("");
            }
            new Object();
        }
    }
}