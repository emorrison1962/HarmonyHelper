using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
    public class ScaleFormulaCatalog
    {
        public List<KeyedScaleFormulaBase> Formulas { get; protected set; } = new List<KeyedScaleFormulaBase>();

        public ScaleFormulaCatalog()
        {
            var keys = KeySignature.MajorKeys;
            foreach (var key in keys)
            {
                this.Formulas.Add(new KeyedScaleFormulaBase(key, ModeFormula.Catalog.Ionian));
                this.Formulas.Add(new KeyedScaleFormulaBase(key, ModeFormula.Catalog.Dorian));
                this.Formulas.Add(new KeyedScaleFormulaBase(key, ModeFormula.Catalog.Phrygian));
                this.Formulas.Add(new KeyedScaleFormulaBase(key, ModeFormula.Catalog.Lydian));
                this.Formulas.Add(new KeyedScaleFormulaBase(key, ModeFormula.Catalog.Mixolydian));
                this.Formulas.Add(new KeyedScaleFormulaBase(key, ModeFormula.Catalog.Aeolian));
                this.Formulas.Add(new KeyedScaleFormulaBase(key, ModeFormula.Catalog.Locrian));

                this.Formulas.Add(new KeyedScaleFormulaBase(key, new HarmonicMinorFormula()));
#warning FIXME: *** IMPLEMENT MelodicMinor ***
                //this.Formulas.Add(new KeyedScaleFormulaBase(key, new MelodicMinorFormula()));
                this.Formulas.Add(new KeyedScaleFormulaBase(key, new PentatonicMajorFormula()));
                this.Formulas.Add(new KeyedScaleFormulaBase(key, new PentatonicMinorFormula()));
                this.Formulas.Add(new KeyedScaleFormulaBase(key, new WholeToneFormula()));
                this.Formulas.Add(new KeyedScaleFormulaBase(key, new DiminishedHalfWholeFormula()));
                this.Formulas.Add(new KeyedScaleFormulaBase(key, new DiminishedWholeHalfFormula()));
            }
        }
    }
}
