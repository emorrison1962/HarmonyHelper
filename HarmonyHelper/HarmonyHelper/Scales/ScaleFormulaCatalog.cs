﻿using System.Collections.Generic;
using System.Linq;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Scales;

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
				this.Add(new MajorModalScaleFormula(key, ModeEnum.Ionian));
				this.Add(new MajorModalScaleFormula(key, ModeEnum.Dorian));
				this.Add(new MajorModalScaleFormula(key, ModeEnum.Phrygian));
				this.Add(new MajorModalScaleFormula(key, ModeEnum.Lydian));
				this.Add(new MajorModalScaleFormula(key, ModeEnum.Mixolydian));
				this.Add(new MajorModalScaleFormula(key, ModeEnum.Aeolian));
				this.Add(new MajorModalScaleFormula(key, ModeEnum.Locrian));

				this.Add(new PentatonicMajorScaleFormula(key));
				this.Add(new NonatonicBluesScaleFormula(key));

				this.Add(new WholeToneScaleFormula(key));
				this.Add(new DiminishedHalfWholeScaleFormula(key));
				this.Add(new DiminishedWholeHalfScaleFormula(key));
			}

			keys = KeySignature.MinorKeys;
			foreach (var key in keys)
			{
				this.Add(new HarmonicMinorScaleFormula(key));
				this.Add(new MelodicMinorScaleFormula(key));

				this.Add(new PentatonicMinorScaleFormula(key));
				this.Add(new HexatonicBluesScaleFormula(key));
				this.Add(new HeptatonicBluesScaleFormula(key));

				this.Add(new HarmonicMinorModalScaleFormula(key, ModeEnum.Ionian));
				this.Add(new HarmonicMinorModalScaleFormula(key, ModeEnum.Dorian));
				this.Add(new HarmonicMinorModalScaleFormula(key, ModeEnum.Phrygian));
				this.Add(new HarmonicMinorModalScaleFormula(key, ModeEnum.Lydian));
				this.Add(new HarmonicMinorModalScaleFormula(key, ModeEnum.Mixolydian));
				this.Add(new HarmonicMinorModalScaleFormula(key, ModeEnum.Aeolian));
				this.Add(new HarmonicMinorModalScaleFormula(key, ModeEnum.Locrian));

			}
		}

		public ScaleFormulaCatalog(KeySignature key)
		{
			this.Add(new MajorModalScaleFormula(key, ModeEnum.Ionian));
			this.Add(new MajorModalScaleFormula(key, ModeEnum.Dorian));
			this.Add(new MajorModalScaleFormula(key, ModeEnum.Phrygian));
			this.Add(new MajorModalScaleFormula(key, ModeEnum.Lydian));
			this.Add(new MajorModalScaleFormula(key, ModeEnum.Mixolydian));
			this.Add(new MajorModalScaleFormula(key, ModeEnum.Aeolian));
			this.Add(new MajorModalScaleFormula(key, ModeEnum.Locrian));

			this.Add(new PentatonicMajorScaleFormula(key));
			this.Add(new NonatonicBluesScaleFormula(key));

			this.Add(new WholeToneScaleFormula(key));
			this.Add(new DiminishedHalfWholeScaleFormula(key));
			this.Add(new DiminishedWholeHalfScaleFormula(key));


			this.Add(new HarmonicMinorScaleFormula(key));
			this.Add(new MelodicMinorScaleFormula(key));

			this.Add(new PentatonicMinorScaleFormula(key));
			this.Add(new HexatonicBluesScaleFormula(key));
			this.Add(new HeptatonicBluesScaleFormula(key));

			this.Add(new HarmonicMinorModalScaleFormula(key, ModeEnum.Ionian));
			this.Add(new HarmonicMinorModalScaleFormula(key, ModeEnum.Dorian));
			this.Add(new HarmonicMinorModalScaleFormula(key, ModeEnum.Phrygian));
			this.Add(new HarmonicMinorModalScaleFormula(key, ModeEnum.Lydian));
			this.Add(new HarmonicMinorModalScaleFormula(key, ModeEnum.Mixolydian));
			this.Add(new HarmonicMinorModalScaleFormula(key, ModeEnum.Aeolian));
			this.Add(new HarmonicMinorModalScaleFormula(key, ModeEnum.Locrian));

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
					if (scale is ModalScaleFormulaBase)
					{
						if (scale.NoteNames[0] == cf.Root)
						{
							result.Add(scale);
						}
					}
					else if (scale is PentatonicScaleFormula)
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
