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
        IChordShapeVM Model { get; set; }
        public ChordShapeView()
        {
            this.InitModel();
            InitializeComponent();
            this.Load += ChordShapeControl_Load;
        }

        void InitModel()
        {
            this.Model = HarmonyHelper.IoC.Container.Resolve<IChordShapeVM>();
            if (this.Model == null)
            {
                throw new ArgumentNullException("model");
            }
            // Bind TextBox.Text to MyData.Name (Two-Way)
            this.DataBindings.Add("Text", this.Model, "modelPropName", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void Model_ModelChanged(object sender, ChordShapeVM e)
        {
#warning can I swallow this?
            new object();
            //throw new NotImplementedException();
        }


        private void ChordShapeControl_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void CtlChordTypeSelectorControl_ChordFolmulaChanged(object sender, object e)
        {
            throw new NotImplementedException();
            //this.Model.Set(e.ChordFormula);
        }

        void Init()
        {
        }

        void foo()
        {
            var dlg = new GuitarNeckSettingsDialog();
            var dr = dlg.ShowDialog();
        }

    }//class
}//ns
