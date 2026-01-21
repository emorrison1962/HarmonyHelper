using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

using NeckDiagrams.Domain;
#if false

key
scale

#endif

namespace NeckDiagrams
{
    public partial class StringPositionControl : UserControl
    {
        const int CX_ELLIPSE = 20;
        const int CY_ELLIPSE = 20;

        #region Properties
        public Note Note { get; private set; }
        int Position { get; set; }
        const int NUT = 0;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsActive { get; set; }
        public bool IsRoot { get; private set; }

        StringPositionVM StringPositionContext { get; set; }
        private NoteTypeEnum NoteType { get { return this.StringPositionContext.NoteType; } }
        Color DotColor { get; set; } //= Color.Black;

        #endregion

        #region Construction
        public StringPositionControl(StringPositionVM ctx)
        {
            if (ctx == null || !ctx.IsValid)
                throw new ArgumentException(nameof(ctx));
            this.StringPositionContext = ctx;
            InitializeComponent();
            this.Note = ctx.Note;
            this.Position = ctx.Position;
            this.Load += this.StringPositionControl_Load;
        }

        private void StringPositionControl_Load(object sender, System.EventArgs e)
        {
#warning FIXME
            //this.Model.ModelChanged += this.ModelChanged_Handler;
            this.Init();
        }

        void Init()
        {
            var vm = HarmonyHelper.IoC.Container.Resolve<IChordShapeVM>();
            var formula = vm.ChordFormula;
            this.IsRoot = formula.Root == this.Note.NoteName;

            var colors = HarmonyHelper.IoC.Container.Resolve<IColorContextCollection>();

            this.IsActive = false;
            var chordFunctionEnum = formula.GetChordFunction(this.Note.NoteName);
            if (chordFunctionEnum != ChordFunctionEnum.None)
            {
                this.IsActive = true;
                var color = colors.GetColor(chordFunctionEnum);
                this.DotColor = color;
                new object();

                this._toolTip.InitialDelay = 1000;
                const string CHORD_FUNCTION = "Chord Function";
                this._toolTip.ToolTipTitle = CHORD_FUNCTION;
                this._toolTip.ShowAlways = true;
                var nn = formula.NoteNames.FirstOrDefault(x => x.RawValue == this.Note.NoteName.RawValue);
                this._toolTip.SetToolTip(this, $"{nn.Name} is the {chordFunctionEnum.ToString()}");
            }
            new object();


        }

        #endregion

        #region Event Handlers

        private void StringPositionControl_Layout(object sender, LayoutEventArgs e)
        {
        }

        public override bool PreProcessMessage(ref Message msg)
        {
            //Debug.WriteLine(msg.Msg);
            return base.PreProcessMessage(ref msg);
        }

        #endregion

        #region Drawing
        private void StringPositionControl_Paint(object sender, PaintEventArgs e)
        {
            if (!DesignMode)
            {
                //this.DrawText(e);
                this.DrawFrets(e);
                this.DrawLine(e);
                this.DrawActiveDot(e);
                //Debug_DrawBoundary(e);
            }
        }

        private void DrawText(PaintEventArgs e)
        {
            var cxFret = this.Width / 2;
            var cyString = this.Height / 2;

            var cxText = cxFret - 25;
            var cyText = cyString - 25;

            var xCenter = CX_ELLIPSE;
            var yCenter = this.Height / 2;

            var x = (xCenter - CX_ELLIPSE / 2) - 10;
            var y = (yCenter - CY_ELLIPSE / 2) - 10;


            using (var font = new Font(FontFamily.GenericMonospace, 11))
            {
                e.Graphics.DrawString($"{this.Note.ToString()}",
                    font,
                    SystemBrushes.ControlText,
                    new Point(x, y));
            }
        }

        private void DrawFrets(PaintEventArgs e)
        {
            var cxFret = this.Width / 2;

            Rectangle rcNut = Rectangle.Empty;
            List<Point> fretPoints = null;

            if ((this.Parent as GuitarStringControl)?.GuitarStringNdx == GuitarStringNdxEnum.First)
            {
                if (this.Position == NUT)
                {
                    rcNut = new Rectangle(
                        new Point(cxFret, this.Height / 2),
                        new Size(5, this.Height));
                }
                else
                {
                    fretPoints = new List<Point>() {
                        new Point(cxFret, this.Height / 2),
                        new Point(cxFret, this.Height)};
                }
            }
            else if ((this.Parent as GuitarStringControl)?.GuitarStringNdx == GuitarStringNdxEnum.Sixth)
            {
                if (this.Position == NUT)
                {
                    rcNut = new Rectangle(
                        new Point(cxFret, 0),
                        new Size(5, this.Height / 2));
                }
                else
                {
                    fretPoints = new List<Point>() {
                        new Point(cxFret, 0),
                        new Point(cxFret, this.Height / 2) };
                }
            }
            else
            {
                if (this.Position == NUT)
                {//Draw nut
                    rcNut = new Rectangle(
                        new Point(cxFret, 0),
                        new Size(5, this.Height));
                }
                else
                {//Draw frets
                    fretPoints = new List<Point>() {
                    new Point(cxFret, 0),
                    new Point(cxFret, this.Height) };
                }
            }


            if (this.Position == NUT)
            {
                Brush brush = SystemBrushes.ControlText;
                    e.Graphics.FillRectangle(brush, rcNut);
            }
            else
            {
                Pen pen = SystemPens.ControlText;
                e.Graphics.DrawLine(pen,
                    fretPoints.First(),
                    fretPoints.Last());
            }


        }

        private void DrawLine(PaintEventArgs e)
        {
            var cyString = this.Height / 2;
            var p1 = new Point(0, cyString);
            var p2 = new Point(this.Width, cyString);
            e.Graphics.DrawLine(SystemPens.ControlText, p1, p2);
        }

        private void DrawActiveDot(PaintEventArgs e)
        {
            if (this.IsActive)
            {
                using var pen = this.CreatePen();
                using var brush = this.CreateBrush();

                var xCenter = CX_ELLIPSE;
                var yCenter = this.Height / 2;

                var x = xCenter - CX_ELLIPSE / 2;
                var y = yCenter - CY_ELLIPSE / 2;

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                e.Graphics.FillEllipse(brush, x, y, CX_ELLIPSE, CX_ELLIPSE);
            }
        }

        void Debug_DrawBoundary(PaintEventArgs e)
        {
            var rcBoundary = new Rectangle(
                new Point(0, 0),
                new Size(5, this.Height));
            e.Graphics.FillRectangle(Brushes.Blue, rcBoundary);
            rcBoundary = new Rectangle(
                new Point(this.Width - 5, 0),
                new Size(5, this.Height));
            e.Graphics.FillRectangle(Brushes.Red, rcBoundary);


            e.Graphics.DrawLine(Pens.Magenta,
                new Point(this.Width / 2, 0),
                new Point(this.Width / 2, this.Height));
            ////left
            //e.Graphics.DrawLine(Pens.Magenta,
            //	new Point(2, 2),
            //	new Point(2, this.Height));
            ////right
            //e.Graphics.DrawLine(Pens.Magenta,
            //	new Point(this.Width, 2),
            //	new Point(this.Width, this.Height));
            //// top
            //e.Graphics.DrawLine(Pens.Magenta,
            //	new Point(2, 2),
            //	new Point(2, this.Width));
            //// bottom
            //e.Graphics.DrawLine(Pens.Magenta,
            //	new Point(this.Height, 2),
            //	new Point(this.Height, this.Width));

        }

        static void DrawYinYang(Graphics gr, int xctr, int yctr, int rmax, int rint, int ysmall, int rsmall)
        {
            Brush white = Brushes.White;
            Brush black = Brushes.Black;
            Pen BlackPen = new Pen(Color.Black, 2 * (rmax - rint));

            gr.FillPie(black, xctr - rmax, yctr - rmax, 2 * rmax, 2 * rmax, -90, 180);
            gr.FillEllipse(black, xctr - rint / 2, yctr - rint, rint, rint);
            gr.FillEllipse(black, xctr - rint / 2, yctr, rint, rint);
            gr.FillEllipse(black, xctr - rsmall, yctr + ysmall - rsmall, 2 * rsmall, 2 * rsmall);
            gr.FillEllipse(black, xctr - rsmall, yctr - ysmall - rsmall, 2 * rsmall, 2 * rsmall);
            double rcircle = (rmax + rint) / 2.0;
            gr.DrawEllipse(BlackPen, (float)(xctr - rcircle), (float)(yctr - rcircle), (float)(2 * rcircle), (float)(2 * rcircle));
        }

        Pen CreatePen()
        {
            return new Pen(this.DotColor);
        }

        Brush CreateBrush()
        {
            return new SolidBrush(this.DotColor);
        }

        #endregion

    }//class
}//ns
