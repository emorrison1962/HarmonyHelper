using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using NeckDiagrams.Domain;
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
    public partial class ChordFormulaSelectorControl : UserControl
    {
        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IChordShapeVM Model { get; set; }

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

        #endregion

        #region Costruction
        public ChordFormulaSelectorControl()
        {
            InitializeComponent();
            this.Load += this.ChordSelectorControl_Load;
        }

        private void ChordSelectorControl_Load(object sender, EventArgs e)
        {
            _chordNoteNameCombo.SelectionChanged += this._chordNoteNameCombo_SelectionChanged;
            Init();
            this._cbChordType.Enabled = false;
            if (!DesignMode)
            {
                this.PopulateChordFormulas();
            }
        }

        void Init()
        {
            InitModel();
            _chordNoteNameCombo.SelectedNoteName = NoteName.C;
        }

        void InitModel()
        {
#if false
            if (this.Model == null)
            {
                throw new NotImplementedException();
            }
            // Bind TextBox.Text to MyData.Name (Two-Way)
            this.DataBindings.Add("Model", this.Model, null, true, DataSourceUpdateMode.OnPropertyChanged);

#endif        
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
                && null != _cbChordType.SelectedItem)
                //&& null != this.ChordFolmulaChanged)
            {
                var root = _chordNoteNameCombo.SelectedNoteName;
                var chordType = (ChordIntervalsEnum)_cbChordType.SelectedItem;


                try
                {
                    var result = ChordFormulaFactory.Get(root, chordType);

                    this.Model.ChordFormula = result;

                }
                catch (Exception)
                {

                    throw;
                }               
                
                //this.ChordFormulaContext = new ChordFormulaContext(result);
                //this.ChordFolmulaChanged(this, this.ChordFormulaContext);
            }
        }


    }//class
}//ns
