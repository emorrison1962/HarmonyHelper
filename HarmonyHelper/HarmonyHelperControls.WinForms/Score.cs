using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HarmonyHelperControls.WinForms
{
    public partial class Score : UserControl
    {
        public Score()
        {
            InitializeComponent();
        }

        private void Score_Paint(object sender, PaintEventArgs e)
        {
            this.DrawStaff(sender, e);
            this.DrawText(sender, e);
        }


        //private Dictionary<MusicFontStyles, Font> fonts = new Dictionary<MusicFontStyles, Font>()
        //    {
        //        {MusicFontStyles.MusicFont, new Font("Polihymnia", 27.5f, GraphicsUnit.Pixel)},
        //        {MusicFontStyles.GraceNoteFont, new Font("Polihymnia", 20, GraphicsUnit.Pixel)},
        //        {MusicFontStyles.StaffFont, new Font("Polihymnia", 30.5f, GraphicsUnit.Pixel)},
        //        {MusicFontStyles.LyricsFont, new Font("Times New Roman", 11, GraphicsUnit.Pixel)},
        //        {MusicFontStyles.DirectionFont, new Font("Microsoft Sans Serif", 11, FontStyle.Italic | FontStyle.Bold, GraphicsUnit.Pixel)},
        //        {MusicFontStyles.TimeSignatureFont, new Font("Microsoft Sans Serif", 14.5f, FontStyle.Bold, GraphicsUnit.Pixel)}
        //    };

        private void DrawText(object sender, PaintEventArgs e)
        {
            using (var font = new Font("Polihymnia", 30.5f, GraphicsUnit.Pixel))
                {
                 //0xFE
                string str = $"\u0069{0x100}{0x120}{0x130}{0x140}{0x200}{0x250}";
                var brush = Brushes.Black;
                var pt = new Point(200, 200);
                e.Graphics.DrawString(str, font, brush, pt);

            }
        }

        void DrawStaff(object sender, PaintEventArgs e)
        {
            var dpiX = e.Graphics.DpiX;
            var dpiY = e.Graphics.DpiY;

            //var pen = Pens.Black;

            using (var pen = new Pen(Color.Black, 2))
            {

                var x = e.ClipRectangle.Left;
                var cx = e.ClipRectangle.Width;
                var y = e.ClipRectangle.Top + 20;
                var cy = e.ClipRectangle.Height;

                var cxMin = x + 50;
                var cxMax = (cx - 50) - cxMin;
                var cyMin = 300;

                var cyLines = 15;

                const int MAX_STAFF_LINES = 5;
                for (int i = 0; i < MAX_STAFF_LINES; ++i)
                {
                    e.Graphics.DrawLine(pen,
                        new Point(cxMin, (i * cyLines) + cyMin),
                        new Point(cxMax, (i * cyLines) + cyMin));
                }

                var cyStaff = cyMin + (cyLines * (MAX_STAFF_LINES - 1));

                const int MAX_MEASURES_PER_LINE = 8;
                var cxMeasure = (cxMax - cxMin) / MAX_MEASURES_PER_LINE + 1; 
                for (int i = 0; i <= MAX_MEASURES_PER_LINE; ++i)
                {
                    e.Graphics.DrawLine(pen,
                        new Point(cxMin + (i * cxMeasure), cyMin),
                        new Point(cxMin + (i * cxMeasure), cyStaff));
                }
            }


            new object();
        }
    }//class
}//ns
