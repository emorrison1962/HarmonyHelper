using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

namespace NeckDiagrams
{
	public class HarmonyModel
	{
		public KeySignature KeySignature 
		{ get; set; }
		
		ScaleFormulaBase _ScaleFormula;
		public ScaleFormulaBase ScaleFormula 
		{ 
			get { return _ScaleFormula; }
			set 
			{ 
				_ScaleFormula = value;
				_ChordFormula = null;
			} 
		}
		
		ChordFormula _ChordFormula;
		public ChordFormula ChordFormula
		{
			get { return _ChordFormula; }
			set
			{
				_ChordFormula = value;
				_ScaleFormula = null;
			}
		}
		public List<NoteName> NoteNames
		{
			get
			{
				return this.ScaleFormula?.NoteNames ?? this.ChordFormula?.NoteNames;
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
	}
}
