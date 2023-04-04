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
                var r = new Rune(i);
                this.Add(new Rune(i));
                Debug.WriteLine(ndx);
            }

#if false
	U+E000 (and U+1D114)
brace
Brace		U+E001
reversedBrace
Reversed brace
	U+E002 (and U+1D115)
bracket
Bracket		U+E003
bracketTop
Bracket top
	U+E004
bracketBottom
Bracket bottom		U+E005
reversedBracketTop
Reversed bracket top
	U+E006
reversedBracketBottom
Reversed bracket bottom		U+E007
systemDivider
System divider
	U+E008
systemDividerLong
Long system divider		U+E009
systemDividerExtraLong
Extra long system divider
	U+E00A
splitBarDivider
Split bar divider (bar spans a system break)		U+E00B
staffDivideArrowDown
Staff divide arrow down
	U+E00C
staffDivideArrowUp
Staff divide arrow up		U+E00D
staffDivideArrowUpDown
Staff divide arrows
#endif

            throw new NotImplementedException("Add the rest.");
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
