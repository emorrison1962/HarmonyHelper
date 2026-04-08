using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;

using HarmonyHelper.Chords.NegativeHarmony;

using Manufaktura.Controls.Model;

namespace NeckDiagrams.Controls
{
    public partial class SquareOfStichGridControl : UserControl
    {
        #region Properties
        KeySignature Key { get; set; } = KeySignature.CMajor;
        CircleOf CircleOfFifths { get; set; }
        HashSet<ChordNameControl> ChordNameControls { get; set; } = new HashSet<ChordNameControl>();

        #endregion

        #region Construction
        public SquareOfStichGridControl()
        {
            InitializeComponent();
        }

        #endregion

        async Task InitAsync()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(() => this.InitAsync());
            }
            else
            {

                this.SuspendLayout();
                this._tlpChords.SuspendLayout();

                var t = await this.Init();

                this._tlpChords.ResumeLayout(true);
                this.ResumeLayout(false);
            }
        }

        async Task<bool> Init()
        {
            this.ChordNameControls.Clear();
            this._tlpChords.Controls.Clear();

            await Task.Run(() => this.CircleOfFifths = new CircleOf(Interval.Perfect4th, this.Key.NoteName, this.Key.IsMajor));
            int ndxRow = 0;
            foreach (var key in this.CircleOfFifths.Keys)
            {
                var row = await Task.Run(() => this.CreateHarmonizedMajorScale(key));
                List<ChordNameControl> controls = new List<ChordNameControl>();
                //foreach (var formula in row.Chords.OrderBy(x=> x.NameAscii))
                foreach (var formula in row.Chords)
                {
                    controls.Add(await this.CreateControl(formula));
                }
                for (int i = 0; i < controls.Count; ++i)
                {
                    var ctl = controls[i];
                    this.AddControl(i, ndxRow, ctl);
                }
                ++ndxRow;
            }

            return true;
        }

        ModalInterchangeGridRow CreateHarmonizedMajorScale(KeySignature inputKey)
        {
            var chordTypes = new List<ChordIntervalsEnum>() { //harmonized major scale
				ChordIntervalsEnum.Major,
                ChordIntervalsEnum.Minor,
                ChordIntervalsEnum.Minor,
                ChordIntervalsEnum.Major,
                ChordIntervalsEnum.Major,
                ChordIntervalsEnum.Minor,
                ChordIntervalsEnum.Diminished
            };

            var chordTypeNdx = 0;
            var mode = ModeEnum.Ionian;

            var scale = new MajorModalScaleFormula(inputKey, mode);
            List<int> scaleDegreeNdxs = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
            var result = new ModalInterchangeGridRow(inputKey, scale.ModeName);

            foreach (var scaleDegreeNdx in scaleDegreeNdxs)
            {
                var chordType = chordTypes.NextOrFirst(ref chordTypeNdx);
                var formula = ChordFormula.Catalog
                    .Where(x => x.Root == scale.NoteNames[scaleDegreeNdx]
                        && x.ChordType == chordType)
                    .FirstOrDefault();

                result.Add(formula ?? ChordFormula.Empty);
            }

            chordTypes.NextOrFirst(ref chordTypeNdx); //create an offset

            return result;
        }

        public async Task<ChordNameControl> CreateControl(ChordFormula formula = null)
        {
            if (null == formula)
                throw new ArgumentNullException(nameof(formula));

            var vm = new ChordFormulaVM(formula);
            var result =
                await Task.Run(() => new ChordNameControl(vm)
                {
                    AutoSize = true,
                    Dock = System.Windows.Forms.DockStyle.Fill,
                    Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold),
                    Location = new System.Drawing.Point(3, 1),
                    Margin = new System.Windows.Forms.Padding(2, 0, 2, 0),
                    Name = "label1",
                    Size = new System.Drawing.Size(46, 19),
                    TabIndex = 0,
                    Text = formula.NameAscii,
                    //TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                });

            result.Selected += ChordNameControl_Selected;
            this.ChordNameControls.Add(result);
            result.SuspendLayout();

            Debug.Assert(null != result);
            return result;
        }

        public void AddControl(int colNdx, int rowNdx, ChordNameControl ctl)
        {
            const int ZERO = 0;
            if (colNdx < ZERO || colNdx > this._tlpChords.ColumnCount)
                throw new ArgumentOutOfRangeException(nameof(colNdx));
            if (rowNdx < ZERO || rowNdx > this._tlpChords.RowCount)
                throw new ArgumentOutOfRangeException(nameof(rowNdx));

            this.BeginInvoke(() =>
                this._tlpChords.Controls.Add(ctl, colNdx, rowNdx));
        }

        public void ChordNameControl_Selected(object sender, ChordNameControl e)
        {
            var seq = this.ChordNameControls.Where(x =>
                x.ChordFormula.ChordFormula.Root.NameAscii[0]
                    .Equals(e.ChordFormula.ChordFormula.Root.NameAscii[0]));

            foreach (var ctl in seq.ToList())
            {
                ctl.IsSelected = e.IsSelected;
            }
        }

        async private void keySignatureCombo1_KeySignatureChanged(object sender, KeySignature e)
        {
            this.Key = e;

            Task.Run(() => this.InitAsync());
        }

    }//class
}//ns




