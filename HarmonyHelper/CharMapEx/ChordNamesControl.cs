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
    public partial class ChordNamesControl : UserControl
    {
        public class ChordFormulaVMEventArgs : EventArgs
        {
            public List<Rune> Items { get; private set; } = new List<Rune>();
            public ChordFormulaVMEventArgs(List<Rune> Items)
            {
                this.Items = Items;
            }
        }
        public event EventHandler<ChordFormulaVMEventArgs> SelectedChordNamesChanged;

        public bool MouseIsDragging { get; private set; }
        public Point DragBeginPoint { get; private set; }
        string _SelectedFont;
        public string SelectedFont 
        {
            get { return this._SelectedFont; }
            set 
            {
                this._SelectedFont = value;
                this.UpdateChildren();
            } 
        }

        public ChordNamesControl()
        {
            InitializeComponent();
            this.Load += ChordNamesControl_Load;
        }

        private void ChordNamesControl_Load(object sender, EventArgs e)
        {
            for (int i = 0xE010, ndx = 0; i < 0xE024; ++i, ++ndx)
            {
                this.Add(new Rune(i));
            }

        }


        public void Add(Rune rune)
        {
            var ctl = new ChordNameControl(rune);
            this._chordNamesTablePanel.Controls.Add(ctl);
        }

        public void AddRange(IEnumerable<Rune> vms)
        {
            
            var vmList = vms.ToList();
            vmList.ForEach(x => this.Add(x));
        }

        void UpdateChildren()
        {
            foreach (var ctl in this._chordNamesTablePanel.Controls)
            {
                if (ctl is ChordNameControl)
                {
                    ((ChordNameControl)ctl).SelectedFont = SelectedFont;
                }
            }
        }

    }//class
}//ns
