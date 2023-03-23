using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        Part Part { get; set; }
        MusicXmlModel Model { get; set; }

        void LoadMusicXml()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "xml files (*.xml)|*.xml|musicxml files (*.musicxml)|*.musicxml|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        var importer = new MusicXmlImporter();
                        this.Model = importer.Import(filePath);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }        
        }

        [Obsolete("", true)]
        void CreatePart() 
        {
            this.Part = new Part(PartTypeEnum.Melody,
                new MusicXmlPartIdentifier("P1", "Bass"), ClefEnum.Bass);
        }

        [Obsolete("", true)]
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

        private void _bnOpen_Click(object sender, EventArgs e)
        {
            this.LoadMusicXml();
        }
    }//class
}//ns
