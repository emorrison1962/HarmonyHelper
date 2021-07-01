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
	public partial class NewHarmonyItemDialog : Form
	{
		public HarmonyModelItem Item { get { return this.modelItemControl.Item; } }
		public NewHarmonyItemDialog()
		{
			InitializeComponent();
			this.Load += this.NewHarmonyItemDialog_Load;
			this.modelItemControl.ModelItemCreated += this.ModelItemControl_ModelItemCreated;

		}

		private void NewHarmonyItemDialog_Load(object sender, EventArgs e)
		{
			this._bnOk.Enabled = false;
			
		}

		private void ModelItemControl_ModelItemCreated(object sender, HarmonyModelItem e)
		{
			this._bnOk.Enabled = true;
		}

		private void _bnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void _bnOk_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}//class
}//ns
