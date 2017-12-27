using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony
{
    public class ScaleFormulaCatalog
    {
        public List<ScaleFormulaBase> Formulas { get; protected set; } = new List<ScaleFormulaBase>();

        public ScaleFormulaCatalog()
        {
            var keys = KeySignature.MajorKeys;
            foreach (var key in keys)
            {
                this.Formulas.Add(new ModeFormula(key, ModeEnum.Ionian));
                var root = key.NoteName + new IntervalContext(key, IntervalsEnum.Major2nd);
                this.Formulas.Add(new ModeFormula(key, ModeEnum.Dorian));
                this.Formulas.Add(new ModeFormula(key, ModeEnum.Phrygian));
                this.Formulas.Add(new ModeFormula(key, ModeEnum.Lydian));
                this.Formulas.Add(new ModeFormula(key, ModeEnum.Mixolydian));
                this.Formulas.Add(new ModeFormula(key, ModeEnum.Aeolian));
                this.Formulas.Add(new ModeFormula(key, ModeEnum.Locrian));

                this.Formulas.Add(new HarmonicMinorFormula(key));
#warning FIXME: *** IMPLEMENT MelodicMinor ***
                //this.Formulas.Add(new MelodicMinorFormula(key));
                this.Formulas.Add(new PentatonicMajorFormula(key));
                this.Formulas.Add(new PentatonicMinorFormula(key + IntervalsEnum.Minor3rd));
#warning *** FIXME ***
                this.Formulas.Add(new WholeToneFormula(key));
                this.Formulas.Add(new DiminishedHalfWholeFormula(key));
                this.Formulas.Add(new DiminishedWholeHalfFormula(key));
            }
        }

        public List<ScaleFormulaBase> GetScalesContaining(ChordFormula cf)
        {
            var result = new List<ScaleFormulaBase>();
            var tmp = new List<ScaleFormulaBase>();

            #region Get the scales containing the chord
            var sorted = this.Formulas.OrderBy(x => x.Name).ToList();
            foreach (var sf in sorted)
            {
                var hasChord = sf.Contains(cf);
                if (hasChord) 
                {
                    //Debug.Write(scale.Name.ToString());
                    tmp.Add(sf);
                }
            }
            #endregion

            #region Get rid of enharmonic equivelents.
            var valueComparer = new NoteNameValueComparer();
            var groups = tmp
                .Where(x => (x.Key.UsesFlats == cf.Key.UsesFlats 
                    && x.Key.UsesSharps == cf.Key.UsesSharps))
                .GroupBy(x => x.NoteNames.Sum(y => y.Value), x => x)
                .ToList();

            foreach (var group in groups)
            {
                var scales = group.ToList();
                foreach (var scale in scales)
                {
                    if (scale is ModeFormula)
                    {
                        if (scale.NoteNames[0] == cf.Root)
                        {
                            result.Add(scale);
                        }
                    }
                    else if (scale is PentatonicFormula)
                    {
                        if (scale.NoteNames[0] == cf.Root)
                        {
                            result.Add(scale);
                        }
                    }
                }
            }
            #endregion

            return result;
        }
    }//class
}//ns
