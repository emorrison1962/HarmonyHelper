using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Scales;

namespace NeckDiagrams
{
	public partial class ModelItemControl : UserControl
	{
		public event EventHandler<HarmonyModelItem> ModelItemCreated;
		const string SELECT_ITEM_TYPE = "Select Item Type";
		const string ARPEGGIO = "Arpeggio";
		const string SCALE = "Scale";
		public HarmonyModelItem Item { get; private set; }
		public ScaleFormulaCatalog ScaleFormulaCatalog { get; private set; }

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
				this.ScaleFormulaCatalog = new ScaleFormulaCatalog(this.Model.KeySignature);
				this.Populate();
				if (null != this.Item)
				{
					if (ModelItemTypeEnum.Arpeggio == this.Item.ModelType)
					{
						_cbChordType.SelectedItem = Item.ChordFormula.ChordType;

						foreach (var cbi in _cbChordType.Items)
						{
							cbi.GetType();
							//Debug.WriteLine(cbi.)
						}
					}
					else
					{
						_cbScaleType.SelectedItem = Item.ScaleFormula;
					}
				}
			}
		}

		#endregion

		void Populate()
		{
			this.Populate_cbScaleType();
			this.Populate_cbChordType();
			this.Populate_cbRoot();
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
		void Populate_cbRoot()
		{
			this._cbRoot.Items.Clear();
			var set = KeySignature.Catalog
				.Select(x => x.NoteName)
				.ToList()
				.OrderBy(x => x)
				.ToHashSet(new NoteNameAphaEqualityComparer());
			
			foreach (var nn in set)
			{
				this._cbRoot.Items.Add(nn);
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
			this.Item = new HarmonyModelItem(_cbScaleType.SelectedItem as INoteNameContainer);
			this.OnModelItemCreated();
		}
		private void _cbChordType_SelectedValueChanged(object sender, EventArgs e)
		{
			var chordType = _cbChordType.SelectedItem as ChordType;
			var root = this._cbRoot.SelectedItem as NoteName;
			var formula = ChordFormulaFactory.Create(
				root, chordType, Model.KeySignature);

			this.Item = new HarmonyModelItem(formula);
			this.OnModelItemCreated();
		}

		void OnModelItemCreated()
		{
			if (null != this.ModelItemCreated)
				this.ModelItemCreated(this, this.Item);
		}
	}//class
}//ns
