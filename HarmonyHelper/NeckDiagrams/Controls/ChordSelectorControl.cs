using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeckDiagrams
{
	public partial class ChordSelectorControl : UserControl
	{
		public event EventHandler<ChordFormula> SelectedChordChanged;
		public ChordFormula SelectedItem
		{
			get { return this._cbChordType .SelectedItem as ChordFormula; }
			set
			{
				var items = this._cbChordType.Items.Cast<ChordType>();
				var item = items.ToList()
					.Where(x => x.Name() == value.ChordType.Name)
					.First();
				this._cbChordType.SelectedItem = item;
			}
		}

		public NoteName NoteName
		{
			get { return _chordNoteNameCombo.SelectedNoteName; }
			set { _chordNoteNameCombo.SelectedNoteName = value; }
		}


		#region Costruction
		public ChordSelectorControl()
		{
			InitializeComponent();
			this.Load += this.ChordSelectorControl_Load;
		}

		private void ChordSelectorControl_Load(object sender, EventArgs e)
		{
			_chordNoteNameCombo.SelectionChanged += this._chordNoteNameCombo_SelectionChanged;
			this._cbChordType.Enabled = false;
			this.PopulateChordFormulas();
		}

		void PopulateChordFormulas()
		{
			this._cbChordType.Items.Clear();
			foreach (var chordType in ChordType.Catalog.OrderBy(x => x.Name))
			{
				this._cbChordType.Items.Add(chordType);
			}
		}
		#endregion

		private void _chordNoteNameCombo_SelectionChanged(object sender, NoteName nn)
		{
			this._cbChordType.Enabled = true;
			this.OnSelectedChordChanged();
		}

		private void _cbChordType_SelectedValueChanged(object sender, EventArgs e)
		{
			var chordType = _cbChordType.SelectedItem as ChordType;
			this.OnSelectedChordChanged();
		}
		void OnSelectedChordChanged()
		{
			if (null != this.SelectedChordChanged)
			{
				if (null != _chordNoteNameCombo.SelectedNoteName
					&& null != _cbChordType.SelectedItem)
				{
					var root = _chordNoteNameCombo.SelectedNoteName;
					var chordType = _cbChordType.SelectedItem as ChordType;
					var model = HarmonyHelper.IoC.Container.Resolve<IHarmonyModel>();
					var result = ChordFormulaFactory.Get(root, chordType, model.KeySignature);
					this.SelectedChordChanged(this, result);
				}
			}
		}

	}//class
}//ns
