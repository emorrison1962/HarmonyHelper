using System;
using System.Collections.Generic;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Scales;

namespace NeckDiagrams
{
	public class HarmonyModelItem
	{
		public event EventHandler<HarmonyModelItem> ModelItemChanged;

		#region Fields
		System.Drawing.Color _Color;
		ModelItemTypeEnum _ModelType;
		ScaleFormulaBase _ScaleFormula;
		ChordFormula _ChordFormula;
		NoteName _Root;

		#endregion

		#region Properties
		public System.Drawing.Color Color { get { return _Color; } set { _Color = value; this.OnModelItemChanged(); } }
		public ModelItemTypeEnum ModelType
		{
			get { return _ModelType; }
			set
			{
				_ModelType = value;
				this.OnModelItemChanged();
			}
		}
		public ScaleFormulaBase ScaleFormula { get { return _ScaleFormula; } set { _ScaleFormula = value; this.OnModelItemChanged(); } }
		public ChordFormula ChordFormula { get { return _ChordFormula; } set { _ChordFormula = value; this.OnModelItemChanged(); } }
		public NoteName Root { get { return _Root; } set { _Root = value; this.OnModelItemChanged(); } }

		#endregion
		protected INoteNameContainer NoteNameContainer
		{
			get
			{
				var result =
					(this.ScaleFormula as INoteNameContainer)
						?? (this.ChordFormula as INoteNameContainer);
				return result;
			}
		}
		public List<NoteName> NoteNames { get { return NoteNameContainer.NoteNames; } }



		public HarmonyModelItem(INoteNameContainer nnc)
		{
			if (null == nnc)
				throw new ArgumentNullException("INoteNameContainer");

			this.Root = (nnc as IHasRootNoteName).Root;
			if (nnc is ScaleFormulaBase)
			{
				this.ModelType = ModelItemTypeEnum.Scale;
				this.ScaleFormula = nnc as ScaleFormulaBase;
			}
			else if (nnc is ChordFormula)
			{
				this.ModelType = ModelItemTypeEnum.Arpeggio;
				this.ChordFormula = nnc as ChordFormula;
			}
		}

		void OnModelItemChanged()
		{
			if (null != this.ModelItemChanged)
				ModelItemChanged(this, this);
		}

		public bool IsValid
		{
			get
			{
				var result = false;

				if (this.NoteNames?.Count > 0)
					if (System.Drawing.Color.Empty != this.Color)
						result = true;
				return result;
			}
		}

	}
}
