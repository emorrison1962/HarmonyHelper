using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Eric.Morrison.Harmony;

namespace NeckDiagrams
{
	public partial class Form1 : Form, IModelProvider
	{
		public event EventHandler<HarmonyModel> ModelChanged;
		ScaleFormulaCatalog ScaleFormulaCatalog { get; set; }

		public HarmonyModel Model { get; private set; }

		public Form1()
		{
			InitializeComponent();
			var defaultKey = KeySignature.CMajor;
			this.Model = new HarmonyModel(defaultKey);

			this.Load += this.Form1_Load;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			foreach (var key in KeySignature.Catalog.OrderBy(x => x.NoteName))
			{
				_cbKey.Items.Add(key);
			}

			var defaultKey = KeySignature.CMajor;
			_cbKey.SelectedItem = this._cbKey.Items.Cast<KeySignature>()
				.First(x => x == defaultKey);
			this.Model = new HarmonyModel(defaultKey);
			this.ScaleFormulaCatalog = new ScaleFormulaCatalog(defaultKey);

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
			this.OnModelChanged();
		}


		private void _cbScale_CheckedChanged(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			//if (_cbScale.Checked)
			//	Model.ModelType |= ModelItemTypeEnum.Scale;
			//else
			//	Model.ModelType ^= ModelItemTypeEnum.Scale;
		}

		private void _cbArpeggio_CheckedChanged(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			//if (_cbArpeggio.Checked)
			//	Model.ModelType |= ModelItemTypeEnum.Arpeggio;
			//else
			//	Model.ModelType ^= ModelItemTypeEnum.Arpeggio;
		}


		private void _cbChordType_SelectedValueChanged(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			//var chordType = _cbChordType.SelectedItem as ChordType;
			//var formula = ChordFormulaFactory.Create(
			//	Model.KeySignature.NoteName, chordType, Model.KeySignature);
			//this.Model.ChordFormula = formula;
			//this.OnModelChanged();
		}

		private void _bnAddItem_Click(object sender, EventArgs e)
		{
			var dlg = new NewHarmonyItemDialog();
			var dr = dlg.ShowDialog();
			if (dr == DialogResult.OK)
			{
				Model.Add(dlg.Item);
			}
		}
	}//class
}//ns
