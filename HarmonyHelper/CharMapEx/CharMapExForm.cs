using System.Diagnostics;
using System.Drawing.Text;

namespace CharMapEx
{
    public partial class CharMapExForm : Form
    {
        public CharMapExForm()
        {
            InitializeComponent();
            //Task.Run(()=> this.EnumerateFontsAsync());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.EnumerateFontsAsync(e);
        }

        async Task EnumerateFontsAsync(PaintEventArgs e)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
               fontFamily,
               20,
               FontStyle.Regular,
               GraphicsUnit.Point);
            RectangleF rectF = new RectangleF(10, 10, 500, 500);
            SolidBrush solidBrush = new SolidBrush(Color.Black);

            string familyName;
            string familyList = "";
            FontFamily[] fontFamilies;

            InstalledFontCollection installedFontCollection = new InstalledFontCollection();

            // Get the array of FontFamily objects.
            fontFamilies = installedFontCollection.Families;

            // The loop below creates a large string that is a comma-separated
            // list of all font family names.
            int count = fontFamilies.Length;
            for (int j = 0; j < count; ++j)
            {
                familyName = fontFamilies[j].Name;
                this._cbFonts.Items.Add(familyName);
                familyList = familyList + familyName;
                familyList = familyList + ",  ";
            }

            // Draw the large string (list of all families) in a rectangle.
            e.Graphics.DrawString(familyList, font, solidBrush, rectF);
        }

        private void _cbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(_cbFonts.SelectedItem);
            //this._grid.Populate()
            this._grid.SelectedFont = this._cbFonts.SelectedItem.ToString();
        }
    }
}