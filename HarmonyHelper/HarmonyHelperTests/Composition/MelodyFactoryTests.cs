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
            var seq = ChordSequenceTests.CreateChordSequence();
            var melody = MelodyFactory.Create(seq);
            Assert.IsNotNull(melody);

            new object();
        }
    }
}