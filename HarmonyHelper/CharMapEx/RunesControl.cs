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

using CharMapEx;

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
            this.SuspendLayout();
            foreach(var rune in Runes.Catalog)// (int i = 0xE010, ndx = 0; i < 0xE024; ++i, ++ndx)
            {
                this.Add(rune);
            }
            this.ResumeLayout();
        }

        public void Add(Rune rune)
        {
            var ctl = new RuneControl(this.FontProvider, rune);
            this._runesTablePanel.Controls.Add(ctl, 
                -1, 
                -1);
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

        private void RunesControl_Layout(object sender, LayoutEventArgs e)
        {
            foreach (var ctl in this._runesTablePanel.Controls.Cast<Control>())
            {
                ctl.Size = ctl.PreferredSize;
                ctl.Dock = DockStyle.Fill;
            }
        }
    }//class
}//ns
