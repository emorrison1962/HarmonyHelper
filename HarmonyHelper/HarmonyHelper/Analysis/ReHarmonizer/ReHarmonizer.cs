using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Eric.Morrison.Collections.Generic;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;

using static System.Collections.Specialized.BitVector32;
using static Eric.Morrison.Harmony.MusicXml.TimeContext;

namespace Eric.Morrison.Harmony.Analysis.ReHarmonizer
{
    public class ReHarmonizer
    {
        ReHarmonizerContext Context { get; set; }
        public void ReHarmonize(MusicXmlModel model)
        {
            this.Context = new ReHarmonizerContext(model);

            var listOf_ListOf_NewSections = new List<List<SinglePartSection>>();


            var sectionPairs = (from p in model.Parts
                         from s in p.Sections
                         select s)
                         .OrderBy(x => x.Measures.First().MeasureNumber)
                         .ThenBy(x => x.Measures.First().Part.PartType)
                         .GroupBy(x => x.Measures[0].MeasureNumber);
            foreach (var grouping in sectionPairs)
            {
                var sectionPair = grouping.ToList();
                var reharmonizedSections = this.GetReharmonizedSections(sectionPair);
                listOf_ListOf_NewSections.Add(reharmonizedSections);
            }


            //foreach (var part in model.Parts)
            //{
            //    foreach (var section in part.Sections)
            //    {
            //        var reharmonizedSections = this.GetReharmonizedSections(section);
            //        listOf_ListOf_NewSections.Add(reharmonizedSections);
            //    }
            //}

            var multiQueue = new CircularMultiQueue
                <List<SinglePartSection>, SinglePartSection>();
            foreach (var newSection  in listOf_ListOf_NewSections)
            {
                multiQueue.Add(newSection, newSection);
            }

            Debug.WriteLine(multiQueue.Count);
            foreach (var sections in multiQueue)
            {
                foreach (var section in sections)
                {
                    //throw new NotImplementedException();
                    section.Part.AddRange(section.Measures);
                    //model.Add(section);
                    new object();
                }
            }

            new object();
        }

        List<SinglePartSection> GetReharmonizedSections(List<SinglePartSection> sectionPairing)
        {
            var result = new List<SinglePartSection>();

            var melodyPart = sectionPairing
                .First(x => x.Part.PartType == PartTypeEnum.Melody);
            var harmonyPart = sectionPairing
                .First(x => x.Part.PartType == PartTypeEnum.Harmony);

            var sectionCmmPairings = this.GetChordMelodyPairings(sectionPairing); 
            var substitutionResults = this.GetChordSubstitutionsAsync(sectionCmmPairings).Result;
            var cmmPairings = this.GetChordMelodyMeasurePairings(sectionPairing);


            var newSectionCount = substitutionResults.Count / cmmPairings.Count;
            newSectionCount += (substitutionResults.Count % cmmPairings.Count) > 0 ? 1 : 0;

            for (int i = 0; i < newSectionCount; ++i)
            {
                var newMelodyMeasures = new List<MusicXmlMeasure>();
                var newHarmonyMeasures = new List<MusicXmlMeasure>();
                foreach (var cmmPairing in cmmPairings)
                {
                    var newMelodyMeasure = new MusicXmlMeasure(cmmPairing.MelodyMeasure);
                    var newHarmonyMeasure = new MusicXmlMeasure(cmmPairing.HarmonyMeasure);

                    var cmPairings = MusicXmlMeasure.GetChordMelodyPairings(cmmPairing.MelodyMeasure,
                        cmmPairing.HarmonyMeasure);

                    foreach (var cmPairing in cmPairings)
                    {
                        if (null != cmPairing.Chord)
                        {
                            var substitution = substitutionResults[cmPairing];
                            foreach (var teChord in newHarmonyMeasure.Chords)
                            {// Make the substitution.
                                teChord.Event = substitution.Substitution;
                            }
                        }
                    }
                    newMelodyMeasures.Add(newMelodyMeasure);
                    newHarmonyMeasures.Add(newHarmonyMeasure);
                }//foreach (var cmmPairing in cmmPairings)

                if (newMelodyMeasures.Any() && newHarmonyMeasures.Any())
                {
                    var newMelodySection = new SinglePartSection(
                        newMelodyMeasures.Select(x => x.Part)
                        .First(),
                        newMelodyMeasures);
                    var newHarmonySection = new SinglePartSection(
                        newHarmonyMeasures.Select(x => x.Part)
                        .First(),
                        newHarmonyMeasures);

                    result.Add(newMelodySection);
                    result.Add(newHarmonySection);
                }
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

        public List<ChordMelodyMeasurePairing> GetChordMelodyMeasurePairings(
            List<SinglePartSection> sectionPairing)
        {
            var result = new List<ChordMelodyMeasurePairing>();

            var melodyPart = sectionPairing
                .First(x => x.Part.PartType == PartTypeEnum.Melody)
                .Part;
            var harmonyPart = sectionPairing
                .First(x => x.Part.PartType == PartTypeEnum.Harmony)
                .Part;

            var melodyMeasures = melodyPart.Measures
                .OrderBy(x => x.MeasureNumber)
                .ToList();
            var harmonyMeasures = harmonyPart.Measures
                .OrderBy(x => x.MeasureNumber)
                .ToList();

            Debug.Assert(melodyMeasures.Count == harmonyMeasures.Count);
            for (int i = 0; i < melodyMeasures.Count; ++i)
            {
                var cmp = new ChordMelodyMeasurePairing(
                    melodyPart,
                    harmonyPart,
                    melodyMeasures[i],
                    harmonyMeasures[i]);
                result.Add(cmp);
            }

            return result;
        }


        public List<ChordMelodyPairing> GetChordMelodyPairings(
            List<SinglePartSection> sectionPairing)
        {
            var result = new List<ChordMelodyPairing>();

            var cmmPairings = this.GetChordMelodyMeasurePairings(sectionPairing);
            foreach (var cmmPairing in cmmPairings)
            {
                var cmPairings = MusicXmlMeasure.GetChordMelodyPairings(cmmPairing.MelodyMeasure,
                    cmmPairing.HarmonyMeasure);
                result.AddRange(cmPairings);
            }
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
        public MusicXmlModel MusicXmlModel { get; set; }
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


