using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace HarmonyHelper.Chords.NeoRiemannianTheory
{
    public class Tonnetz : IEnumerable<TonnetzNode>
    {
        public List<TonnetzNode> Nodes { get; set; } = new List<TonnetzNode>();

        public Tonnetz()
        {
            var nrtChords = new List<NrtChordFormula>();
            var circle = new CircleOf(Interval.Perfect4th, NoteName.C, true);

            foreach (var key in circle.Keys)
            {
                var minorFormula = ChordFormula.Catalog
                    .First(x => x.Root == key.NoteName
                        && x.ChordType == ChordIntervalsEnum.Minor);
                this.Nodes.Add(new TonnetzNode(NrtChordFormula.CreateEx(minorFormula), null));

                var majorFormula = ChordFormula.Catalog
                    .First(x => x.Root == key.NoteName
                        && x.ChordType == ChordIntervalsEnum.Major);
                this.Nodes.Add(new TonnetzNode(NrtChordFormula.CreateEx(majorFormula), null));
            }
            new object();
        }

        public IEnumerator<TonnetzNode> GetEnumerator()
        {
            return ((IEnumerable<TonnetzNode>)this.Nodes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.Nodes).GetEnumerator();
        }

        public class ChordStateQueueItem : IEqualityComparer<ChordStateQueueItem>
        {
            public List<ChordState> Path { get; set; }
            public ChordState ChordState { get; set; }

            public ChordStateQueueItem(ChordState chordState, List<ChordState> path)
            {
                this.ChordState = chordState;
                this.Path = path;
            }

            public override string ToString()
            {
                return $"{this.GetType().Name}: {ChordState} at Path Length={Path.Count}";
            }

            public bool Equals(ChordStateQueueItem? x, ChordStateQueueItem? y)
            {
                if (x is null || y is null)
                    return false;
                if (x.ChordState.Equals(y.ChordState))
                    return true;
                else
                    return false;
            }

            public int GetHashCode([DisallowNull] ChordStateQueueItem obj)
            {
                return obj.ChordState.GetHashCode();
            }
        }

        public class Transformation
        {
            public ChordState NextState { get; set; }
            public string MoveName { get; set; }
            public Transformation(ChordState nextState, string moveName)
            {
                this.NextState = nextState;
                this.MoveName = moveName;
            }
        }

    }//class

}//ns
