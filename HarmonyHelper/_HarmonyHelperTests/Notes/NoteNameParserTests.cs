using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.Notes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Notes.Tests
{
    [TestClass()]
    public class NoteNameParserTests
    {

        [TestMethod()]
        public void TryParseTest()
        {
            var s = "d e e d g e";
            var result = NoteNameParser.TryParse(s, out var notes, out var msg);
            Assert.IsTrue(result);
            new object();
        }
    }
}