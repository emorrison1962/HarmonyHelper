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


namespace NeckDiagrams
{
    public partial class ChordTypeSelectorControl : UserControl
    {
        public event EventHandler<ChordFormulaContext> ChordFolmulaChanged;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ChordFormula SelectedItem
        {
            get { return this._cbChordType.SelectedItem as ChordFormula; }
            set
            {
                if (null != value)
                {
                    var items = this._cbChordType.Items.Cast<ChordIntervalsEnum>();
                    var item = items.ToList()
                        .Where(x => x.Name() == value.ChordType.Name())
                        .First();
                    this._cbChordType.SelectedItem = item;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public NoteName NoteName
        {
            get { return _chordNoteNameCombo.SelectedNoteName; }
            set { _chordNoteNameCombo.SelectedNoteName = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ChordFormulaContext ChordFormulaContext { get; set; }

        #region Costruction
        public ChordTypeSelectorControl()
        {
            InitializeComponent();
            this.Load += this.ChordSelectorControl_Load;
        }

        void Init()
        {
            new object();
        }

        private void ChordSelectorControl_Load(object sender, EventArgs e)
        {
            _chordNoteNameCombo.SelectionChanged += this._chordNoteNameCombo_SelectionChanged;
            this._cbChordType.Enabled = false;
            if (!DesignMode)
            {
                this.PopulateChordFormulas();
            }
        }

        void PopulateChordFormulas()
        {
            this._cbChordType.Items.Clear();
            foreach (var chordType in ChordType.Catalog.OrderBy(x => x.Name()))
            {
                this._cbChordType.Items.Add(chordType);
            }
        }
        #endregion

        private void _chordNoteNameCombo_SelectionChanged(object sender, NoteName nn)
        {
            this._cbChordType.Enabled = true;
            this.OnSelectedChordChanged();
        }

        private void _cbChordType_SelectedValueChanged(object sender, EventArgs e)
        {
            var chordType = (ChordIntervalsEnum)_cbChordType.SelectedItem;
            this.OnSelectedChordChanged();
        }
#if false
        void OnSelectedChordChanged()
        {
            if (null != this.SelectedChordChanged)
            {
                if (null != _chordNoteNameCombo.SelectedNoteName
                    && null != _cbChordType.SelectedItem)
                {
                    var root = _chordNoteNameCombo.SelectedNoteName;
                    var chordType = (ChordIntervalsEnum)_cbChordType.SelectedItem;
                    var model = HarmonyHelper.IoC.Container.Resolve<IHarmonyModel>();
                    var result = ChordFormulaFactory.Get(root, chordType);
                    this.SelectedChordChanged(this, result);
                }
            }
        }
#endif
        void OnSelectedChordChanged()
        {

            if (null != _chordNoteNameCombo.SelectedNoteName
                && null != _cbChordType.SelectedItem
                && null != this.ChordFolmulaChanged)
            {
                var root = _chordNoteNameCombo.SelectedNoteName;
                var chordType = (ChordIntervalsEnum)_cbChordType.SelectedItem;
                var result = ChordFormulaFactory.Get(root, chordType);

                this.ChordFormulaContext = new ChordFormulaContext(result);
                this.ChordFolmulaChanged(this, this.ChordFormulaContext);
            }
        }


    }//class
}//ns
