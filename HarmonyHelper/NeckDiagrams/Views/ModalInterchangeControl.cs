using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeckDiagrams.Controls
{
    public partial class ModalInterchangeControl : UserControl
    {
        public ModalInterchangeControl()
        {
            InitializeComponent();
        }

        public List<ChordFormulaVM> ChordFormulaVMs { get; private set; } = new List<ChordFormulaVM>();
        public List<HarmonicAnalysisResult> Results { get; private set; }

        private void bnChords_Click(object sender, EventArgs e)
        {
            var dlg = new ChordParserDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                this.ChordFormulaVMs = dlg.ChordFormulaVMs;
                this.Populate();
                this.Analyze();
            }
        }

        private void Populate()
        {
            //this._chordNamesControl.AddRange(this.ChordFormulaVMs, this);
        }

        void PopulateListView()
        {
            foreach (var result in this.Results)
            {
                var lvi = new ListViewItem(result.Rule.Name);
                lvi.Tag = result;
                lvi.ToolTipText = result.Rule.Description;
                this.lvAnalysis.Items.Add(lvi);
            }
        }

        void Analyze()
        {
            var analyzer = new HarmonicAnalyzer();
            this.Results = analyzer.Analyze(
                this.ChordFormulaVMs.Select(x => x.ChordFormula)
                    .ToList());
            this.PopulateListView();
        }

        private void lvAnalysis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvAnalysis.SelectedItems.Count > 0)
            {
                var item = this.lvAnalysis.SelectedItems[0];
                this.tbDetails.Text = (item.Tag as HarmonicAnalysisResult).Message;
                this.OnSelectedIndexChanged(item.Tag as HarmonicAnalysisResult);
            }
        }

        private void OnSelectedIndexChanged(HarmonicAnalysisResult harmonicAnalysisResult)
        {
            if (null != this.AnalysisResultChanged)
            {
                this.AnalysisResultChanged(this,
                    new AnalysisResultEventArgs(harmonicAnalysisResult));
            }
        }

        public class AnalysisResultEventArgs : EventArgs
        {
            public HarmonicAnalysisResult Result { get; protected set; }
            public AnalysisResultEventArgs(HarmonicAnalysisResult Result)
            {
                this.Result = Result;
            }
        }
        public event EventHandler<AnalysisResultEventArgs> AnalysisResultChanged;
    }//class
}//ns
