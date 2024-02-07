using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelper.Composition;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HarmonyHelper.Composition.Tests
{
    [TestClass()]
    public class MelodyFactoryTests
    {
        [TestMethod()]
        public void MelodyFactoryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            for (int i = 1; i < 9; i++) 
            {
                var msg = 
                $"{(((i & 4) > 0) ? 1 : 0)}"+
                $"{(((i & 2) > 0) ? 1 : 0)}"+
                $"{(((i & 1) > 0) ? 1 : 0)}";
                Debug.WriteLine(msg);
            }
            new object();

            var seq = ChordSequenceTests.CreateChordSequence();
            MelodyFactory.Create(seq);
        }
    }
}