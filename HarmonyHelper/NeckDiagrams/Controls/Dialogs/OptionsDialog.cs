using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Eric.Morrison.Harmony;

using NeckDiagrams.Domain;

namespace NeckDiagrams.Controls
{
    public partial class OptionsDialog : Form
    {
        ColorContextCollection colorContextCollection;
        ColorContextCollection ColorContextCollection
        {
            get
            {
                return colorContextCollection;
            }
            set
            {
                this.colorContextCollection = value;
            }
        }


        public OptionsDialog()
        {
            this.Init();
            InitializeComponent();
            this.Load += OptionsDialog_Load;
            this.tabColors.ControlAdded += TabColors_ControlAdded;
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {
            ctlRoot.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Root);
            ctlSecond.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Second);
            ctlThird.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Third);
            ctlFourth.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Fourth);
            ctlFifth.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Fifth);
            ctlSixth.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Sixth);
            ctlSeventh.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Seventh);
            ctlNinth.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Ninth);
            ctlEleventh.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Eleventh);
            ctlThirteenth.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Thirteenth);
        }

        private void TabColors_ControlAdded(object sender, ControlEventArgs e)
        {
            ctlRoot.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Root);
            ctlSecond.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Second);
            ctlThird.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Third);
            ctlFourth.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Fourth);
            ctlFifth.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Fifth);
            ctlSixth.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Sixth);
            ctlSeventh.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Seventh);
            ctlNinth.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Ninth);
            ctlEleventh.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Eleventh);
            ctlThirteenth.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Thirteenth);
        }

        private void Init()
        {
            this.InitColorContextCollection();
        }

        void InitColorContextCollection()
        {
            this.ColorContextCollection = ColorContextCollection.LoadSettingsOrDefault();
        }

        void bnCancel_Click(object sender, EventArgs e)
        {
        }

        void bnOK_Click(object sender, EventArgs e)
        {
            ColorContextCollection.SaveToSettings(this.ColorContextCollection);

            var coll = ctlGuitarStrings.GuitarStringCollection;
            GuitarStringCollection.SaveToSettings(coll);
        }


    }//class
}//ns
