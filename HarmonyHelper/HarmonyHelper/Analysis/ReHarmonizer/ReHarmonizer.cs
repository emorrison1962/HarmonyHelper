using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;
using Kohoutech.Score.MusicXML;

namespace Eric.Morrison.Harmony.Analysis.ReHarmonizer
{
    public class ReHarmonizer
    {
        ReHarmonizerContext Context { get; set; }
        
        public void ReHarmonize(MusicXmlParsingResult input) 
        {
            this.Context = new ReHarmonizerContext(input);
            var pairings = new List<ChordMelodyPairing>();

            var chords = this.Context.GetChords();
            var measures = this.Context.GetMergedMeasures();
            foreach (var measure in measures) 
            {
                foreach (var chord in measure.Chords)
                {
                    //Debug.WriteLine(chord.ToString());
                    var notes = measure.Notes.GetIntersecting(chord.TimeContext);
                    var pairing = new ChordMelodyPairing(chord,
                        notes.ToList(),
                        chord.TimeContext);
                    pairings.Add(pairing);
                    new object();
                }
            }

            foreach (var pairing in pairings)
            {
                var substitutions = this.ReHarmonize(pairing);
            }

            new object();
        }

        private List<ChordFormula> ReHarmonize(ChordMelodyPairing pairing)
        {
            var ks2cfMap = new KeySignature2ChordFormulaMap();
            var cf2ksMap = new ChordFormula2KeySignatureMap();

            List<KeySignature> mappedKeys = cf2ksMap.GetKeys(pairing.Chord);
            Debug.WriteLine($"cf2ksMap {pairing.Chord.Event} contains:");
            foreach (var key in mappedKeys)
            {
                Debug.WriteLine($"\t{key}");
            }



            var notesStr = string.Join(",", pairing.Melody);

            var keys = KeySignature.Catalog
                .Where(x => x.IsDiatonic(pairing.Melody, out var blueNotes) >= IsDiatonicEnum.Partially)
                .OrderBy(x => x.NoteName)
                .ToList();

            var matchesSet = new HashSet<ChordFormula>();
            var formulas = ks2cfMap.GetChordFormulas(keys);
            //foreach (var key in keys)
            {
                //var formulas = ks2cfMap.GetChordFormulas(key);
                //var formulas = ChordFormulaCatalog.Formulas
                //    .Where(x => x.Key == key);
                foreach (var formula in formulas)
                {
                    if (formula.Contains(pairing.Melody, 
                        out var contained, 
                        out var notContained) >= ContainsEnum.Yes)
                    {
                        if (matchesSet.Add(formula))
                        {
                            Debug.WriteLine($"{formula} \t\tcontains: {string.Join(",", contained)}, does not contain: {string.Join(",", notContained)}, melody: {notesStr}");
                        }
                    }
                    else
                    {
                        //Debug.WriteLine($"**** {key}, NO FORMULA contains: {notesStr}");
                    }
                }
            }

            /*
            var matches = matchesSet.OrderBy(x => x).ToList();
            foreach (var match in matches)
            {
                Debug.WriteLine($"{match} \t\tcontains: {notesStr}");
            }


            if (keys.Count() == 0)
            {
                if (pairing.Melody.Count > 7)
                {
                    Debug.WriteLine($"******** Need to handle Blue Notes: {notesStr}!");
                    //Is it reliable to count on duration to identify blue notes?
                    // Add "Straight, No Chaser" as a test file.
                    new object();
                }
                else
                {//Need to handle Blue Notes!
                    Debug.WriteLine($"******** Need to handle Blue Notes: {notesStr}!");
                    new object();
                }
            }
            */

            Debug.WriteLine("====================================");
            return null;
        }
    }//class

    public static class TimedEventExtensions
    {
        public static List<TimedEvent<T>> GetIntersecting<T>(this List<TimedEvent<T>> src, TimeContext window) 
            where T : class, IComparable<T>
        {
            var result = new List<TimedEvent<T>>();
            foreach (var item in src)
            {
                if (item.TimeContext.Intersects(window))
                { 
                    result.Add(item);
                }
            }
            return result;
        }
    }

    public class ReHarmonizerContext
    {
        MusicXmlParsingResult MusicXmlParsingResult { get; set; }
        public ReHarmonizerContext(MusicXmlParsingResult input)
        {
            this.MusicXmlParsingResult = input;
        }

        public List<TimedEvent<ChordFormula>> GetChords() 
        {
            var result = (from p in this.MusicXmlParsingResult.Parts
                       from m in p.Measures
                       from c in m.Chords
                       select c).ToList();
            return result;
        }

        public List<MusicXmlMeasure> GetMergedMeasures()
        {
            var result = new List<MusicXmlMeasure>();
            var seq = (from p in this.MusicXmlParsingResult.Parts
                          from m in p.Measures
                          select m).ToList();
            
            var groupings = seq.GroupBy(x => x.MeasureNumber).ToList();
            foreach (var grouping in groupings)
            {
                var merged = MusicXmlMeasure.CreateMerged(grouping.ToList());
                result.Add(merged);
            }

            return result;
        }


    }//class
}//ns


