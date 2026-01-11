using System;
using System.Collections.Generic;
using System.Linq;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using HarmonyHelper.IoC;

namespace NeckDiagrams
{

	public abstract class HarmonyContext : IHarmonyContext
	{
		public event EventHandler<HarmonyContext> ModelChanged;

        KeySignature _KeySignature;

		#region Properties
		public List<HarmonyModelItem> Items { get; set; } = new List<HarmonyModelItem>();

		public KeySignature? KeySignature
		{
			get { return this._KeySignature; }
			set
			{
				this._KeySignature = value;
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
				var result = this.Items.Any(x => x.IsValid == false);
				if (!result)
				{
					if (null != this.KeySignature)
					{
						if (null != this.NoteNames && this.NoteNames.Count > 0)
						{
							result = true;
						}
					}
				}
				return result;
			}
		}

        #endregion

        #region Construction
        protected HarmonyContext()
        {
            Container.Register<IHarmonyContext>(this);
        }
        public HarmonyContext(KeySignature key) : this()
		{
			this.KeySignature = key;
		}

		#endregion

		List<NoteName> NormalizeNoteNames()
		{
			throw new NotImplementedException();
			var nns = new HashSet<NoteName>();
			foreach (var item in this.Items)
			{
				item.NoteNames.ForEach(x => nns.Add(x));
			}

			var result = nns.ToList();
			if (null != result && null != this.KeySignature)
			{
				//this.KeySignature.Normalize(ref result);
			}
			return result;
		}

		void OnModelChanged()
		{
			if (null != this.ModelChanged)
				this.ModelChanged(this, this);
		}

		internal void Add(HarmonyModelItem item)
		{
			this.Items.Add(item);
			item.ModelItemChanged += this.Item_ModelItemChanged;
			this.OnModelChanged();
		}

		private void Item_ModelItemChanged(object sender, HarmonyModelItem e)
		{
			this.OnModelChanged();
		}
	}//class

    public class ScaleHarmonyModel : HarmonyContext
    {
        public ScaleHarmonyModel(KeySignature key) : base(key)
        {
        }
    }

    public class ChordFormulaContext : HarmonyContext
    {
        public ChordFormula ChordFormula { get; set; }
		public ChordFormulaContext(ChordFormula cf, KeySignature key = null) : base(key)
        {
			this.ChordFormula = cf;
        }
    }

}//ns
