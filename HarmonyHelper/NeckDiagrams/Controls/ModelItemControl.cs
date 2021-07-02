using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

namespace NeckDiagrams
{
	public partial class ModelItemControl : UserControl
	{
		public event EventHandler<HarmonyModelItem> ModelItemChanged;
		const string SELECT_ITEM_TYPE = "Select Item Type";
		const string ARPEGGIO = "Arpeggio";
		const string SCALE = "Scale";
		public HarmonyModelItem Item { get; private set; }
		public ScaleFormulaCatalog ScaleFormulaCatalog { get; private set; }
		NoteName Root { get; set; }

		HarmonyModel Model
		{
			get
			{
				var result = HarmonyHelper.IoC.Container
					.Resolve<IHarmonyModel>() as HarmonyModel;
				return result;
			}
		}

		#region Construction
		public ModelItemControl()
		{
			InitializeComponent();
			groupBox.Text = SELECT_ITEM_TYPE;
			scalePanel.Visible = false;
			arpPanel.Visible = false;
			this.Load += this.Form1_Load;
		}

		public ModelItemControl(HarmonyModelItem Item) : this()
		{
			this.Item = Item;
			if (ModelItemTypeEnum.Arpeggio == this.Item.ModelType)
			{
				_rbArpeggio.Checked = true;
			}
			else
			{
				_rbScale.Checked = true;
			}

		}
		private void Form1_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				this.Populate();

				if (null != this.Item)
				{
					if (ModelItemTypeEnum.Arpeggio == this.Item.ModelType)
					{
						this._cbChordType.SelectedValueChanged -= this._cbChordType_SelectedValueChanged;
						_cbChordType.SelectedItem = Item.ChordFormula.ChordType;
						this._cbChordType.SelectedValueChanged += this._cbChordType_SelectedValueChanged;
					}
					else
					{
						this._cbScaleType.SelectedValueChanged -= this._cbScaleType_SelectedValueChanged;
						_cbScaleType.SelectedItem = Item.ScaleFormula;
						this._cbScaleType.SelectedValueChanged += this._cbScaleType_SelectedValueChanged;
					}
				}
			}
		}

		#endregion

		void Populate()
		{
			this.Populate_cbChordType();
			_chordNoteNameCombo.SelectionChanged += this._chordNoteNameCombo_SelectionChanged;
			_scaleNoteNameCombo.SelectionChanged += this._scaleNoteNameCombo_SelectionChanged;
			_cbChordType.Enabled = false;
			_cbScaleType.Enabled = false;
		}

		private void _chordNoteNameCombo_SelectionChanged(object sender, NoteName e)
		{
			this.Root = e;
			_cbChordType.Enabled = true;
		}

		private void _scaleNoteNameCombo_SelectionChanged(object sender, NoteName e)
		{
			this.Root = e;
			_cbScaleType.Enabled = true;
			this.Populate_cbScaleType();
		}

		void Populate_cbScaleType()
		{
			_cbScaleType.Items.Clear();
			var key = KeySignature.Catalog.Where(x => x.NoteName == this.Root).First();

			this.ScaleFormulaCatalog = new ScaleFormulaCatalog(key);
			foreach (var st in ScaleFormulaCatalog.Formulas
				.Where(x => x.Root == this.Root)
				.OrderBy(x => x.Name))
			{
				_cbScaleType.Items.Add(st);
			}
		}

		void Populate_cbChordType()
		{
			this._cbChordType.Items.Clear();

			//foreach (var formula in ChordType.Catalog.OrderBy(x => x.Name))
			//{
			//	Debug.WriteLine(formula.GetType().Name);
			//}
			foreach (var formula in ChordType.Catalog.OrderBy(x => x.Name))
			{
				this._cbChordType.Items.Add(formula);
			}

		}

		private void _rbScale_CheckedChanged(object sender, EventArgs e)
		{
			scalePanel.Visible = _rbScale.Checked;
			groupBox.Text = _rbScale.Checked ? SCALE : ARPEGGIO;
		}

		private void _rbArpeggio_CheckedChanged(object sender, EventArgs e)
		{
			arpPanel.Visible = _rbArpeggio.Checked;
			groupBox.Text = _rbArpeggio.Checked ? ARPEGGIO : SCALE;
		}

		private void _cbScaleType_SelectedValueChanged(object sender, EventArgs e)
		{
			if (null != this.Root)
			{
				this.Item = new HarmonyModelItem(_cbScaleType.SelectedItem as INoteNameContainer);
				this.OnModelItemChanged();
			}
		}

		private void _cbChordType_SelectedValueChanged(object sender, EventArgs e)
		{
			if (null != this.Root)
			{
				var chordType = _cbChordType.SelectedItem as ChordType;
				var formula = ChordFormulaFactory.Create(
					this.Root, chordType, Model.KeySignature);

				this.Item = new HarmonyModelItem(formula);
				this.OnModelItemChanged();
			}
		}

		void OnModelItemChanged()
		{
			if (null != this.ModelItemChanged)
				this.ModelItemChanged(this, this.Item);
		}

		private void _bnColor_Click(object sender, EventArgs e)
		{
			if (null != this.Item)
			{
				if (DialogResult.OK == this.colorDialog.ShowDialog())
				{
					var color = this.colorDialog.Color;
					this._colorSwatch.BackColor = color;
					this.Item.NoteColor = color;
					this.OnModelItemChanged();
				}
			}
		}
	}//class
}//ns
