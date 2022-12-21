using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;

namespace Eric.Morrison.Harmony
{
    static public class ChordFormula2KeySignatureMap
    {
        static public Dictionary<ChordFormula, List<KeySignature>>
            ChordFormulaToKeySignatureMaps { get; set; }
                = new Dictionary<ChordFormula, List<KeySignature>>();


        static ChordFormula2KeySignatureMap()
        {
            foreach (var key in KeySignature.Catalog)
            {
                foreach (var formula in ChordFormula.Catalog)
                {
                    if (key.IsDiatonic(formula.NoteNames) >= IsDiatonicEnum.Partially)
                    {
                        if (ChordFormulaToKeySignatureMaps.TryGetValue(formula, out var dict))
                        {
                            dict.Add(key);
                        }
                        else
                        {
                            ChordFormulaToKeySignatureMaps[formula] = new List<KeySignature>();
                            ChordFormulaToKeySignatureMaps[formula].Add(key);
                        }
                    }
                }
            }

            new object();
        }

        static public List<KeySignature> GetKeys(TimedEvent<ChordFormula> chord)
        {
            return GetKeys(chord.Event);
        }

        static public List<KeySignature> GetKeys(ChordFormula formula)
        {
            var result = new List<KeySignature>();
            if (ChordFormulaToKeySignatureMaps.ContainsKey(formula))
            {
                result = ChordFormulaToKeySignatureMaps[formula]?
                    .OrderBy(x => x.IsMinor)
                    .ThenBy(x => x.NoteName)
                    .ToList();
            }
            //Debug.Assert(result.Count > 0);
            if (result.Count == 0)
            {
                Debug.WriteLine(formula);
            }
            return result;
        }

    }//class
}//ns
