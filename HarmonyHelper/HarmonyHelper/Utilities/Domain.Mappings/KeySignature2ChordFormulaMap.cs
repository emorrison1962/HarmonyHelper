using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    static public class KeySignature2ChordFormulaMap
    {
        static public Dictionary<KeySignature, List<ChordFormula>> 
            KeySignatureToChordFormulaMaps { get; set; } 
                = new Dictionary<KeySignature, List<ChordFormula>>();

        static KeySignature2ChordFormulaMap()
        {
            foreach (var key in KeySignature.Catalog)
            {
                foreach (var formula in ChordFormula.Catalog)
                {
                    if (IsDiatonicEnum.Yes == key.IsDiatonic(formula.NoteNames))
                    {
                        if (KeySignatureToChordFormulaMaps.TryGetValue(key, out var formulas))
                        {
                            formulas.Add(formula);
                        }
                        else
                        {
                            KeySignatureToChordFormulaMaps[key] = new List<ChordFormula>();
                            KeySignatureToChordFormulaMaps[key].Add(formula);
                        }
                    }
                }
            }
            new object();
        }

        static public List<ChordFormula> GetChordFormulas(KeySignature key)
        {
            var result = KeySignatureToChordFormulaMaps[key]
                .OrderBy(x => x.Root)
                .ThenBy(x => x.NoteNames.Count)
                .ToList();
            return result;
        }

        static public List<ChordFormula> GetChordFormulas(List<KeySignature> keys)
        {
            var set = new HashSet<ChordFormula>();
            foreach (var key in keys)
            {
                KeySignatureToChordFormulaMaps[key]
                    .ForEach(x => set.Add(x));
            }
            
            var result = set.OrderBy(x => x.Root)
                .ThenBy(x => x.NoteNames.Count)
                .ToList();
            return result;
        }
    }//class
}//ns
