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
    public class KeySignature2ChordFormulaMap
    {
        public Dictionary<KeySignature, List<ChordFormula>> 
            KeySignatureToChordFormulaMaps { get; set; } 
                = new Dictionary<KeySignature, List<ChordFormula>>();

        public KeySignature2ChordFormulaMap()
        {
            foreach (var key in KeySignature.Catalog)
            {
                foreach (var formula in ChordFormulaCatalog.Formulas)
                {
                    if (IsDiatonicEnum.Yes == key.IsDiatonic(formula.NoteNames))
                    {
                        if (this.KeySignatureToChordFormulaMaps.TryGetValue(key, out var formulas))
                        {
                            formulas.Add(formula);
                        }
                        else
                        {
                            this.KeySignatureToChordFormulaMaps[key] = new List<ChordFormula>();
                            this.KeySignatureToChordFormulaMaps[key].Add(formula);
                        }
                    }
                }
            }


            //foreach (var dict in this.KeyToFormulaMaps)
            //{
            //    Debug.WriteLine($"K2FMap {dict.Key} contains:");
            //    foreach (var formula in dict.Value)
            //    {
            //        Debug.WriteLine($"\t{formula}");
            //    }
            //}

            new object();
        }

        public List<ChordFormula> GetChordFormulas(KeySignature key)
        {
            var result = this.KeySignatureToChordFormulaMaps[key]
                .OrderBy(x => x.Root)
                .ThenBy(x => x.NoteNames.Count)
                .ToList();
            return result;
        }

        public List<ChordFormula> GetChordFormulas(List<KeySignature> keys)
        {
            var set = new HashSet<ChordFormula>();
            foreach (var key in keys)
            {
                this.KeySignatureToChordFormulaMaps[key]
                    .ForEach(x => set.Add(x));
            }
            
            var result = set.OrderBy(x => x.Root)
                .ThenBy(x => x.NoteNames.Count)
                .ToList();
            return result;
        }
    }//class
}//ns
