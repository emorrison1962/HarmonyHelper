using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Scales;

using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NeckDiagrams
{
    public partial class ScaleSelectorControl : UserControl
    {
        public event EventHandler<ScaleFormulaBase> SelectedScaleChanged;
        public ScaleFormulaCatalog ScaleFormulaCatalog { get; private set; }
        public ScaleFormulaBase SelectedItem
        {
            get { return this._cbScaleType.SelectedItem as ScaleFormulaBase; }
            set
            {
                var items = this._cbScaleType.Items.Cast<ScaleFormulaBase>();
                var item = items.ToList()
                    .Where(x => x.Name == value.Name)
                    .First();
                this._cbScaleType.SelectedItem = item;
            }
        }

        public NoteName NoteName
        {
            get { return _scaleNoteNameCombo.SelectedNoteName; }
            set { _scaleNoteNameCombo.SelectedNoteName = value; }
        }

        #region Construction
        public ScaleSelectorControl()
        {
            InitializeComponent();
            this.Load += this.ScaleSelectorControl_Load;

        }

        private void ScaleSelectorControl_Load(object sender, EventArgs e)
        {
            _scaleNoteNameCombo.SelectionChanged += this._scaleNoteNameCombo_SelectionChanged;
            this._cbScaleType.SelectedValueChanged += this._cbScaleType_SelectedValueChanged;
            this._scaleNoteNameCombo.Enabled = true;
            this._cbScaleType.Enabled = false;
        }

        #endregion

        private void PopulateScaleFormulas(NoteName nn)
        {
            _cbScaleType.Items.Clear();
            var key = KeySignature.InternalCatalog.Where(x => x.NoteName == nn).First();

            this.ScaleFormulaCatalog = new ScaleFormulaCatalog(key);
            foreach (var scaleFormula in ScaleFormulaCatalog.Formulas
                .Where(x => x.Root == nn)
                .OrderBy(x => x.Name))
            {
                _cbScaleType.Items.Add(scaleFormula);
            }
        }

        private void _scaleNoteNameCombo_SelectionChanged(object sender, NoteName nn)
        {
            _cbScaleType.Enabled = true;
            PopulateScaleFormulas(_scaleNoteNameCombo.SelectedNoteName);
        }

        private void _cbScaleType_SelectedValueChanged(object sender, EventArgs e)
        {
            var scale = _cbScaleType.SelectedItem as ScaleFormulaBase;
            this.OnSelectedScaleChanged(scale);
        }

        void OnSelectedScaleChanged(ScaleFormulaBase scale)
        {

            if (null != this.SelectedScaleChanged)
                this.SelectedScaleChanged(this, scale);
        }
    }//class
}//ns
