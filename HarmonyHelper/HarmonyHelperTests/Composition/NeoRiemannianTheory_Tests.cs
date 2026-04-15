using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Eric.Morrison;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;

using HarmonyHelper.Chords.NeoRiemannianTheory;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace zHarmonyHelperTests;

[TestClass]
public class NeoRiemannianTheory_Tests
{
    [TestMethod]
    public void TestMethod1()
    {
        var nnRows = new List<(NoteName NoteName, ChordIntervalsEnum ChordType)>() { (NoteName.Ab, ChordIntervalsEnum.Minor), (NoteName.B, ChordIntervalsEnum.Major) };
        var nrtChords = new List<NrtChordFormula>();

        for (int ndxRow = 0; ndxRow < 12; ++ndxRow)
        {
            var strs = new List<string>();
            if (ndxRow % 2 == 0)
                strs.Add("\t");


            var nnRow = nnRows[ndxRow % 2];
            nnRow.NoteName += Interval.DiminishedOctave;
            nnRows[ndxRow % 2] = (NoteName: nnRow.NoteName, nnRow.ChordType);

            var circle = new CircleOf(Interval.Perfect4th, nnRow.NoteName, true);
            for (int i = 0; i < 13; ++i)
            {
                var key = circle.Keys.NextOrFirst<KeySignature>(i);
                //Debug.Write($"{key.NoteName}\t");
                strs.Add(key.NoteName.ToString());
                strs.Add("\t");

                var minorFormula = ChordFormula.Catalog
                    .First(x => x.Root == nnRow.NoteName
                        && x.ChordType == ChordIntervalsEnum.Minor);
                var nrtMinor = NrtChordFormula.CreateEx(minorFormula);
                nrtChords.Add(nrtMinor);

                var majorFormula = ChordFormula.Catalog
                    .First(x => x.Root == nnRow.NoteName
                        && x.ChordType == ChordIntervalsEnum.Major);
                var nrtMajor = NrtChordFormula.CreateEx(majorFormula);
                nrtChords.Add(nrtMajor);
            }

            foreach (var str in strs)
                Debug.Write(str);
            Debug.WriteLine("");

        }

        foreach (var nrtChord in nrtChords.OrderBy(x => (x.Formula.Root.AsciiSortValue, x.Formula.ChordType)))
        {
            var p = nrtChord.P;
            var l = nrtChord.L;
            var r = nrtChord.R;
            Debug.WriteLine($"Chord: {nrtChord.Formula.Name}\t P={p.Name}, L={l.Name}, R={r.Name}");
        }
        new object();


        //var CircleOfFifths = new CircleOf(Interval.Perfect4th, this.Key.NoteName, this.Key.IsMajor);
        new object();

    }

    [TestMethod]
    public void BuildTonnetz()
    {
        var nrtChords = new List<NrtChordFormula>();
        var circle = new CircleOf(Interval.Perfect4th, NoteName.C, true);

        var tonnetz = new Tonnetz();
        //foreach (var key in circle.Keys)
        //{
        //    tonnetz.Nodes.Add(new TonnetzNode(new NRTChordFormula(ChordFormula.Create(key.NoteName, ChordIntervalsEnum.Minor)), null));
        //    tonnetz.Nodes.Add(new TonnetzNode(new NRTChordFormula(ChordFormula.Create(key.NoteName, ChordIntervalsEnum.Major)), null));
        //}

        {
            var cMaj = tonnetz
                .Where(x => x.Root == NoteName.C && x.ChordType == ChordIntervalsEnum.Major)
                .First();
            var l = cMaj.L;
            var p = cMaj.P;
            var r = cMaj.R;

            foreach (var node in tonnetz)
            {
                Debug.WriteLine($"Node: {node.Name}\t Neighbors: {string.Join(", ", node.Neighbors.Select(x => x.Name))}");
            }

            new object();
        }

        new object();
    }

    [TestMethod]
    public void FindShortestPath_Test()
    {
        var tonnetz = new Tonnetz();

        {
            foreach (var node in tonnetz.Nodes)
            {
                Debug.WriteLine(node.NrtFormula);
            }
            new object();
        }

#if false
        {
            var start = new ChordState(NoteName.C, ChordIntervalsEnum.Major);
            var end = new ChordState(NoteName.E, ChordIntervalsEnum.Minor);
            var path = tonnetz.FindShortestPath(start, end);
            new object();
        }

        {
            var start = new ChordState(NoteName.Bb, ChordIntervalsEnum.Major);
            var end = new ChordState(NoteName.E, ChordIntervalsEnum.Minor);
            var path = tonnetz.FindShortestPath(start, end);
            new object();
        }
#endif
        new object();
    }

    [TestMethod]
    public void TonnetzPopulation_Test()
    {
        var tonnetz = new Tonnetz();

        var nodes = tonnetz.Nodes.Distinct<TonnetzNode>().ToList();
        var count = tonnetz.Nodes.Count;
        new object();
    }

}// class

