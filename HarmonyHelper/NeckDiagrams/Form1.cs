using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

namespace NeckDiagrams
{
	public partial class Form1 : Form, IModelProvider
	{
		public event EventHandler<HarmonyModel> ModelChanged;
		ScaleFormulaCatalog ScaleFormulaCatalog { get; set; }

		public HarmonyModel Model { get; private set; } = new HarmonyModel();

		public Form1()
		{
			InitializeComponent();
			this.Load += this.Form1_Load;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			foreach (var key in KeySignature.Catalog.OrderBy(x => x.NoteName))
			{
				_cbKey.Items.Add(key);
			}
			_cbKey.SelectedItem = this._cbKey.Items.Cast<KeySignature>()
				.First(x => x == KeySignature.AMinor);

			this.ScaleFormulaCatalog = new ScaleFormulaCatalog(KeySignature.AMinor);
			this.Populate_cbScaleType();


			this.Populate_cbChordType();

			_cbScaleType.DropDownWidth = _cbScaleType.Items.Cast<ScaleFormulaBase>()
				.Max(x => TextRenderer.MeasureText(x.ToString(), _cbScaleType.Font).Width);
		}

		private void Populate_cbChordType()
		{
			this._cbChordType.Items.Clear();

			foreach (var formula in ChordType.Catalog.OrderBy(x => x.Name))
			{
				this._cbChordType.Items.Add(formula);
			}
			
		}

		void OnModelChanged()
		{
			if (this.Model.IsValid)
			{
				if (null != this.ModelChanged)
				{
					this.ModelChanged(this, this.Model);
				}
			}
		}
		private void _cbKey_SelectedValueChanged(object sender, EventArgs e)
		{
			this.Model.KeySignature = _cbKey.SelectedItem as KeySignature;
			this.ScaleFormulaCatalog = new ScaleFormulaCatalog(this.Model.KeySignature);
			this.Populate_cbScaleType();
			this.OnModelChanged();
		}

		void Populate_cbScaleType()
		{
			_cbScaleType.Items.Clear();

			foreach (var st in ScaleFormulaCatalog.Formulas
				.Where(x => x.Root == Model.KeySignature.NoteName)
				.OrderBy(x => x.Name))
			{
				_cbScaleType.Items.Add(st);
			}
		}

		private void _cbScaleType_SelectedValueChanged(object sender, EventArgs e)
		{
			this.Model.ScaleFormula = _cbScaleType.SelectedItem as ScaleFormulaBase;
			this.OnModelChanged();
		}

		private void _cbScale_CheckedChanged(object sender, EventArgs e)
		{
			if (_cbScale.Checked)
				Model.ModelType |= ModelTypeEnum.Scale;
			else
				Model.ModelType ^= ModelTypeEnum.Scale;
		}

		private void _cbArpeggio_CheckedChanged(object sender, EventArgs e)
		{
			if (_cbArpeggio.Checked)
				Model.ModelType |= ModelTypeEnum.Arpeggio;
			else
				Model.ModelType ^= ModelTypeEnum.Arpeggio;
		}


		private void _cbChordType_SelectedValueChanged(object sender, EventArgs e)
		{
			var chordType = _cbChordType.SelectedItem as ChordType;
			var formula = ChordFormulaFactory.Create(
				Model.KeySignature.NoteName, chordType, Model.KeySignature);
			this.Model.ChordFormula = formula;
			this.OnModelChanged();
		}
	}//class
}//ns
