using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;
using Kohoutech.Score;
using static System.Collections.Specialized.BitVector32;

namespace Eric.Morrison.Harmony.Analysis.ReHarmonizer
{
    public class ReHarmonizer
    {
        ReHarmonizerContext Context { get; set; }

        public void ReHarmonize(MusicXmlModel model)
        {
            this.Context = new ReHarmonizerContext(model);

            foreach (var section in model.Sections)
            {
                var reharmonizedSection = GetReharmonized(section);
            }

            new object();
        }

        List<MusicXmlSection> GetReharmonized(MusicXmlSection section)
        {
            var result = new List<MusicXmlSection>();

            var pairings = section.GetChordMelodyPairings();
            var substitutionResults = this.GetChordSubstitutionsAsync(pairings).Result;
            var used = new HashSet<ChordSubstitution>();
            var measures = section.GetMergedMeasures();
            var measureNumber = measures.Max(x => x.MeasureNumber) + 1;

            var newMeasures = new List<MusicXmlMeasure>();

            for (int i = 0; i < substitutionResults.Count; ++i)
            {
                var newSection = new ReHarmonizedMusicXmlSection();

                foreach (var part in section.Parts)
                {
                    var newPart = MusicXmlPart.CloneShallow(part);
                    newSection.Parts.Add(newPart);
                    foreach (var measure in measures)
                    {
                        foreach (var pairing in measure.ChordMelodyPairings)
                        {
                            if (measure.Chords.Any())
                            {
                                // create a new measure here.
                                var newMeasure = MusicXmlMeasure.CopyWithOffset(measure, measureNumber);

                                var substitution = substitutionResults[pairing];
                                foreach (var teChord in newMeasure.Chords)
                                {
                                    teChord.Event = substitution.Substitution;
                                }
                                
                                newMeasures.Add(newMeasure);
                                used.Add(substitution);
                                new object();

                                new object();
                            }
                        }//foreach (var pairing in pairings)
                        new object();
                        newPart.Measures.AddRange(newMeasures);
                    }//foreach (var measure in measures)
                    Debug.Assert(newMeasures.Count == 16);

                    newSection.Parts.Add(newPart);
                }
                result.Add(newSection);
            }

            return result;
        }

        async Task<ChordSubstitutionResults> GetChordSubstitutionsAsync(List<ChordMelodyPairing> pairings)
        {
            var result = new ChordSubstitutionResults();
            var distinct = pairings.Distinct().ToList();
            foreach (var pairing in distinct)
            {
                var substitutions = await this.GetChordSubstitutionsAsync(pairing);
                result.Add(pairing, substitutions);
                //Debug.WriteLine(pairing);
                new object();
            }
            foreach (var item in result.Substitutions)
            {//Prime the pump.
                item.Value.GetEnumerator().MoveNext();
            }

            return result;
        }

        async Task<Queue<ChordSubstitution>> GetChordSubstitutionsAsync(ChordMelodyPairing pairing)
        {
            List<KeySignature> pertinentKeys = ChordFormula2KeySignatureMap.GetKeys(pairing.Chord);
            //Debug.WriteLine($"cf2ksMap {pairing.Chord.Event} contains:");
            foreach (var key in pertinentKeys)
            {
                //Debug.WriteLine($"\t{key}");
            }

            var notesStr = string.Join(",", pairing.Melody);

            var keys = new List<KeySignature>();
            await Task.Run(() =>
            {
                keys = KeySignature.Catalog
                .Where(x => x.IsDiatonic(pairing.Melody, out var blueNotes) >= IsDiatonicEnum.Partially)
                .Distinct()
                .OrderBy(x => x.NoteName)
                .ToList();
            });

            var matchesSet = new HashSet<ChordFormula>();
            var formulas = KeySignature2ChordFormulaMap.GetChordFormulas(keys);

            formulas = formulas.Except(formulas, new FilterSubsumersComparer())
                .ToList();


            var result = new Queue<ChordSubstitution>();
            foreach (var formula in formulas.Where(x => x.NoteNames.Count >= 4))
            {
                if (formula.Contains(pairing.Melody,
                    out var contained,
                    out var notContained) >= ChordFormulaContainsEnum.Partially)
                {
                    if (matchesSet.Add(formula))
                    {
                        result.Enqueue(
                            new ChordSubstitution(pairing.Chord.Event,
                            formula,
                            pairing.TimeContext));
                    }
                }
            }

            foreach (var substitution in result)
            {
                //Debug.WriteLine($"{substitution}");
            }

            //Debug.WriteLine($"====================================");
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
            where T : class, IMusicalEvent<T>, IComparable<T>, new()
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
        MusicXmlModel MusicXmlModel { get; set; }
        public ReHarmonizerContext(MusicXmlModel input)
        {
            this.MusicXmlModel = input;
        }

        public List<TimedEvent<ChordFormula>> GetChords()
        {
            var result = (from p in this.MusicXmlModel.Parts
                          from m in p.Measures
                          from c in m.Chords
                          select c).ToList();
            return result;
        }



    }//class
}//ns


