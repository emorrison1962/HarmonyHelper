using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Manufaktura.Controls.Model;
using NeckDiagrams.Domain;


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
            //Debug.WriteLine($"+{MethodBase.GetCurrentMethod().Name}");
            this.Load += this.ChordSelectorControl_Load;
            InitializeComponent();
            //Debug.WriteLine($"-{MethodBase.GetCurrentMethod().Name}");
        }

        private void ChordSelectorControl_Load(object sender, EventArgs e)
        {
            //Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}");
            _chordNoteNameCombo.SelectionChanged += this._chordNoteNameCombo_SelectionChanged;
            Init();
            this._cbChordType.Enabled = false;
            if (!DesignMode)
            {
                this.PopulateChordFormulas();
            }
            //Debug.WriteLine($"-{MethodBase.GetCurrentMethod().Name}");
        }

        void Init()
        {
            if (this.Model == null)
            {
                this.Model = HarmonyHelper.IoC.Container.Resolve<IChordShapeVM>();

            }
            // Bind TextBox.Text to MyData.Name (Two-Way)
            this.DataBindings.Add("Model", this.Model, null, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        void PopulateChordFormulas()
        {
            this._cbChordType.Items.Clear();
            //foreach (var chordType in ChordType.Catalog.OrderBy(x => x.Name()))

            //var keySelector = Func<TSource, TKey> 
            //var x = ChordType.Catalog.OrderBy()
            var ordered = ChordType.Catalog.OrderBy(x => x);
            foreach (var chordType in ordered)
            {
                this._cbChordType.Items.Add(chordType);
            }
        }

        public static Func<TSource, TKey> BuildKeySelector<TSource, TKey>(string propertyName)
        {
            // A simple reflection-based (less efficient) approach
            return obj => (TKey)typeof(TSource).GetProperty(propertyName).GetValue(obj);

            // A more efficient approach involves using Expression trees (see Microsoft Learn or Stack Overflow links for details)
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

        void OnSelectedChordChanged()
        {

            if (null != _chordNoteNameCombo.SelectedNoteName
                && null != _cbChordType.SelectedItem)
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
            }
        }


    }//class
}//ns
