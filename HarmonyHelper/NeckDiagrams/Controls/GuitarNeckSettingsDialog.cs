using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Eric.Morrison.Harmony;

using Microsoft.VisualBasic.Logging;

using NeckDiagrams.Domain;
using NeckDiagrams.Properties;

using Newtonsoft.Json;

namespace NeckDiagrams.Controls
{
    public partial class GuitarNeckSettingsDialog : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GuitarStringCollection GuitarStringCollection { get; set; } = null;

        public GuitarNeckSettingsDialog()
        {
            InitializeComponent();
            this.Init();
            this.Load += GuitarNeckSettingsDialog_Load;
        }

        private void GuitarNeckSettingsDialog_Load(object sender, EventArgs e)
        {
            this.ctlGuitarStrings.Set(this.GuitarStringCollection);
        }

        void Init()
        {
            this.GuitarStringCollection = GuitarStringCollection.LoadSettingsOrDefault();
        }

        private void bnOK_Click(object sender, EventArgs e)
        {
            var coll = this.ctlGuitarStrings.GuitarStringCollection;
            this.Close();
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            GuitarStringCollection.SaveToSettings(this.GuitarStringCollection);
            this.Close();
        }
    }//class
}//ns
