using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using Manufaktura.Controls.Linq;

namespace NeckDiagrams.Feature_Controls
{
    public partial class ManufakturaSandboxControl : UserControl
    {
        public ManufakturaSandboxControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var doc = XDocument.Load(@"C:\temp\Effendi MusicXml Files\I\AllBlues 1.xml");
            var score = doc.ToScore();

            _noteViewer.DataSource = score;
            var size = _noteViewer.Size;
            _noteViewer.Scale(new SizeF(11000, 11000));
            _noteViewer.Refresh();
            var size2 = _noteViewer.Size;

            //SizeF shadowSize = listBox1.Size;
            //SizeF addSize = new SizeF(10.5F, 20.8F);

            //// Add them together and save the result in shadowSize.
            //shadowSize = shadowSize + addSize;

        }

    }//class
}//ns
