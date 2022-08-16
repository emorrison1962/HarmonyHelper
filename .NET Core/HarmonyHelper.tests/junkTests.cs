using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHelper.Tests
{
    [TestClass()]
    public class junkTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var j = new Junk();
            var k = new Junk();

            var b = (j == k);
            var q = j.Equals(k);

            //Assert.IsTrue();
        }
    }
}