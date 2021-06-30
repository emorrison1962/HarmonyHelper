using System;
using System.Collections.Generic;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

namespace NeckDiagrams
{
	[Flags]
	public enum ModelItemTypeEnum
	{
		Scale = 1,
		Arpeggio = 1 << 2,
		//Chord = 1 << 3
	}

	public class ModelItem
	{
		public event EventHandler<ModelItem> ModelItemChanged;
		ModelItemTypeEnum _ModelType;
		public ModelItemTypeEnum ModelType
		{
			get { return _ModelType; }
			set
			{
				_ModelType = value;
				this.OnModelItemChanged();
			}
		}
		public INoteNameContainer NoteNameContainer { get; private set; }

		public ModelItem(INoteNameContainer nnc)
		{
			this.NoteNameContainer = nnc;
			if (nnc is ScaleFormulaBase)
				this.ModelType = ModelItemTypeEnum.Scale;
			else if (nnc is ChordFormula)
				this.ModelType = ModelItemTypeEnum.Arpeggio;
		}

		void OnModelItemChanged()
		{
			if (null != this.ModelItemChanged)
				ModelItemChanged(this, this);
		}

	}

	public class HarmonyModel
	{
		public event EventHandler<HarmonyModel> ModelChanged;

		List<INoteNameContainer> Items { get; set; } = new List<INoteNameContainer>();
		KeySignature _KeySignature;

		//ScaleFormulaBase _ScaleFormula = ScaleFormulaBase.Empty;
		//ChordFormula _ChordFormula = ChordFormula.Empty;

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

		//public ScaleFormulaBase ScaleFormula
		//{
		//	get { return _ScaleFormula; }
		//	set
		//	{
		//		_ScaleFormula = value;
		//		this.OnModelChanged();
		//	}
		//}

		//public ChordFormula ChordFormula
		//{
		//	get { return _ChordFormula; }
		//	set
		//	{
		//		_ChordFormula = value;
		//		this.OnModelChanged();
		//	}
		//}
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
				throw new NotImplementedException();
				//var result = false;
				//if (null != this.KeySignature)
				//	if (null != ScaleFormula || null != ChordFormula)
				//		if (null != this.NoteNames && this.NoteNames.Count > 0)
				//			result = true;
				//return result;
			}
		}

		List<NoteName> NormalizeNoteNames()
		{


			var result = this.
				ScaleFormula?.NoteNames;
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
