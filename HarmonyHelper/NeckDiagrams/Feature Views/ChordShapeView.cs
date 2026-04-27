using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using NeckDiagrams.Controls;
using NeckDiagrams.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            //Debug.WriteLine($"+{MethodBase.GetCurrentMethod().Name}");
            this.Init();
            this.Load += ChordShapeControl_Load;
            InitializeComponent();
            //Debug.WriteLine($"-{MethodBase.GetCurrentMethod().Name}");
        }

        private void ChordShapeControl_Load(object sender, EventArgs e)
        {
            //Debug.WriteLine($"+{MethodBase.GetCurrentMethod().Name}");
            //Debug.WriteLine($"-{MethodBase.GetCurrentMethod().Name}");
        }

        void Init()
        {
            this.BootstrapModel();
            this.DataBindings.Add("Model", this.Model, null, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        void BootstrapModel()
        {
            this.Model = HarmonyHelper.IoC.Container.Resolve<IChordShapeVM>();
            if (this.Model == null)
            {
                this.Model = new ChordShapeVM();
            }
            HarmonyHelper.IoC.Container.Register<IChordShapeVM>(this.Model);
            
            var colors = ColorContextCollection.LoadSettingsOrDefault();
            HarmonyHelper.IoC.Container.Register<IColorContextCollection>(colors);
        }

        #endregion

    }//class
}//ns
