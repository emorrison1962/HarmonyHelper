using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;

namespace Eric.Morrison.Harmony
{
    public class ChordFormula2KeySignatureMap
    {
        public Dictionary<ChordFormula, List<KeySignature>>
            ChordFormulaToKeySignatureMaps
        { get; set; }
                = new Dictionary<ChordFormula, List<KeySignature>>();


        public ChordFormula2KeySignatureMap()
        {
            foreach (var key in KeySignature.Catalog)
            {
                foreach (var formula in ChordFormulaCatalog.Formulas)
                {
                    if (IsDiatonicEnum.Partially <= key.IsDiatonic(formula.NoteNames))
                    {
                        if (this.ChordFormulaToKeySignatureMaps.TryGetValue(formula, out var dict))
                        {
                            dict.Add(key);
                        }
                        else
                        {
                            this.ChordFormulaToKeySignatureMaps[formula] = new List<KeySignature>();
                            this.ChordFormulaToKeySignatureMaps[formula].Add(key);
                        }
                    }
                }
            }

            //foreach (var dict in this.FormulaToKeyMaps)
            //{
            //    Debug.WriteLine($"F2KMap {dict.Key} contains:");
            //    foreach (var key in dict.Value)
            //    {
            //        Debug.WriteLine($"\t{key}");
            //    }
            //}

            new object();
        }

        public List<KeySignature> GetKeys(TimedEvent<ChordFormula> chord)
        {
            var result = new List<KeySignature>();
            if (this.ChordFormulaToKeySignatureMaps.ContainsKey(chord.Event))
            {
                result = this.ChordFormulaToKeySignatureMaps[chord.Event]?
                    .OrderBy(x => x.NoteName)
                    .ToList();
            }
            return result;
        }
    }//class
}//ns
