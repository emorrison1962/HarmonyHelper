using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace Eric.Morrison.Harmony.Tests
{
    [TestClass()]
    public class ScaleTests
    {
        [TestMethod()]
        public void ScaleTest()
        {
            Assert.Fail();
        }

        public class AlphaNoteNameComparer : IComparer<NoteName>
        {
            public int Compare(NoteName x, NoteName y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        class NoteNameListValueComparer : IEqualityComparer<List<NoteName>>
        {
            public bool Equals(List<NoteName> x, List<NoteName> y)
            {
                var result = true;
                foreach (var nn in x)
                {
                    if (!y.Contains(nn))
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }

            public int GetHashCode(List<NoteName> obj)
            {
                var result = 0;
                foreach (var nn in obj)
                {
                    result ^= nn.Value.GetHashCode();
                }
                return result;
            }

            public int GetHashCode(NoteName obj)
            {
                return obj.Value.GetHashCode();
            }
        }

        [TestMethod()]
        public void todoTest()
        {

#warning *** "TODO" ***

            //var chord = ChordFormula.Bb7;
            var chord = new ChordFormula(NoteName.Bb, ChordTypesEnum.Minor7th, KeySignature.EbMajor);

            Debug.WriteLine("Scales containing the chord tones from: " + chord.Name.ToString());
            Debug.Indent();

            var reported = new List<List<NoteName>>();

            var thesaurus = new ScaleFormulaCatalog();
            foreach (var scale in thesaurus.Formulas)
            {
                if (scale.Key.NoteName == NoteName.Bb)
                    new object();
                var hasChord = scale.Contains(chord.NoteNames);
                if (hasChord)
                {
                    new object();
                }

                if (hasChord) //implies implicit IEnumerable<NoteName> conversion operator!!!
                {
                    //Debug.Write(scale.Name.ToString());

                    var copy = new List<NoteName>(scale.NoteNames);
                    copy.Sort(new AlphaNoteNameComparer());

#warning *** Okay, got rid of enharmonic equivelents. But now I need to select WHICH enharmonic equivelent I want to use. ***

                    //if (!reported.Contains(copy, new NoteNameListValueComparer()))
                    if (true)
                    {
                        reported.Add(copy);

                        Debug.Write(string.Format("{0} ", scale.Key.NoteName));
                        Debug.Write(scale.ToString());
                        //Debug.Write(" contains: ");
                        //Debug.Write(Bb7.Name.ToString());
                        Debug.WriteLine("");
                    }
                    else
                    {
                    }

                }
            }
            Debug.Unindent();

            new object();

#if false
Scales containing the chord tones from: B♭Minor7th
Scales containing the chord tones from: B♭Minor7th
    C Phrygian: C,D♭,E♭,F,G,A♭,B♭
    C Locrian: C,D♭,E♭,F,G♭,A♭,B♭
    G DiminishedHalfWholeFormula: G,A♭,B♭,B,D♭,D,E,F
    B Lydian: B,C♯,D♯,F,F♯,G♯,A♯
    F HarmonicMinorFormula: F,G,A♭,B♭,C,D♭,E
    B♭ PentatonicMinorFormula: B♭,D♭,E♭,F,A♭



#endif

        }


    }//class
}//ns