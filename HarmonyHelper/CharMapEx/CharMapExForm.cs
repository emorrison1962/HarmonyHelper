using System.Diagnostics;
using System.Drawing.Text;
using System.Text;

using NeckDiagrams.Controls;

namespace CharMapEx
{
    public partial class CharMapExForm : Form, IFontProvider
    {
        public string? SelectedFont { get; private set; }

        public event EventHandler<string> FontChanged;
        public CharMapExForm()
        {
            InitializeComponent();
            Task.Run(() => this.EnumerateFontsAsync());
        }

        protected override void OnLoad(EventArgs e)
        {
            this.SelectedFont = "Bravura";
            this._runesControl.SetFontProvider(this);
            base.OnLoad(e);
        }

        async Task EnumerateFontsAsync()
        {
            var installedFonts = new InstalledFontCollection();

            var fontFamilies = installedFonts.Families;
            int count = fontFamilies.Length;
            for (int i = 0; i < count; ++i)
            {
                var familyName = fontFamilies[i].Name;
                this._cbFonts.Items.Add(familyName);
            }
            this._cbFonts.SelectedText= "Bravura";
            await Task.CompletedTask;
        }

        private void _cbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(_cbFonts.SelectedItem);
            //this._grid.Populate()
            this.SelectedFont = this._cbFonts.SelectedItem.ToString();

            //this.Populate_FlowLayoutPanel();
            this.OnFontChanged();
            this.Invalidate(true);
        }

        private void OnFontChanged()
        {
            this.FontChanged?.Invoke(this, this.SelectedFont);
        }

        [Obsolete("", true)]
        void Populate_FlowLayoutPanel()
        {
            for (int i = 0xE010, ndx = 0; i < 0xE024; ++i, ++ndx)
            {
                this.Add(new Rune(i));
            }
            this.Update();
        }

        [Obsolete("", true)]
        public void Add(Rune rune)
        {
            //var ctl = new RuneControl(rune);
            //this._flowPanel.Controls.Add(ctl);
        }

    }//class
}//ns