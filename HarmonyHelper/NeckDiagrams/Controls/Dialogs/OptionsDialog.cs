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
                ColorContextCollection.LoadSettingsOrDefault();
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
            colorSelectorControl01.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Root);
            colorSelectorControl02.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Second);
            colorSelectorControl03.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Third);
            colorSelectorControl04.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Fourth);
            colorSelectorControl05.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Fifth);
            colorSelectorControl06.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Sixth);
            colorSelectorControl07.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Seventh);
        }

        private void TabColors_ControlAdded(object sender, ControlEventArgs e)
        {
            colorSelectorControl01.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Root);
            colorSelectorControl02.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Second);
            colorSelectorControl03.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Third);
            colorSelectorControl04.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Fourth);
            colorSelectorControl05.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Fifth);
            colorSelectorControl06.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Sixth);
            colorSelectorControl07.ColorContext = this.ColorContextCollection.Get(ChordFunctionEnum.Seventh);
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
        }


    }//class
}//ns
