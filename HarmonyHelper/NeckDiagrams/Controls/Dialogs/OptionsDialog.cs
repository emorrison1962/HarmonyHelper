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
        ColorContextCollection ColorContextCollection {  get; set; }

        public OptionsDialog()
        {
            InitializeComponent();
            this.Init();
        }
        
        private void Init()
        {
            this.InitColorContextCollection();
        }

        void InitColorContextCollection()
        {
            this.ColorContextCollection = ColorContextCollection.LoadSettingsOrDefault();

            colorSelectorControl01.ColorContext = this.ColorContextCollection.Get(IntervalRoleTypeEnum.Root);
            colorSelectorControl02.ColorContext = this.ColorContextCollection.Get(IntervalRoleTypeEnum.Second);
            colorSelectorControl03.ColorContext = this.ColorContextCollection.Get(IntervalRoleTypeEnum.Third);
            colorSelectorControl04.ColorContext = this.ColorContextCollection.Get(IntervalRoleTypeEnum.Fourth);
            colorSelectorControl05.ColorContext = this.ColorContextCollection.Get(IntervalRoleTypeEnum.Fifth);
            colorSelectorControl06.ColorContext = this.ColorContextCollection.Get(IntervalRoleTypeEnum.Sixth);
            colorSelectorControl07.ColorContext = this.ColorContextCollection.Get(IntervalRoleTypeEnum.Seventh);
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
