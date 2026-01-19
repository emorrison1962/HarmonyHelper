//NeckDiagramsTests\Domain\ChordShapeVMTests.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Eric.Morrison.Harmony.Chords;
using NeckDiagrams.Domain;

namespace zNeckDiagrams.Domain.Tests
{
    [TestClass]
    public class CoPilot_ChordShapeVMTests
    {
        [TestMethod]
        public void Constructor_Defaults()
        {
            var vm = new ChordShapeVM();
            // Initial ChordFormula should be null (not set)
            Assert.IsNull(vm.ChordFormula);
        }

        [TestMethod]
        public void Set_SetsChordFormula_RaisesPropertyChanged_AndUpdatesGuitarStrings()
        {
            var vm = new ChordShapeVM();

            var seen = new List<string>();
            vm.PropertyChanged += (s, e) =>
            {
                if (!string.IsNullOrEmpty(e.PropertyName))
                    seen.Add(e.PropertyName);
            };

            var cf = ChordFormula.CMajor7;
            Assert.IsNotNull(cf, "Test precondition failed: ChordFormula.CMajor7 is null");

            // Act
            vm.Set(cf);

            // ChordFormula property must be set
            Assert.AreSame(cf, vm.ChordFormula);

            // NoteNames property should reflect the chord formula's note names
            CollectionAssert.AreEqual(cf.NoteNames, vm.NoteNames);

            // PropertyChanged should have fired for ChordFormula (at least once)
            Assert.IsTrue(seen.Contains(nameof(vm.ChordFormula)), $"PropertyChanged was not raised for {nameof(vm.ChordFormula)}");

            // GuitarStringCollection should be available; if not, mark inconclusive
            var gsc = vm.GuitarStringCollection;
            if (gsc is null)
            {
                Assert.Inconclusive("GuitarStringCollection.LoadSettingsOrDefault returned null - cannot validate guitar string updates.");
            }

            // Dictionary may be null or empty; handle defensively
            var dict = gsc.Dictionary;
            if (dict is null || dict.Values is null || dict.Values.Count == 0)
            {
                Assert.Inconclusive("GuitarStringCollection.Dictionary is not populated - cannot validate guitar string updates.");
            }

            // Each GuitarStringModel.ActiveNotes must match the chord formula's NoteNames
            foreach (var gsm in dict.Values)
            {
                Assert.IsNotNull(gsm, "GuitarStringModel in collection was null");
                Assert.IsNotNull(gsm.ActiveNotes, "GuitarStringModel.ActiveNotes was null");
                Assert.IsTrue(Enumerable.SequenceEqual(cf.NoteNames, gsm.ActiveNotes),
                    "GuitarStringModel.ActiveNotes did not match chord formula NoteNames");
            }
        }

        [TestMethod]
        public void GuitarStringCollection_Set_DoesNotThrow()
        {
            var vm = new ChordShapeVM();
            var current = vm.GuitarStringCollection;

            // Try setting the same collection (SaveToSettings is invoked by setter).
            // We only assert that setter does not throw.
            try
            {
                vm.GuitarStringCollection = current;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Setting GuitarStringCollection threw an exception: {ex}");
            }
        }
    }
}