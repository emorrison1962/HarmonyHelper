using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelper.Melody;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHelper.Melody.Tests
{
    [TestClass()]
    public class MelodyGeneratorTests
    {
        [TestMethod()]
        public void CreateMelodyTest()
        {
            var str = "c6 e7 a7 d7 g7 b7 e7 a7 abdim7";
            new MelodyGenerator().CreateMelody(str);    
            Assert.Fail();
        }
    }
}