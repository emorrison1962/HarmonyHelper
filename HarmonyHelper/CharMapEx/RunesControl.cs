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

namespace NeckDiagrams.Controls
{
    public partial class RunesControl : UserControl
    {
        public class ChordFormulaVMEventArgs : EventArgs
        {
            public List<Rune> Items { get; private set; } = new List<Rune>();
            public ChordFormulaVMEventArgs(List<Rune> Items)
            {
                this.Items = Items;
            }
        }
        public event EventHandler<ChordFormulaVMEventArgs> SelectedRunesChanged;

        public bool MouseIsDragging { get; private set; }
        public Point DragBeginPoint { get; private set; }
        string _SelectedFont;
        public string SelectedFont
        {
            get { return this._SelectedFont; }
            set
            {
                this._SelectedFont = value;
            }
        }

        public IFontProvider FontProvider { get; set; }
        public RunesControl()
        {
            InitializeComponent();
            this.Load += RunesControl_Load;
        }

        private void RunesControl_Load(object sender, EventArgs e)
        {
            for (int i = 0xE010, ndx = 0; i < 0xE024; ++i, ++ndx)
            {
                this.Add(new Rune(i));
                Debug.WriteLine(ndx);
            }
            "Add the rest."
        }

        int currentColumn = 0;
        int currentRow = 0; 
        public void Add(Rune rune)
        {
            var ctl = new RuneControl(this.FontProvider, rune);
            this._runesTablePanel.Controls.Add(ctl, 
                -1, 
                -1);

            if (currentColumn == 15)
            {
                currentColumn = 0;
                currentRow++;
            }
            ctl.Width= 75;
            ctl.Height= 75;
            ctl.Dock= DockStyle.Fill;
        }

        public void AddRange(IEnumerable<Rune> vms)
        {

            var vmList = vms.ToList();
            vmList.ForEach(x => this.Add(x));
        }

        public void SetFontProvider(IFontProvider provider)
        {
            foreach (var ctl in this._runesTablePanel.Controls)
            {
                if (ctl is RuneControl)
                {
                    var cnCtl = (RuneControl)ctl;
                    cnCtl.SetFontProvider(provider);
                }
            }
        }

    }//class
}//ns
