using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison.Harmony.MusicXml;

namespace NeckDiagrams.Controls
{
    public partial class ReHarmonizerControl : UserControl
    {
        #region Construction
        public ReHarmonizerControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        #endregion

        MusicXmlPart Part { get; set; }
        MusicXmlModel Model { get; set; }
        void CreatePart() 
        {
            this.Part = new MusicXmlPart(PartTypeEnum.Melody,
                new MusicXmlPartIdentifier("P1", "Bass"), ClefEnum.Bass);
        }

        void CreateModel()
        {
            var isValid = this.Part.IsValid();
            Debug.Assert(isValid);

            var result = new MusicXmlModel();
            result.Add(this.Part);

            isValid = result.IsValid();
            Debug.Assert(isValid);

            this.Model = result;
        }
    }//class
}//ns
