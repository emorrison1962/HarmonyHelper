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
    public class ChordFormula2KeySignatureMap
    {
        public Dictionary<ChordFormula, List<KeySignature>>
            ChordFormulaToKeySignatureMaps { get; set; }
                = new Dictionary<ChordFormula, List<KeySignature>>();


        public ChordFormula2KeySignatureMap()
        {
            foreach (var key in KeySignature.Catalog)
            {
                foreach (var formula in ChordFormulaCatalog.Formulas)
                {
                    if (IsDiatonicEnum.Yes == key.IsDiatonic(formula.NoteNames))
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
            var result = this.ChordFormulaToKeySignatureMaps[chord.Event]
                .OrderBy(x => x.NoteName)
                .ToList();
            return result;
        }
    }//class

}//ns
