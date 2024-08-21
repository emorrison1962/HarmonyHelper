using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;

namespace HarmonyHelper.Chords.NegativeHarmony
{
    /// <summary>
    /// C Ionian transforms into G Phrygian.
    /// C Dorian trasforms into G Dorian.
    /// C Phrygian trasforms into G Ionian.
    /// C Lydian transforms into G Locrian.
    /// C Mixolydian trasforms into G Aelian.
    /// C Aeolian trasforms into G Mixolydian.
    /// C Locrian transforms into G Lydian.
    /// https://rcalsaverini.github.io/blog/modes-transform-negative-harmony/
    /// </summary>
    public class NegativeHarmonyMirror
    {

        public NoteName GetMirrored(KeySignature ks, NoteName nn)
        {
            var cof = new CircleOfFifths(ks.NoteName);
            var interval = ks.NoteName - nn;
            var ndx = cof.Notes.IndexOf(nn);

            var mirrorNdx = 1; //[0] = [1]
            if (ndx == 1)
                mirrorNdx = 0; //[1] = [0]
            else if (ndx > 1)
                mirrorNdx = (cof.Notes.Count + 1) - (ndx);

            mirrorNdx %= (cof.Notes.Count + 1);

            var result = cof.Notes[mirrorNdx];
            //Debug.WriteLine($"{nn.NameAscii}: {chordType.NameAscii}, {ndx}: {mirrorNdx}");
            //new object();

            return result;
        }

        [Obsolete("See how new impl of GetMirrored works.")]
        public ChordFormula xGetMirrored(KeySignature ks, ChordFormula formula)
        {
            ChordFormula result = null;
            var cof = new CircleOfFifths(ks.NoteName);

            var nns = new List<NoteName>();
            foreach (var nn in formula.NoteNames)
            {
                var ndx = cof.Notes.IndexOf(nn);

                var mirrorNdx = 1; //[0] = [1]
                if (ndx == 1)
                    mirrorNdx = 0; //[1] = [0]
                else if (ndx > 1)
                    mirrorNdx = (cof.Notes.Count + 1) - (ndx);

                mirrorNdx %= (cof.Notes.Count + 1);

                var nnMirror = cof.Notes[mirrorNdx];
                Debug.WriteLine($"{nn.NameAscii}: {nnMirror.NameAscii}, {ndx}: {mirrorNdx}");

                nns.Add(nnMirror);
                new object();
            }

            nns = nns.OrderByDescending(x => nns.IndexOf(x)).ToList();
            var append = nns[0];
            nns.Remove(append);
            nns.Add(append);

            return result;
        }

        void foo()
        {
#warning Is this correct? Why is he not mirroring the roots on the I chords?
#if false

1		I		im		
1		Imaj7		imb6		
1		I7		im6		
1		I+		V+ **		
1		im		I		
1		im7		I6		
b2		bII		viim		
b2		bIImaj7		viimb6		
b2		bII7		viim6		
b2		biim		VII		
b2		biim7		VII6		
2		II		bviim		
2		II7		bviim6		
2		iim		bVII		
2		iim7		bVII6		
2		iidim		viidim **		
2		iim7b5		V7 **		
b3		bIII		vim		
b3		bIIImaj7		vimb6		
b3		bIII7		vim6		
3		III		bvim		
3		III7		bvim6		
3		iiim		bVI		
3		iiim7		bVI6		
4		IV		vm		
4		IVmaj7		vmb6		
4		ivm		V		
4		ivm6		V7		
// #4/b5		#IV		bvm		
// #4/b5		#ivø7		bIII7 **		
5		V		ivm		
5		V7		ivm6		
5		vm		IV		
5		vm7		IV6		
b6		bVI		iiim		
b6		bVImaj7		iiimb6		
b6		bVI7		iiim6		
b6		bvim		III		
6		VI		biiim		
6		VI7		biiim6		
6		vim		bIII		
6		vim7		bIII6		
b7		bVII		iim		
b7		bVIImaj7		iimb6		
b7		bVII7		iim6		
7		VII		biim		
7		VII7		biim6		
7		viidim		iidim **		
7		viiø7		bVII7 **		
7		viidim7		viidim7 **		
#endif
        }

        public ChordFormula GetMirrored(KeySignature ks, ChordFormula formula)
        {
            var chordType = ChordIntervalsEnum.None;
            
            #region switch (formula.ChordType)
            switch (formula.ChordType)
            {
                case ChordIntervalsEnum.Major:
                    {
                        chordType = ChordIntervalsEnum.Minor;
                        break;
                    }
                case ChordIntervalsEnum.Major7:
                    {
                        chordType = ChordIntervalsEnum.Minor6;
                        break;
                    }
                case ChordIntervalsEnum.Dominant7:
                    {//1		I7		im6		
                        chordType = ChordIntervalsEnum.Minor6;
                        break;
                    }
                case ChordIntervalsEnum.Augmented:
                    { //V+
                        chordType = ChordIntervalsEnum.Augmented;
                        break;
                    }
                case ChordIntervalsEnum.Minor:
                    {
                        chordType = ChordIntervalsEnum.Major; break;
                    }
                case ChordIntervalsEnum.Minor7:
                    { //im7		I6		
                        chordType = ChordIntervalsEnum.Major6; break;
                    }
                case ChordIntervalsEnum.Major6:
                case ChordIntervalsEnum.Major9:
                case ChordIntervalsEnum.Major11:
                case ChordIntervalsEnum.Major13:
                case ChordIntervalsEnum.MajorMu:
                case ChordIntervalsEnum.Dominant7b9:
                case ChordIntervalsEnum.Dominant7Sharp9:
                case ChordIntervalsEnum.Dominant7b5:
                case ChordIntervalsEnum.Dominant7b5b9:
                case ChordIntervalsEnum.Dominant7b5Sharp9:
                case ChordIntervalsEnum.Dominant7Sharp5:
                case ChordIntervalsEnum.Dominant7Sharp5b9:
                case ChordIntervalsEnum.Dominant7Sharp5Nine:
                case ChordIntervalsEnum.Dominant9:
                case ChordIntervalsEnum.Dominant11:
                case ChordIntervalsEnum.DominantAug11:
                case ChordIntervalsEnum.Dominant11b9:
                case ChordIntervalsEnum.Dominant13:
                case ChordIntervalsEnum.Dominant13Aug11:
                case ChordIntervalsEnum.Dominant13b9:
                case ChordIntervalsEnum.Sus4:
                case ChordIntervalsEnum.Sus2:
                case ChordIntervalsEnum.Sus2Sus4:
                case ChordIntervalsEnum.Dominant7Sus2:
                case ChordIntervalsEnum.Dominant7Sus4:
                case ChordIntervalsEnum.Diminished:
                case ChordIntervalsEnum.HalfDiminished:
                case ChordIntervalsEnum.Diminished7:
                case ChordIntervalsEnum.Minor9:
                case ChordIntervalsEnum.Minor11:
                case ChordIntervalsEnum.Minor13:
                case ChordIntervalsEnum.Minor6:
                case ChordIntervalsEnum.Minor6Add9:
                case ChordIntervalsEnum.Minor7Sharp5:
                case ChordIntervalsEnum.MinorAdd9:
                case ChordIntervalsEnum.MinorMajor7:
                case ChordIntervalsEnum.MinorAugmented:
                case ChordIntervalsEnum.MinorMajor7Aug:
                case ChordIntervalsEnum.MinorMajor9:
                case ChordIntervalsEnum.Major13Aug11:
                case ChordIntervalsEnum.Major7Aug:
                case ChordIntervalsEnum.Major7b5:
                case ChordIntervalsEnum.Major9thSharp11:
                default:
                    {
                        throw new NotSupportedException();
                        break;
                    }

            }

            #endregion

            var mirrorRoot = this.GetMirrored(ks, formula.Root);
            var result = ChordFormula.Create(mirrorRoot, chordType);

            return result;
        }


    }//class

    /// <summary>
    /// Clockwise:
    /// C, G, D, A, E, B, Gb/F#, Db, Ab, Eb, Bb, F
    /// </summary>
    public class CircleOfFifths
    {
        public List<NoteName> Notes { get; set; } = new List<NoteName>();
        public CircleOfFifths(NoteName nn)
        {
            Notes.Add(nn);
            for (int i = 1; i < 12; ++i)
            {
                nn += Interval.Perfect5th;
                if (!nn.IsNatural)
                {
                    var enharmonic = NoteName.GetEnharmonicEquivalents(nn)
                        .OrderBy(ee => ee.AccidentalCount)
                        .First();
                    Notes.Add(enharmonic);
                }
                else
                    Notes.Add(nn);
            }
        }
    }//class

    public class CircleOfChromatics
    {
        public List<NoteName> Notes { get; set; } = new List<NoteName>();
        public CircleOfChromatics(KeySignature ks)
        {
            var formula = new ChromaticScaleFormula(ks);
            Notes.AddRange(formula.NoteNames);
        }
    }

}//ns
