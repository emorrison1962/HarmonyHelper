using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using NeckDiagrams.Controls;
using NeckDiagrams.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace NeckDiagrams.Views
{
    public partial class ChordShapeView : UserControl
    {
        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IChordShapeVM Model { get; set; }

        #endregion

        #region Construction
        public ChordShapeView()
        {
            InitializeComponent();
            this.Load += ChordShapeControl_Load;
        }

        private void ChordShapeControl_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        void Init()
        {
            this.InitModel();
            _ctlChordFormulaSelector.Model = this.Model;
        }

        void InitModel()
        {
            this.Model = HarmonyHelper.IoC.Container.Resolve<IChordShapeVM>();
            if (this.Model == null)
            {
                this.Model = new ChordShapeVM();
            }
            _ctlChordFormulaSelector.Model = this.Model;
            // Bind TextBox.Text to MyData.Name (Two-Way)
            this.DataBindings.Add("Model", this.Model, null, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        #endregion

        private void Model_ModelChanged(object sender, ChordShapeVM e)
        {
#warning can I swallow this?
            new object();
            //throw new NotImplementedException();
        }

        private void CtlChordTypeSelectorControl_ChordFolmulaChanged(object sender, object e)
        {
            throw new NotImplementedException();
            //this.Model.Set(e.ChordFormula);
        }

        void foo()
        {
            var dlg = new GuitarNeckSettingsDialog();
            var dr = dlg.ShowDialog();
        }

    }//class
}//ns
