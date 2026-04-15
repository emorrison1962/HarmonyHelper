using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using Eric.Morrison.Harmony;

using Manufaktura.Controls.Model;

using NeckDiagrams.Controls;
using NeckDiagrams.Views;

namespace NeckDiagrams
{
    public partial class Form1 : Form
    {
        //public event EventHandler<HarmonyModel> ModelChanged;
        ScaleFormulaCatalog ScaleFormulaCatalog { get; set; }

        public Form1()
        {
            InitializeComponent();

            this.Load += this.Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                //this.ShowGuitarNeckSettingsDialog();
                this._ctlNav.SelectedFeatureTypeChanged += this.SelectedFeatureChanged;
                //_ctlNav.SelectedFeatureType = FeatureType.ChordFingering;
                _ctlNav.SelectedFeatureType = FeatureType.SquareOfStitch;
                _ctlNav.Init();

            }
        }

        [Obsolete("", true)]
        void ShowGuitarNeckSettingsDialog()
        {
            var dlg = new GuitarNeckSettingsDialog();
            dlg.ShowDialog();
        }

        private void SelectedFeatureChanged(object sender, FeatureType e)
        {
            //Debug.WriteLine(e.ToString());
            var featureView = new FeatureViewFactory().CreateView(e);
            this.AddControl(featureView);
        }


        //void OnModelChanged()
        //{
        //	if (this.Model.IsValid)
        //	{
        //		if (null != this.ModelChanged)
        //		{
        //			this.ModelChanged(this, this.Model);
        //		}
        //	}
        //}
        private void _cbKey_SelectedValueChanged(object sender, EventArgs e)
        {
            //this.Model.KeySignature = _cbKey.SelectedItem as KeySignature;
            //this.ScaleFormulaCatalog = new ScaleFormulaCatalog(this.Model.KeySignature);
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

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //neckPanel.Padding = new Padding(20, neckPanel.Height / 4,
            //	20, neckPanel.Height / 4);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.Refresh();
            }

            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                //this.printDialog.Document = _neckCtl.PrintDocument;
                var dr = this.printDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    this.printDialog.Document.Print();
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.Refresh();
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var pa = e.PrintAction;
            new object();
        }

        private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            new object();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            new object();

        }

        private void printDocument1_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {
            new object();

        }

        private void _cbScale_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            //if (_cbScale.Checked)
            //Model.ModelType |= ModelItemTypeEnum.Scale;
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

        Control CurrentView { get; set; }
        void AddControl(Control ctl)
        {
            if (this.CurrentView is not null)
                this._pnlFeatureView.Controls.Remove(this.CurrentView);

            ctl.Dock = DockStyle.Fill;
            this._pnlFeatureView.Controls.Add(ctl);
            this.CurrentView = ctl;
            this.Invalidate(true);
        }

        private void _ctlNav_Load(object sender, EventArgs e)
        {
        }
    }//class

    class FeatureViewFactory
    {
        internal Control CreateView(FeatureType e)
        {
            Control result = null;
            switch (e)
            {
                case FeatureType.None:
                    { }
                    break;
                case FeatureType.VoiceLeading: { result = new VoiceLeadingControl(); } break;
                case FeatureType.ChordFingering: { result = new ChordShapeView(); } break;
                case FeatureType.Arpeggiator: { result = new ArpeggiatorControl(); } break;
                case FeatureType.Manufaktura: { result = new ManufakturaScratchPadControl(); } break;
                case FeatureType.Arpeggios: { result = new ArpeggiosControl(); } break;
                case FeatureType.HarmonicAnalysis: { result = new HarmonicAnalysisControl(); } break;
                case FeatureType.LeadSheets: { result = new LeadSheetControl(); } break;
                case FeatureType.ModalInterchange: { result = new ModalInterchangeView(); } break;
                case FeatureType.ReHarmonize: { result = new ReHarmonizerControl(); } break;
                case FeatureType.Scales: { result = new ScalesControl(); } break;
                case FeatureType.SquareOfStitch: { result = new SquareOfStichView(); } break;
                case FeatureType.SandBox: { result = new SandBoxView(); } break;
                default: { throw new ArgumentOutOfRangeException(nameof(e)); }
            }
            //Debug.WriteLine(result.GetType().Name);
            return result;
        }
    }
}//ns
