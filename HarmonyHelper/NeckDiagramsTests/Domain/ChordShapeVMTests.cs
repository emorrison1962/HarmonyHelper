using Eric.Morrison.Harmony.Chords;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using NeckDiagrams.Domain;

using System;
using System.Collections.Generic;
using System.Text;

namespace zNeckDiagrams.Domain.Tests
{
    [TestClass()]
    public class ChordShapeVMTests
    {
        [Ignore]
        [TestMethod()]
        public void ChordShapeVMTest()
        {
            Assert.Fail();
        }
        [Ignore]
        [TestMethod()]
        public void EventsTest()
        {
            var model = new ChordShapeVM();
            model.PropertyChanged += this.Model_PropertyChanged;
            model.Set(ChordFormula.CMajor7);
            Assert.Fail("Events Test");
        }

        private void Model_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }//class
}//ns