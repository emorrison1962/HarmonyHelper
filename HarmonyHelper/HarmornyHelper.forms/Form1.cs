using System;
using System.Windows.Forms;

namespace HarmornyHelper.forms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			_bnScales.Checked = true;
		}

		private void _bnIntervals_CheckedChanged(object sender, EventArgs e)
		{
			this._contentPanel.Controls.Clear();
			if (_bnIntervals.Checked)
			{
				this._contentPanel.Controls.Add(new IntervalsControl());
			}
		}

		private void _bnScales_CheckedChanged(object sender, EventArgs e)
		{
			this._contentPanel.Controls.Clear();
			if (_bnScales.Checked)
			{
				this._contentPanel.Controls.Add(new ScalesControl());
			}
		}

		private void _bnChords_CheckedChanged(object sender, EventArgs e)
		{
			this._contentPanel.Controls.Clear();
			if (_bnChords.Checked)
			{
				this._contentPanel.Controls.Add(new ChordsControl());
			}
		}

		private void _bnArpeggios_CheckedChanged(object sender, EventArgs e)
		{
			this._contentPanel.Controls.Clear();
			if (_bnArpeggios.Checked)
			{
				this._contentPanel.Controls.Add(new ArpeggiosControl());
			}
		}

		private void _bnAnalysis_CheckedChanged(object sender, EventArgs e)
		{
			this._contentPanel.Controls.Clear();
			if (_bnAnalysis.Checked)
			{
				this._contentPanel.Controls.Add(new AnalysisControl());
			}
		}
	}
}
