using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
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
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Score_Paint(object sender, PaintEventArgs e)
        {
            this.DrawStaff(sender, e);
            this.DrawText(sender, e);
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
                Debug.WriteLine((cyLines * (MAX_STAFF_LINES - 1)));

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
            staff.DrawStaff(sender, e);
             

            //e.Graphics.DrawRectangle(Pens.DarkRed, staff.StaffPrefixRectangle);
            //e.Graphics.DrawRectangles(Pens.DarkOrange, staff.MeasureGrid.Rectangles.ToArray());

        }

        private void DrawText(object sender, PaintEventArgs e)
        {
            using (var font = new Font("Bravura", 40))
            {
                var brush = Brushes.Black;
                var pt = e.ClipRectangle.Location;

                throw new NotImplementedException();
                var str = Runes.F_clef.ToString();

                var sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Near;
                sf.Alignment = StringAlignment.Center;

                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                e.Graphics.DrawString(str, font, Brushes.Black, pt, System.Drawing.StringFormat.GenericTypographic);


                new object();
            }
        }


    }//class
}//ns
