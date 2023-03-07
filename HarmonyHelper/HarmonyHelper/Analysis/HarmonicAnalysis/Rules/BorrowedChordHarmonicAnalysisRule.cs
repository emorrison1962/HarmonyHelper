using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;

using Newtonsoft.Json;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
    public class BorrowedChordHarmonicAnalysisRule : HarmonicAnalysisRuleBase
    {
        public override string Name { get { return "Modal Interchange"; } }
        public override string Description { get { return @"Borrowed chords are chords from a key that's parallel to your song's key signature. So if you're writing in a major key, you could use a chord from its parallel minor. These non-diatonic chords can spruce up a predictable chord progression. Borrowed chords don't appear naturally in a particular song's key."; } }

        List<int> _scaleDegreeNdxs = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
        List<ModeEnum> _modes = Enum.GetValues(typeof(ModeEnum)).Cast<ModeEnum>().ToList();
        public BorrowedChordHarmonicAnalysisRule()
        {

        }

        public override List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords)
        {
            var result = new List<HarmonicAnalysisResult>();
            //using (new TimedLogger(MethodBase.GetCurrentMethod().Name))
            {
                var key = KeySignature.DetermineKey(chords);
                var grids = this.CreateGrids(key);

                var formulas = chords.Select(x => x).Distinct().ToList();
                var nonDiatonic = key.GetNonDiatonic(formulas)
                    .Where(x => !x.IsDominantOfKey(key));
                new object();

                var dict = this.PopulateGrids(key, grids, nonDiatonic);

                foreach (var chord in chords)
                {
                    if (dict.ContainsKey(chord))
                    {
                        var item = dict.Where(x => x.Key == chord).First();
                        var message = string.Join(Environment.NewLine, item.Value);
                        var har = new HarmonicAnalysisResult(this, true, message, item.Key);
                        result.Add(har);
                    }
                }
            }
            return result;
        }

        public List<ModalInterchangeGrid> CreateGrids(KeySignature key)
        {
            var grids = new List<ModalInterchangeGrid>();

            using (new TimedLogger(MethodBase.GetCurrentMethod().Name))
            {
                grids.Add(this.CreateMajorBorrowedChordGrid(key));
                grids.Add(this.CreateMelodicMinorBorrowedChordGrid(key));
                grids.Add(this.CreateHarmonicMinorBorrowedChordGrid(key));
            }

            //using (new TimedLogger(MethodBase.GetCurrentMethod().Name))
            //{
            //    var json = Helpers.LoadEmbeddedResource($"{nameof(ModalInterchangeGrid)} {key.Name}");
            //    grids = JsonConvert.DeserializeObject<List<ModalInterchangeGrid>>(json);
            //}
            return grids;
        }

        ModalInterchangeGrid CreateMajorBorrowedChordGrid(KeySignature inputKey)
        {
            var result = new ModalInterchangeGrid();

            //using (new TimedLogger(MethodBase.GetCurrentMethod().Name))
            {
                var keys = new List<KeySignature> { 
				// These keys represent the transposed key for each row.
				// E.G, 2nd row Cm7 is the Dorian chord from Bb, 4th row CMaj7 is the Lydian chord from key of G.
				inputKey,
                inputKey - Interval.Major2nd,
                inputKey - Interval.Major3rd,
                inputKey - Interval.Perfect4th,
                inputKey - Interval.Perfect5th,
                inputKey - Interval.Major6th,
                inputKey - Interval.Major7th,
            };
                var chordTypes = new List<ChordIntervalsEnum>() { //harmonized major scale
				ChordIntervalsEnum.ChordTypeMajor7th,
                ChordIntervalsEnum.ChordTypeMinor7th,
                ChordIntervalsEnum.ChordTypeMinor7th,
                ChordIntervalsEnum.ChordTypeMajor7th,
                ChordIntervalsEnum.ChordTypeDominant7th,
                ChordIntervalsEnum.ChordTypeMinor7th,
                ChordIntervalsEnum.ChordTypeHalfDiminished
            };

                var chordTypeNdx = 0;
                var modeNdx = 0;

                foreach (var key in keys)
                {
                    var mode = _modes[modeNdx++];
                    var scale = new MajorModalScaleFormula(key, mode);
                    var gridRow = new ModalInterchangeGridRow(key, scale.ModeName);

                    foreach (var scaleDegreeNdx in _scaleDegreeNdxs)
                    {
                        var chordType = chordTypes.NextOrFirst(ref chordTypeNdx);
                        var formula = ChordFormula.Catalog
                            .Where(x => x.Root == scale.NoteNames[scaleDegreeNdx]
                                && x.ChordType == chordType)
                            .FirstOrDefault();
                        if (null != formula)
                            gridRow.Chords.Add(formula.Copy());
                    }

                    result.Rows.Add(gridRow);
                    chordTypes.NextOrFirst(ref chordTypeNdx); //create an offset
                }


                #region debug output
                //Debug.WriteLine($"===={MethodInfo.GetCurrentMethod().Name}====");
                //foreach (var row in result.Rows)
                //{
                //	Debug.Write($"{row.Key,3}");
                //	Debug.Write($"| {row.Mode.ToString()} ");
                //	Debug.WriteLine($"| {string.Join(", ", row.Formulas.Select(x => x.Name))}");
                //}
                //Debug.WriteLine("");
                #endregion
            }

            return result;
        }

        ModalInterchangeGrid CreateMelodicMinorBorrowedChordGrid(KeySignature inputKey)
        {
            var result = new ModalInterchangeGrid();

            //using (new TimedLogger(MethodBase.GetCurrentMethod().Name))
            {
                var keys = new List<KeySignature> { 
				// These keys represent the transposed key for each row.
				// E.G, 2nd row Cm7 is the Dorian chord from Bb, 4th row CMaj7 is the Lydian chord from key of G.
				inputKey,
                inputKey - Interval.Major2nd,
                inputKey - Interval.Minor3rd,
                inputKey - Interval.Perfect4th,
                inputKey - Interval.Diminished5th,
                inputKey - Interval.Minor6th,
                inputKey - Interval.Minor7th,
            };

                var chordTypes = new List<ChordIntervalsEnum>() { //harmonized melodic minor scale
				ChordIntervalsEnum.ChordTypeMinorMajor7th,
                ChordIntervalsEnum.ChordTypeMinor7th,
                ChordIntervalsEnum.ChordTypeMajor7thAug5,
                ChordIntervalsEnum.ChordTypeDominant7th,
                ChordIntervalsEnum.ChordTypeDominant7th,
                ChordIntervalsEnum.ChordTypeHalfDiminished,
                ChordIntervalsEnum.ChordTypeHalfDiminished
            };

                var chordTypeNdx = 0;
                var modeNdx = 0;

                foreach (var key in keys)
                {
                    var mode = _modes[modeNdx++];
                    var scale = new MelodicMinorModalScaleFormula(key, mode);
                    var gridRow = new ModalInterchangeGridRow(key, scale.ModeName);

                    foreach (var scaleDegreeNdx in _scaleDegreeNdxs)
                    {
                        var chordType = chordTypes.NextOrFirst(ref chordTypeNdx);
                        var formula = ChordFormula.Catalog
                            .Where(x => x.Root == scale.NoteNames[scaleDegreeNdx]
                                && x.ChordType == chordType)
                            .FirstOrDefault();

                        gridRow.Chords.Add(formula);
                    }

                    result.Rows.Add(gridRow);
                    chordTypes.NextOrFirst(ref chordTypeNdx); //create an offset
                }


                #region debug output
                //Debug.WriteLine($"===={MethodInfo.GetCurrentMethod().Name}====");
                //foreach (var row in result.Rows)
                //{
                //	Debug.Write($"{row.Key,3}");
                //	Debug.Write($"| {row.ModeName.ToString()} ");
                //	Debug.WriteLine($"| {string.Join(", ", row.Formulas.Select(x => x.Name))}");
                //}
                //Debug.WriteLine("");
                #endregion
            }
            return result;
        }

        ModalInterchangeGrid CreateHarmonicMinorBorrowedChordGrid(KeySignature inputKey)
        {
            var result = new ModalInterchangeGrid();

            //using (new TimedLogger(MethodBase.GetCurrentMethod().Name))
            {
                var keys = new List<KeySignature> { 
				// These keys represent the transposed key for each row.
				// E.G, 2nd row Cm7 is the Dorian chord from Bb, 4th row CMaj7 is the Lydian chord from key of G.
				inputKey,
                inputKey - Interval.Major2nd,
                inputKey - Interval.Minor3rd,
                inputKey - Interval.Perfect4th,
                inputKey - Interval.Diminished5th,
                inputKey - Interval.Minor6th,
                inputKey - Interval.Minor7th,
            };
                var chordTypes = new List<ChordIntervalsEnum>() { //harmonized melodic minor scale
				ChordIntervalsEnum.MinorMaj7th,
                ChordIntervalsEnum.HalfDiminished,
                ChordIntervalsEnum.Major7Aug5,
                ChordIntervalsEnum.Minor7th,
                ChordIntervalsEnum.Dominant7th,
                ChordIntervalsEnum.Major7th,
                ChordIntervalsEnum.Diminished7
            };

                var chordTypeNdx = 0;
                var modeNdx = 0;

                //var scale = new ModeFormula(inputKey, ModeEnum.Ionian);
                foreach (var key in keys)
                {
                    var mode = _modes[modeNdx++];
                    var scale = new HarmonicMinorModalScaleFormula(key, mode);
                    var gridRow = new ModalInterchangeGridRow(key, scale.ModeName);

                    foreach (var scaleDegreeNdx in _scaleDegreeNdxs)
                    {
                        var chordType = chordTypes.NextOrFirst(ref chordTypeNdx);
                        //Debug.WriteLine(scale);
                        var chord = ChordFormula.Catalog
                            .Where(x => x.Root == scale.NoteNames[scaleDegreeNdx]
                                && x.ChordType == chordType)
                            .FirstOrDefault();
                        gridRow.Chords.Add(chord);
                    }

                    result.Rows.Add(gridRow);
                    chordTypes.NextOrFirst(ref chordTypeNdx); //create an offset
                }


                #region debug output
                //Debug.WriteLine($"===={MethodInfo.GetCurrentMethod().Name}====");
                //foreach (var row in result.Rows)
                //{
                //	Debug.Write($"{row.Key,3}");
                //	Debug.Write($"| {row.ModeName.ToString()} ");
                //	Debug.WriteLine($"| {string.Join(", ", row.Formulas.Select(x => x.Name))}");
                //}
                //Debug.WriteLine("");
                #endregion
            }
            return result;
        }

        Dictionary<ChordFormula, List<string>> PopulateGrids(KeySignature key, List<ModalInterchangeGrid> grids, IEnumerable<ChordFormula> nonDiatonic)
        {
            var result = new Dictionary<ChordFormula, List<string>>();
            //using (new TimedLogger(MethodBase.GetCurrentMethod().Name))
            {
                foreach (var chord in nonDiatonic)
                {
                    foreach (var grid in grids)
                    {
                        var rows = grid.Rows.Where(x => x.Chords.Contains(chord, new ChordFormulaFunctionalEqualityComparer())).ToList(); // get row from grid.
                        foreach (var row in rows)
                        {
                            var message = $"• {chord.Name} could be considered a borrowed chord from the parallel {key.NoteName} {row.ModeName} mode in {row.Key}.";
                            if (result.Keys.Contains(chord))
                            {
                                result[chord].Add(message);
                            }
                            else
                            {
                                result.Add(chord, new List<string> { message });
                            }
                        }
                        new object();
                    }
                }
            }
            return result;
        }

    }//class

    public class TimedLogger : IDisposable
    {
        private bool disposedValue;

        string MethodName { get; set; }
        Stopwatch Stopwatch { get; set; }

        public TimedLogger(string methodName)
        {
            this.MethodName = methodName;
            //Debug.WriteLine($"+{this.MethodName}");
            this.Stopwatch = Stopwatch.StartNew();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Stopwatch.Stop();
                    Debug.WriteLine($"-{this.MethodName} took: {this.Stopwatch.ElapsedMilliseconds}, {this.Stopwatch.ElapsedTicks}");

                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~TimedLogger()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}//ns