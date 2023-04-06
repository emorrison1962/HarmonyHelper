using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelperControls.WinForms;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony;
using Newtonsoft.Json;

namespace HarmonyHelperControls.WinForms.Tests
{
    [TestClass()]
    public class MiscTests
    {
        [TestMethod()]
        public void fooTest()
        {
            var junk = new Runes02();
            var json = Helpers.LoadEmbeddedResource("bravura_metadata.json");

            var blob = JsonConvert.DeserializeObject(json);

            new object();
        }
    }
}