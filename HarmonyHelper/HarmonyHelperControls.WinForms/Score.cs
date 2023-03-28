using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison.Harmony.Rhythm;

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

        const string TREBLE_CLEF = "\u0069";

        private void DrawText(object sender, PaintEventArgs e)
        {
            using (var font = new Font("Polihymnia", 50f, GraphicsUnit.Pixel))
            {
                //0xFE
                string str = TREBLE_CLEF;
                var brush = Brushes.Black;
                var pt = new Point(200, 200);
                e.Graphics.DrawString(str, font, brush, pt);

            }
        }

        class MeasureGrid
        {
            public List<RectangleF> Rectangles = new List<RectangleF>();
            public MeasureGrid(Point pt, int cxTotal, TimeSignature ts)
            {//| m1 | m2 | m3 | m4 | m5 | m6 | m7 | m8 | 
                var nRectangles = ts.BeatCount;
                var cx = cxTotal / nRectangles;
                for (int i = 0; i < nRectangles; ++i)
                {
                    var rc = new RectangleF(pt, new Size(cx, StaffGrid.MIN_STAFF_HEIGHT));
                    this.Rectangles.Add(rc);
                    pt.Offset(cx, 0);
                }
            }
        }
        class StaffGrid
        {
            public const int MIN_STAFF_HEIGHT = 20;
            public RectangleF StaffPrefixRectangle { get; set; }
            public MeasureGrid MeasureGrid { get; set; }

            //E, G, B, D
            //F, A, C, E


            public StaffGrid(Point location, int cxTotal, TimeSignature ts)
            {//| cxPrefix | m1 | m2 | m3 | m4 | m5 | m6 | m7 | m8 |
                var cx = cxTotal / 9;
                this.StaffPrefixRectangle = new RectangleF(location, new Size(cx, MIN_STAFF_HEIGHT));
                cxTotal -= cx;
                location.Offset(cx, 0);

                this.MeasureGrid = new MeasureGrid(location, cxTotal, ts);
            }
        }
        StaffGrid CreateStaffGrid(Point pt, int cx, TimeSignature ts)
        {
            var result = new StaffGrid(pt, cx, ts);
            return result;
        }
        void DrawStaff(object sender, PaintEventArgs e)
        {
            var staffGrid = this.CreateStaffGrid(e.ClipRectangle.Location, 
                e.ClipRectangle.Width, 
                new TimeSignature(4, 4));
            this.DrawStaffGrid(sender, e, staffGrid);

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

        void DrawStaffGrid(object sender, PaintEventArgs e, StaffGrid staff)
        {
            e.Graphics.DrawRectangle(Pens.DarkRed, staff.StaffPrefixRectangle);
            e.Graphics.DrawRectangles(Pens.DarkOrange, staff.MeasureGrid.Rectangles.ToArray());
            //foreach (var rc in staff.MeasureGrid.Rectangles)
            
        }
    }//class
}//ns
