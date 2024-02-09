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

            var MAX = MotifDirectionEnum.None 
                | MotifDirectionEnum.Ascending 
                | MotifDirectionEnum.Descending;

            for (int i = (int)MotifDirectionEnum.Unknown; i < (int)MAX; i++) 
            {
                var e = (MotifDirectionEnum)i;
                var msg =
                $"{(e.HasFlag(MotifDirectionEnum.Descending) ? 1 : 0)}" +
                $"{(e.HasFlag(MotifDirectionEnum.Ascending) ? 1 : 0)}" +
                $"{(e.HasFlag(MotifDirectionEnum.None) ? 1 : 0)}";
                Debug.WriteLine(msg);
            }
            new object();

            var seq = ChordSequenceTests.CreateChordSequence();
            MelodyFactory.Create(seq);
        }
    }
}