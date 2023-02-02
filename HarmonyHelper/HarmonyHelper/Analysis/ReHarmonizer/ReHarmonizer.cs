using System;
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
        public MusicXmlPart MelodyPart { get; set; }
        public MusicXmlPart HarmonyPart { get; set; }

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

        #endregion
        
        void Init(MusicXmlModel model, string PartIdMelody, string PartIdHarmony)
        {
            this.MelodyPart = model.Parts.Where(x => x.Identifier.ID == PartIdMelody)
                .First();
            this.HarmonyPart = model.Parts.Where(x => x.Identifier.ID == PartIdHarmony)
                .First();
        }

        
        class SectionPairings : IEnumerable<MelodyHarmonyPair<MusicXmlSection>>
        { 
            public List<MusicXmlSection> MelodySections 
            { get { return this.MelodyPart.Sections; } }
            public List<MusicXmlSection> HarmonySections
            { get { return this.HarmonyPart.Sections; } }

            public MusicXmlPart MelodyPart { get; set; }
            public MusicXmlPart HarmonyPart { get; set; }

            public SectionPairings(MusicXmlPart melodyPart, MusicXmlPart harmonyPart)
            {
                this.MelodyPart = melodyPart;
                this.HarmonyPart = harmonyPart;
            }

            public IEnumerator<MelodyHarmonyPair<MusicXmlSection>> GetEnumerator()
            {
                MelodyHarmonyPair<MusicXmlSection> result = null;
                for (var i = 0; i < this.MelodySections.Count; ++i)
                {
                    var mSect = this.MelodySections[i];
                    var hSect = this.HarmonySections[i];
                    result = new MelodyHarmonyPair<MusicXmlSection>(mSect, hSect);
                    yield return result;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }


            //public IEnumerable<MelodyHarmonyPair<MusicXmlSection>> GetEnumerator()
            //{
            //    MelodyHarmonyPair<MusicXmlSection> result = null;
            //    for (var i = 0; i < this.MelodySections.Count; ++i)
            //    {
            //        var mSect = this.MelodySections[i];
            //        var hSect = this.HarmonySections[i];
            //        result = new MelodyHarmonyPair<MusicXmlSection>(mSect, hSect);
            //        yield return result;
            //    }
            //}

        }//class

        public void ReHarmonize(MusicXmlModel model, string PartIdMelody, string PartIdHarmony)
        {
            this.Init(model, PartIdMelody, PartIdHarmony);

            var sectionPairs = new SectionPairings(
                this.MelodyPart, this.HarmonyPart);

            var newSections = new List<MelodyHarmonyPair<MusicXmlSection>>();
            
            foreach (var sectionPair in sectionPairs)
            {
                var reharmonizedSections = this.GetReharmonizedSections(sectionPair);
                newSections.AddRange(reharmonizedSections);
            }

            var multiQueue = new CircularMultiQueue
                <string, MelodyHarmonyPair<MusicXmlSection>>();
            foreach (var newSection in newSections)
            {
                var key = newSection.Melody.Part.Sections.IndexOf(newSection.Melody).ToString();
                multiQueue.Add(key, newSections);
            }

            //var xmultiQueue = new CircularMultiQueue
            //    <List<MusicXmlSection>, MusicXmlSection>();
            //foreach (var newSection  in newSections)
            //{
            //    multiQueue.Add(newSection, newSection.Harmony);
            //}

            Debug.WriteLine(multiQueue.Count);
            foreach (var pairs in multiQueue)
            {
                foreach (var pair in pairs)
                {
                    //throw new NotImplementedException();
                    pair.Melody.Part.AddRange(pair.Melody.Measures);
                    pair.Harmony.Part.AddRange(pair.Harmony.Measures);
                    //model.Add(section);
                    new object();
                }
            }

            new object();
        }

        List<MelodyHarmonyPair<MusicXmlSection>> GetReharmonizedSections(MelodyHarmonyPair<MusicXmlSection> sectionPairing)
        {
            var result = new List<MelodyHarmonyPair<MusicXmlSection>>();

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
                    var newMelodyMeasure = new MusicXmlMeasure(cmmPairing.Melody);
                    var newHarmonyMeasure = new MusicXmlMeasure(cmmPairing.Harmony);

                    var cmPairings = MusicXmlMeasure.
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
                    var newMelodySection = new MusicXmlSection(
                        newMelodyMeasures.Select(x => x.Part)
                        .First(),
                        newMelodyMeasures);
                    var newHarmonySection = new MusicXmlSection(
                        newHarmonyMeasures.Select(x => x.Part)
                        .First(),
                        newHarmonyMeasures);

                    result.Add(new MelodyHarmonyPair<MusicXmlSection>(
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

            foreach (var substitution in result)
            {
                //Debug.WriteLine($"{substitution}");
            }

            //Debug.WriteLine($"====================================");
            Debug.Assert(result.Any());
            return result;
        }

        [Obsolete("Get rid of this. Encapsulate in a workflow class.")]
        public List<MelodyHarmonyPair<MusicXmlMeasure>> GetChordMelodyMeasurePairings(
            MelodyHarmonyPair<MusicXmlSection> sectionPairing)
        {
            var result = new List<MelodyHarmonyPair<MusicXmlMeasure>>();

            var melodyMeasures = sectionPairing.Melody.Measures
                .OrderBy(x => x.MeasureNumber)
                .ToList();
            var harmonyMeasures = sectionPairing.Harmony.Measures
                .OrderBy(x => x.MeasureNumber)
                .ToList();

            Debug.Assert(melodyMeasures.Count == harmonyMeasures.Count);
            for (int i = 0; i < melodyMeasures.Count; ++i)
            {
                var cmp = new MelodyHarmonyPair<MusicXmlMeasure>(
                    melodyMeasures[i],
                    harmonyMeasures[i]);
                result.Add(cmp);
            }

            Debug.Assert(result.Any());
            return result;
        }

        class Pairings 
        { 
            MusicXmlPart MelodyPart { get; set; }
            MusicXmlPart HarmonyPart { get; set; }
        }
        public List<ChordMelodyPairing> GetChordMelodyPairings(
            MelodyHarmonyPair<MusicXmlSection> sectionPairing)
        {
            var result = new List<ChordMelodyPairing>();

            var cmmPairings = this.GetChordMelodyMeasurePairings(sectionPairing);
            foreach (var cmmPairing in cmmPairings)
            {
                var cmPairings = MusicXmlMeasure.GetChordMelodyPairings(cmmPairing);
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

    [Obsolete("", true)]
    public class ReHarmonizerContext
    {



    }//class
}//ns


