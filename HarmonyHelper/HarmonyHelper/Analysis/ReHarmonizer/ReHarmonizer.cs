using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;

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

        private List<ChordSubstitution> ReHarmonize(ChordMelodyPairing pairing)
        {
            List<KeySignature> mappedKeys = ChordFormula2KeySignatureMap.GetKeys(pairing.Chord);
            Debug.WriteLine($"cf2ksMap {pairing.Chord.Event} contains:");
            foreach (var key in mappedKeys)
            {
                Debug.WriteLine($"\t{key}");
            }

            var notesStr = string.Join(",", pairing.Melody);

            
            var keys = KeySignature.Catalog
                .Where(x => x.IsDiatonic(pairing.Melody, out var blueNotes) >= IsDiatonicEnum.Partially)
                .Distinct()
                .OrderBy(x => x.NoteName)
                .ToList();

            var matchesSet = new HashSet<ChordFormula>();
            var formulas = KeySignature2ChordFormulaMap.GetChordFormulas(keys);

            formulas = formulas.Except(formulas, new FilterSubsumersComparer())
                .ToList();


            var result = new List<ChordSubstitution>();
            foreach (var formula in formulas.Where(x => x.NoteNames.Count >= 4))
            {
                if (formula.Contains(pairing.Melody,
                    out var contained,
                    out var notContained) >= ContainsEnum.Partially)
                {
                    if (matchesSet.Add(formula))
                    {
                        result.Add(
                            new ChordSubstitution(pairing.Chord.Event, 
                            formula, 
                            pairing.TimeContext));
                    }
                }
            }

            foreach (var substitution in result)
            {
                Debug.WriteLine($"{substitution}");
            }

            Debug.WriteLine($"====================================");
            return result;
        }


    }//class

    public class FilterSubsumersComparer : IEqualityComparer<ChordFormula>
    {
        public bool Equals(ChordFormula x, ChordFormula y)
        {
            var result = false;
            if (!x.Equals(y))
            {
                if (x.IsSubsumedBy(y))
                    result = true;
            }
            return result;
        }

        public int GetHashCode(ChordFormula obj)
        {
            return 0;
        }
    }


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


