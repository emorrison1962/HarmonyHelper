using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public class ScaleFormulaCatalog
	{
		public List<ScaleFormulaBase> Formulas { get; protected set; } = new List<ScaleFormulaBase>();


		void Add(ScaleFormulaBase formula)
		{
			this.Formulas.Add(formula);
		}
		public ScaleFormulaCatalog()
		{
			var keys = KeySignature.MajorKeys;
			foreach (var key in keys)
			{
				this.Add(new ModeFormula(key, ModeEnum.Ionian));
				this.Add(new ModeFormula(key, ModeEnum.Dorian));
				this.Add(new ModeFormula(key, ModeEnum.Phrygian));
				this.Add(new ModeFormula(key, ModeEnum.Lydian));
				this.Add(new ModeFormula(key, ModeEnum.Mixolydian));
				this.Add(new ModeFormula(key, ModeEnum.Aeolian));
				this.Add(new ModeFormula(key, ModeEnum.Locrian));

				this.Add(new PentatonicMajorFormula(key));
				this.Add(new BluesScaleFormula(key));

				this.Add(new WholeToneFormula(key));
				this.Add(new DiminishedHalfWholeFormula(key));
				this.Add(new DiminishedWholeHalfFormula(key));
			}

			keys = KeySignature.MinorKeys;
			foreach (var key in keys)
			{
				this.Add(new HarmonicMinorFormula(key));
#warning FIXME: *** IMPLEMENT MelodicMinor ***
				//this.Add(new MelodicMinorFormula(key));

				this.Add(new PentatonicMinorFormula(key));
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
			var valueComparer = new NoteNameValueEqualityComparer();
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
