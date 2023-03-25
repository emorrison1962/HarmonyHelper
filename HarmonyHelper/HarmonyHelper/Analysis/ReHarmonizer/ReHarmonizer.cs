﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
        #region Properties
        public MusicXmlModel MusicXmlModel { get; set; }
        public Part MelodyPart { get; set; }
        public Part HarmonyPart { get; set; }

        public List<Part> Parts
        {
            get
            {
                return new List<Part>
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

        #endregion

        void Init(MusicXmlModel model, string PartIdMelody, string PartIdHarmony)
        {
            this.MelodyPart = model.Parts.Where(x => x.Identifier.ID == PartIdMelody)
                .First();
            this.HarmonyPart = model.Parts.Where(x => x.Identifier.ID == PartIdHarmony)
                .First();
        }


        class SectionPairings : IEnumerable<MelodyHarmonyPair<MusicXml.Section>>
        {
            public List<MusicXml.Section> MelodySections
            { get { return this.MelodyPart.Sections; } }
            public List<MusicXml.Section> HarmonySections
            { get { return this.HarmonyPart.Sections; } }

            public Part MelodyPart { get; set; }
            public Part HarmonyPart { get; set; }

            public SectionPairings(Part melodyPart, Part harmonyPart)
            {
                this.MelodyPart = melodyPart;
                this.HarmonyPart = harmonyPart;
            }

            public IEnumerator<MelodyHarmonyPair<MusicXml.Section>> GetEnumerator()
            {
                MelodyHarmonyPair<MusicXml.Section> result = null;
                for (var i = 0; i < this.MelodySections.Count; ++i)
                {
                    var mSect = this.MelodySections[i];
                    var hSect = this.HarmonySections[i];
                    result = new MelodyHarmonyPair<MusicXml.Section>(mSect, hSect);
                    yield return result;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }//class

        public void ReHarmonize(MusicXmlModel model, string PartIdMelody, string PartIdHarmony)
        {
            this.Init(model, PartIdMelody, PartIdHarmony);

            var sectionPairs = new SectionPairings(
                this.MelodyPart, this.HarmonyPart);

            var multiQueue = new CircularMultiQueue
                <string, MelodyHarmonyPair<MusicXml.Section>>();
            foreach (var sectionPair in sectionPairs)
            {
                var reharmonizedSections = this.GetReharmonizedSections(sectionPair);
                multiQueue.Add(sectionPair.Melody.Name, reharmonizedSections);
            }


            Debug.WriteLine(multiQueue.Count);
            var list = multiQueue.ToList();
            var grouping = list.GroupBy(x => x.Harmony.Name);
            var groupings = grouping.ToList();

            foreach (var mhPairing in multiQueue)
            {
                //throw new NotImplementedException();
                mhPairing.Melody.Part.Add(mhPairing.Melody);
                if (mhPairing.Melody.Part != mhPairing.Harmony.Part)
                {
                    mhPairing.Harmony.Part.Add(mhPairing.Harmony);
                }
                //model.Add(section);
                new object();
            }

            new object();
        }

        List<MelodyHarmonyPair<MusicXml.Section>> GetReharmonizedSections(MelodyHarmonyPair<MusicXml.Section> sectionPairing)
        {
            var result = new List<MelodyHarmonyPair<MusicXml.Section>>();

            var sectionCmmPairings = this.GetChordMelodyPairings(sectionPairing);
            var substitutionResults = this.GetChordSubstitutionsAsync(sectionCmmPairings).Result;
            var cmmPairings = this.GetChordMelodyMeasurePairings(sectionPairing);

            for (int i = 0; i < substitutionResults.Count; i++)
            {
                var substitutions = substitutionResults.Substitutions;
                foreach (var substitution in substitutions)
                {
                    new object();
                }
            }

            var newSectionCount = substitutionResults.Count / cmmPairings.Count;
            newSectionCount += (substitutionResults.Count % cmmPairings.Count) > 0 ? 1 : 0;

            for (int i = 0; i < newSectionCount; ++i)
            {
                var newMelodyMeasures = new MeasureList();
                var newHarmonyMeasures = new MeasureList();
                foreach (var cmmPairing in cmmPairings)
                {
                    Measure newMelodyMeasure = null;
                    Measure newHarmonyMeasure = null;
                    if (cmmPairing.Melody != cmmPairing.Harmony)
                    {
                        newMelodyMeasure = new Measure(cmmPairing.Melody);
                        newHarmonyMeasure = new Measure(cmmPairing.Harmony);
                    }
                    else
                    {
                        newMelodyMeasure = new Measure(cmmPairing.Melody);
                        newHarmonyMeasure = newMelodyMeasure;
                    }

                    var cmPairings = Measure.
                        GetChordMelodyPairings(cmmPairing);

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
                    var cmmPairing = cmmPairings[0];

                    var newMelodySection = new MusicXml.Section(
                        sectionPairing.Melody.Name,
                        newMelodyMeasures.Select(x => x.Part)
                            .First(),
                        newMelodyMeasures);
                    MusicXml.Section newHarmonySection = null;
                    if (cmmPairing.Melody != cmmPairing.Harmony)
                    {
                        newHarmonySection = new MusicXml.Section(
                            sectionPairing.Harmony.Name,
                            newHarmonyMeasures.Select(x => x.Part)
                                .First(),   
                            newHarmonyMeasures);
                    }
                    else
                    {
                        newHarmonySection = newMelodySection;
                    }
                    result.Add(new MelodyHarmonyPair<MusicXml.Section>(
                        newMelodySection, newHarmonySection));
                }
            }

            Debug.Assert(result.Any());
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

        async Task<List<ChordSubstitution>> GetChordSubstitutionsAsync(ChordMelodyPairing pairing)
        {
            var notesStr = string.Join(",", pairing.Melody);

            uint melodyBitMask = 0;
            pairing.Melody.ForEach(x => melodyBitMask |= x.RawValue);
            var formulas = new List<ChordFormula>();
            foreach (var cf in ChordFormula.Catalog.Where(x => !x.UsesSharps))
            {
                if (melodyBitMask == (cf.RawValue & melodyBitMask))
                {
                    formulas.Add(cf);
                }
            }
            formulas = formulas.Except(formulas, new FilterSubsumersComparer())
                .ToList();
            formulas = formulas.Where(x => x.NoteNames.Count >= 4).ToList();

#if false
            var keys = new List<KeySignature>();
            await Task.Run(() =>
            {
                keys = KeySignature.Catalog
                    .Where(x => x.IsDiatonic(pairing.Melody, out var blueNotes) == IsDiatonicEnum.Partially)
                    .Distinct()
                    .OrderBy(x => x.NoteName)
                    .ToList();
            });

            var matchesSet = new HashSet<ChordFormula>();
            var formulas = KeySignature2ChordFormulaMap.GetChordFormulas(keys);

            formulas = formulas.Except(formulas, new FilterSubsumersComparer())
                .ToList();
            formulas = formulas.Where(x => x.NoteNames.Count >= 4).ToList();

            var result = new Queue<ChordSubstitution>();
            foreach (var formula in formulas)
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
#endif

            var result = new List<ChordSubstitution>();
            foreach (var formula in formulas)
            {
                result.Add(
                    new ChordSubstitution(pairing.Chord.Event,
                    formula,
                    pairing.TimeContext));
            }



            foreach (var substitution in result)
            {
                //Debug.WriteLine($"{substitution}");
            }

            //Debug.WriteLine($"====================================");
            if (pairing.Melody.Count > 0)
                Debug.Assert(result.Any());
            return result;
        }

        [Obsolete("Get rid of this. Encapsulate in a workflow class.")]
        public List<MelodyHarmonyPair<Measure>> GetChordMelodyMeasurePairings(
            MelodyHarmonyPair<MusicXml.Section> sectionPairing)
        {
            var result = new List<MelodyHarmonyPair<Measure>>();

            var melodyMeasures = sectionPairing.Melody.Measures
                .OrderBy(x => x.MeasureNumber)
                .ToList();
            var harmonyMeasures = sectionPairing.Harmony.Measures
                .OrderBy(x => x.MeasureNumber)
                .ToList();

            Debug.Assert(melodyMeasures.Count == harmonyMeasures.Count);
            for (int i = 0; i < melodyMeasures.Count; ++i)
            {
                var cmp = new MelodyHarmonyPair<Measure>(
                    melodyMeasures[i],
                    harmonyMeasures[i]);
                result.Add(cmp);
            }

            Debug.Assert(result.Any());
            return result;
        }

        class Pairings
        {
            Part MelodyPart { get; set; }
            Part HarmonyPart { get; set; }
        }
        public List<ChordMelodyPairing> GetChordMelodyPairings(
            MelodyHarmonyPair<MusicXml.Section> sectionPairing)
        {
            var result = new List<ChordMelodyPairing>();

            var cmmPairings = this.GetChordMelodyMeasurePairings(sectionPairing);
            foreach (var cmmPairing in cmmPairings)
            {
                var cmPairings = Measure.GetChordMelodyPairings(cmmPairing);
                result.AddRange(cmPairings);
            }
            Debug.Assert(result.Any());
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

}//ns


