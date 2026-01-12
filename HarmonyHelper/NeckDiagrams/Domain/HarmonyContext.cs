using System;
using System.Collections.Generic;
using System.Linq;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Scales;

using HarmonyHelper.IoC;

namespace NeckDiagrams
{

	public abstract class HarmonyContext<T> : IHarmonyContext<T>, INoteNameContainer where T: INoteNameContainer
    {
        KeySignature _KeySignature;

		#region Properties

		public KeySignature? KeySignature
		{
			get { return this._KeySignature; }
			set
			{
				this._KeySignature = value;
			}
		}

		public List<NoteName> NoteNames
		{
			get
			{
				var result = this.Value.NoteNames;
				//var result = this.NormalizeNoteNames();
				return result;
			}
		}

		public T Value { get; private set; }

        #endregion

        #region Construction
        protected HarmonyContext()
        {
            Container.Register<IHarmonyContext<T>>(this);
        }
        public HarmonyContext(T t) : this()
		{
			this.Value = t;
		}

		#endregion

		//List<NoteName> NormalizeNoteNames()
		//{
		//	throw new NotImplementedException();
		//	var nns = new HashSet<NoteName>();
		//	foreach (var item in this.Items)
		//	{
		//		item.NoteNames.ForEach(x => nns.Add(x));
		//	}

		//	var result = nns.ToList();
		//	if (null != result && null != this.KeySignature)
		//	{
		//		//this.KeySignature.Normalize(ref result);
		//	}
		//	return result;
		//}

	}//class

    public class ScaleHarmonyContext : HarmonyContext<ScaleFormulaBase>
    {
        public ScaleHarmonyContext(ScaleFormulaBase sf) : base(sf)
        {
        }
    }

    public class ChordFormulaContext : HarmonyContext<ChordFormula>
    {
		public ChordFormulaContext(ChordFormula cf, KeySignature key = null) : base(cf)
        {
        }
    }

    public class junk : INoteNameContainer
    {
        public List<NoteName> NoteNames { get; }
    }

}//ns
