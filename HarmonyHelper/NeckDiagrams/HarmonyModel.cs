using System;
using System.Collections.Generic;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

namespace NeckDiagrams
{
	[Flags]
	public enum ModelTypeEnum
	{
		Scale = 1,
		Arpeggio = 1 << 2,
		Chord = 1 << 3
	}
	public class HarmonyModel
	{
		public event EventHandler<HarmonyModel> ModelChanged;

		ModelTypeEnum _ModelType;
		KeySignature _KeySignature;
		ScaleFormulaBase _ScaleFormula = ScaleFormulaBase.Empty;
		ChordFormula _ChordFormula = ChordFormula.Empty;

		public ModelTypeEnum ModelType
		{
			get { return _ModelType; }
			set
			{
				_ModelType = value; 
				this.OnModelChanged();
			}
		}
		public KeySignature KeySignature
		{
			get { return this._KeySignature; }
			set
			{
				this._KeySignature = value;
				this.NormalizeNoteNames();
				this.OnModelChanged();
			}
		}

		public ScaleFormulaBase ScaleFormula
		{
			get { return _ScaleFormula; }
			set
			{
				_ScaleFormula = value;
				this.OnModelChanged();
			}
		}

		public ChordFormula ChordFormula
		{
			get { return _ChordFormula; }
			set
			{
				_ChordFormula = value;
				this.OnModelChanged();
			}
		}
		public List<NoteName> NoteNames
		{
			get
			{
				var result = this.NormalizeNoteNames();
				return result;
			}
		}

		public bool IsValid
		{
			get
			{
				var result = false;
				if (null != this.KeySignature)
					if (null != ScaleFormula || null != ChordFormula)
						if (null != this.NoteNames && this.NoteNames.Count > 0)
							result = true;
				return result;
			}
		}

		List<NoteName> NormalizeNoteNames()
		{

			var result = this.ScaleFormula?.NoteNames;
			if (null != this.ChordFormula?.NoteNames)
				result.AddRange(this.ChordFormula?.NoteNames);

			if (null != result && null != this.KeySignature)
			{
				this.KeySignature.Normalize(ref result);
			}
			return result;
		}

		void OnModelChanged()
		{
			if (null != this.ModelChanged)
				ModelChanged(this, this);
		}
	}//class
}//ns
