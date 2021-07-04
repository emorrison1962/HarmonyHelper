using System;
using System.Collections.Generic;
using System.Linq;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using HarmonyHelper.IoC;

namespace NeckDiagrams
{
	[Flags]
	public enum ModelItemTypeEnum
	{
		Scale = 1,
		Arpeggio = 1 << 2,
		//Chord = 1 << 3
	}


	public class HarmonyModel : IHarmonyModel
	{
		public event EventHandler<HarmonyModel> ModelChanged;

		public List<HarmonyModelItem> Items { get; set; } = new List<HarmonyModelItem>();
		KeySignature _KeySignature;

		public KeySignature KeySignature
		{
			get { return this._KeySignature; }
			set
			{
				this._KeySignature = value;
				Container.Register<INoteNameNormalizer>(this._KeySignature);
				//this.NormalizeNoteNames();
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

		public HarmonyModel(KeySignature key)
		{
			this.KeySignature = key;
			Container.Register<IHarmonyModel>(this);
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

		List<NoteName> NormalizeNoteNames()
		{
			//throw new NotImplementedException();
			var nns = new HashSet<NoteName>();
			foreach (var item in this.Items)
			{
				item.NoteNames.ForEach(x => nns.Add(x));
			}

			var result = nns.ToList();
			if (null != result && null != this.KeySignature)
			{
				this.KeySignature.Normalize(ref result);
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
			this.OnModelChanged();
		}
	}//class
}//ns
