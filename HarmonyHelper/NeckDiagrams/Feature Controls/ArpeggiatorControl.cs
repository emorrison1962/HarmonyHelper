using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NeckDiagrams.Controls
{
    public partial class ArpeggiatorControl : UserControl
    {
        #region Properties
        ArpeggiatorCreationContext CreationContext { get; set; } = new ArpeggiatorCreationContext();
        Arpeggiator Arpeggiator { get; set; }
        List<ChordFormulaVM> ChordFormulaVMs { get; set; }

        #endregion

        #region Construction
        public ArpeggiatorControl()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        #endregion
        private void _bnChords_Click(object sender, EventArgs e)
        {
            var dlg = new ChordParserDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                this.ChordFormulaVMs = dlg.ChordFormulaVMs;
            }
        }

        void CreateArpeggiator()
        {
            if (this.CreationContext.TryCreateArpeggiator(out var arpeggiator))
            {
                this.Arpeggiator = arpeggiator;
                new object();
            }
        }

        private void _cbUntilPatternRepeats_CheckedChanged(object sender, EventArgs e)
        {
            this.CreationContext.UntilPatternRepeats = _cbUntilPatternRepeats.Checked;
        }

        private void _rbAscending_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbAscending.Checked)
                this.CreationContext.Direction |= DirectionEnum.Ascending;
            else
                this.CreationContext.Direction &= DirectionEnum.Ascending;
        }

        private void _rbDescending_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbDescending.Checked)
                this.CreationContext.Direction |= DirectionEnum.Descending;
            else
                this.CreationContext.Direction &= DirectionEnum.Descending;
        }

        private void _cbTemporaryReversal_CheckedChanged(object sender, EventArgs e)
        {
            this.CreationContext.TemporaryReversal = _cbTemporaryReversal.Checked;
        }

        private void _comboNoteRange_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _comboNeckPosition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _numericNotesPerMeasure_ValueChanged(object sender, EventArgs e)
        {
            this.CreationContext.BeatsPerMeasure = (int)_numericNotesPerMeasure.Value;
        }

    }//class

    class ArpeggiatorCreationContext
    {
        public List<Chord> Chords { get; set; }
        public List<ArpeggiationChordContext> ChordContexts { get; set; }
        public NoteRange NoteRange { get; set; } = new FiveStringBassRange(FiveStringBassPositionEnum.FirstPosition);
        public int BeatsPerMeasure { get; set; }
        public DirectionEnum Direction { get; set; } = DirectionEnum.Ascending | DirectionEnum.AllowTemporayReversalForCloserNote;
        public bool UntilPatternRepeats { get; set; }
        public bool TemporaryReversal { get; set; }

        public bool IsValid()
        {
            var result = false;
            if (this.Chords.Any()
                && this.ChordContexts.Any()
                && this.NoteRange.IsValid()
                && this.BeatsPerMeasure > 0
                && this.Direction.HasFlag(DirectionEnum.Ascending) || this.Direction.HasFlag(DirectionEnum.Descending)
                )
            {
                result = true;
            }
            return result;
        }

        public bool TryCreateArpeggiator(out Arpeggiator arpeggiator)
        {
            arpeggiator = null;
            var result = this.IsValid();
            if (result)
            {
                arpeggiator = new Arpeggiator(this.ChordContexts,
                    this.Direction,
                    this.NoteRange,
                    this.BeatsPerMeasure,
                    null,
                    this.UntilPatternRepeats);
            }
            return result;
        }

    }//class

}//ns
