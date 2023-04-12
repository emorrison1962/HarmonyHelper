using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelperControls.WinForms;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony;
using Newtonsoft.Json;
using MyNamespace;
using Manufaktura.Controls.SMuFL.EagerLoading;

namespace HarmonyHelperControls.WinForms.Tests
{
    [TestClass()]
    public class MiscTests
    {
        [TestMethod()]
        public void fooTest()
        {
            var json = Helpers.LoadEmbeddedResource("bravura_metadata.json");

            var blob = JsonConvert.DeserializeObject<SMuFLFontMetadata>(json);

            new object();
        }

    }//class
}//ns