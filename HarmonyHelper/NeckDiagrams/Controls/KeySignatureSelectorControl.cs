using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison.Harmony;

namespace NeckDiagrams.Controls
{
    public partial class KeySignatureSelectorControl : UserControl
    {
        public KeySignatureSelectorControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            foreach (var key in KeySignature.Catalog)
            {
                this._combo.Items.Add(key);
            }
        }

    }//class
}//ns
