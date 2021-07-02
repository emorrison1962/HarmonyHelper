﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Scales;

namespace NeckDiagrams
{
	public class HarmonyModelItem
	{
		public event EventHandler<HarmonyModelItem> ModelItemChanged;
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
		public ScaleFormulaBase ScaleFormula { get; set; }
		public ChordFormula ChordFormula { get; set; }

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

		public NoteName Root { get; private set; }


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
				return true;
				//var result = false;
				//if (null != this.KeySignature)
				//	if (null != ScaleFormula || null != ChordFormula)
				//		if (null != this.NoteNames && this.NoteNames.Count > 0)
				//			result = true;
				//return result;
			}
		}

	}
}