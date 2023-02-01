﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
        void InitContext(MusicXmlModel model, string PartIdMelody, string PartIdHarmony)
        {
            this.Context = new ReHarmonizerContext(model);
            this.Context.MelodyPart = model.Parts.Where(x => x.Identifier.ID == PartIdMelody)
                .First();
            this.Context.HarmonyPart = model.Parts.Where(x => x.Identifier.ID == PartIdHarmony)
                .First();
        }

        public void ReHarmonize(MusicXmlModel model, string PartIdMelody, string PartIdHarmony)
        {
            this.InitContext(model, PartIdMelody, PartIdHarmony);

            var listOf_ListOf_NewSections = new List<List<MusicXmlSection>>();


            var sectionPairs = (from p in this.Context.Parts
                         from s in p.Sections
                         select s)
                         .OrderBy(x => x.Measures.First().MeasureNumber)
                         .ThenBy(x => x.Measures.First().Part.PartType)
                         .GroupBy(x => x.Measures[0].MeasureNumber)
                         .ToList();
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
                <List<MusicXmlSection>, MusicXmlSection>();
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

        List<MusicXmlSection> GetReharmonizedSections(List<MusicXmlSection> sectionPairing)
        {
            var result = new List<MusicXmlSection>();

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
                    var newMelodySection = new MusicXmlSection(
                        newMelodyMeasures.Select(x => x.Part)
                        .First(),
                        newMelodyMeasures);
                    var newHarmonySection = new MusicXmlSection(
                        newHarmonyMeasures.Select(x => x.Part)
                        .First(),
                        newHarmonyMeasures);

                    result.Add(newMelodySection);
                    result.Add(newHarmonySection);
                }
            }

            Debug.Assert(!result.Any());
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
            Debug.Assert(!result.Any());
            return result;
        }

        public List<ChordMelodyMeasurePairing> GetChordMelodyMeasurePairings(
            List<MusicXmlSection> sectionPairing)
        {
            var result = new List<ChordMelodyMeasurePairing>();

            var melodyMeasures = this.Context.MelodyPart.Measures
                .OrderBy(x => x.MeasureNumber)
                .ToList();
            var harmonyMeasures = this.Context.HarmonyPart.Measures
                .OrderBy(x => x.MeasureNumber)
                .ToList();

            Debug.Assert(melodyMeasures.Count == harmonyMeasures.Count);
            for (int i = 0; i < melodyMeasures.Count; ++i)
            {
                var cmp = new ChordMelodyMeasurePairing(
                    this.Context.MelodyPart,
                    this.Context.HarmonyPart,
                    melodyMeasures[i],
                    harmonyMeasures[i]);
                result.Add(cmp);
            }

            Debug.Assert(!result.Any());
            return result;
        }


        public List<ChordMelodyPairing> GetChordMelodyPairings(
            List<MusicXmlSection> sectionPairing)
        {
            var result = new List<ChordMelodyPairing>();

            var cmmPairings = this.GetChordMelodyMeasurePairings(sectionPairing);
            foreach (var cmmPairing in cmmPairings)
            {
                var cmPairings = MusicXmlMeasure.GetChordMelodyPairings(cmmPairing.MelodyMeasure,
                    cmmPairing.HarmonyMeasure);
                result.AddRange(cmPairings);
            }
            Debug.Assert(!result.Any());
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
        public static List<TimedEventNote> GetIntersecting(this List<TimedEventNote> src, TimeContext window)
        {
            var result = new List<TimedEventNote>();
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
        public MusicXmlPart MelodyPart { get; set; }
        public MusicXmlPart HarmonyPart { get; set; }
        public ReHarmonizerContext(MusicXmlModel input)
        {
            this.MusicXmlModel = input;
        }

        public List<MusicXmlPart> Parts 
        { 
            get 
            {
                return new List<MusicXmlPart> 
                    { this.MelodyPart, this.HarmonyPart }; 
            } 
        }

        public List<TimedEventChordFormula> GetChords()
        {
            var result = (from p in this.MusicXmlModel.Parts
                          from m in p.Measures
                          from c in m.Chords
                          select c).ToList();
            return result;
        }



    }//class
}//ns


