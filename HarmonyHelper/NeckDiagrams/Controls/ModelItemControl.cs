using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using System;
using System.Diagnostics;
using System.Linq;
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
			this.Item = new HarmonyModelItem();
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
				this.Model.ModelChanged += this.Model_ModelChanged;
				this.Populate();

				this.chordSelectorControl.SelectedChordChanged += this.ChordSelectorControl_SelectedChordChanged;

				this.scaleSelectorControl.SelectedScaleChanged += this.ScaleSelectorControl_SelectedScaleChanged;

			}
		}

		private void Model_ModelChanged(object sender, HarmonyModel model)
		{
			if (null != this.Item)
			{
				if (model.Items.Any(x => x == this.Item))
				{
					
					this.Refresh();
				}
			}
		}

		#endregion

		void Populate()
		{
			if (null != this.Item)
			{

				if (this.Item.IsValid)
				{
					this._colorSwatch.BackColor = this.Item.Color;


					if (this.Item.ModelType == ModelItemTypeEnum.Arpeggio)
					{
						chordSelectorControl.Visible = true;
						chordSelectorControl.NoteName = this.Item.ChordFormula.Root;
						chordSelectorControl.SelectedItem = Item.ChordFormula;
					}
					else
					{
						scaleSelectorControl.Visible = true;
						scaleSelectorControl.NoteName = this.Item.ScaleFormula.Root;
						scaleSelectorControl.SelectedItem = Item.ScaleFormula;
					}
				}
			}
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
				this.Item.ChordFormula = chordFormula;
				this.OnModelItemChanged();
			}
		}

		private void ScaleSelectorControl_SelectedScaleChanged(object sender, Eric.Morrison.Harmony.Scales.ScaleFormulaBase scaleFormula)
		{
			this.Item.ScaleFormula = scaleFormula;
			this.OnModelItemChanged();
		}
	}//class
}//ns
