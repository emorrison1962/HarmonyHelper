using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using System;
using System.Windows.Forms;

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
		//NoteName Root { get; set; }

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
			scaleSelectorControl.Visible = false;
			chordSelectorControl.Visible = false;
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

				this.chordSelectorControl.SelectedChordChanged += this.ChordSelectorControl_SelectedChordChanged;

				this.scaleSelectorControl.SelectedScaleChanged += this.ScaleSelectorControl_SelectedScaleChanged;

				if (null != this.Item)
				{
					if (ModelItemTypeEnum.Arpeggio == this.Item.ModelType)
					{
						chordSelectorControl.SelectedItem = Item.ChordFormula;
					}
					else
					{
						scaleSelectorControl.SelectedItem = Item.ScaleFormula;
					}
				}
			}
		}

		#endregion

		void Populate()
		{
			this.chordSelectorControl.Enabled = false;
			this.scaleSelectorControl.Enabled = false;
		}

		private void _rbScale_CheckedChanged(object sender, EventArgs e)
		{
			this.scaleSelectorControl.Visible = _rbScale.Checked;
			this.scaleSelectorControl.Enabled = _rbScale.Checked;
			groupBox.Text = _rbScale.Checked ? SCALE : ARPEGGIO;
		}

		private void _rbArpeggio_CheckedChanged(object sender, EventArgs e)
		{
			this.chordSelectorControl.Visible = _rbArpeggio.Checked;
			this.chordSelectorControl.Enabled = _rbArpeggio.Checked;
			groupBox.Text = _rbArpeggio.Checked ? ARPEGGIO : SCALE;
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
					this.Item.Color = color;
					this.OnModelItemChanged();
				}
			}
		}
		private void ChordSelectorControl_SelectedChordChanged(object sender, ChordFormula chordFormula)
		{
			if (null != chordFormula.Root)
			{
				this.Item = new HarmonyModelItem(chordFormula);
				this.OnModelItemChanged();
			}
		}

		private void ScaleSelectorControl_SelectedScaleChanged(object sender, Eric.Morrison.Harmony.Scales.ScaleFormulaBase scaleFormula)
		{
			this.Item = new HarmonyModelItem(scaleFormula as INoteNameContainer);
			this.OnModelItemChanged();
		}
	}//class
}//ns
