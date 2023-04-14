﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison;
using Eric.Morrison.Harmony.MusicXml;
using Eric.Morrison.Harmony.Rhythm;

using HarmonyHelperControls.WinForms.Domain;

using Manufaktura.Controls.SMuFL.EagerLoading;

using Newtonsoft.Json;

//using static System.Net.Mime.MediaTypeNames;

namespace HarmonyHelperControls.WinForms
{
    public partial class Score : UserControl
    {
        #region Properties
        string SelectedFontName { get { return "Bravura"; } }
        public Font LocalFont { get; set; }
        public RectangleF StaffPrefixRectangle { get; set; }
        public MeasureGrid MeasureGrid { get; set; }
        public FontContext FontContext { get; private set; }
        float LineSpacing { get; set; }
        public float BaseLine { get; private set; }
        public MusicXmlModel Model { get; private set; }
        SMuFLFontMetadata SmuflFontMetadata { get; set; }
        SizeF MeasureSize { get; set; }
        PointF LastPoint { get; set; }
        PointF MeasureLocation { get; set; }
        PointF NoteLocation { get; set; }

        #endregion

        #region Orig Construction
        public Score()
        {//| cxPrefix | m1 | m2 | m3 | m4 | m5 | m6 | m7 | m8 |
            InitializeComponent();

            this.LocalFont = new Font(this.SelectedFontName, 50);
            this.FontContext = LocalFont.GetFontMetrics();
            this.LineSpacing = this.FontContext.EmHeight / 2;
            this.BaseLine = this.FontContext.BaseLine;

            var ptBaseline = new PointF(this.ClientRectangle.Location.X, this.BaseLine);

            float cxTotal = this.ClientRectangle.Width;
            var cx = cxTotal / 9;
            this.StaffPrefixRectangle = new RectangleF(ptBaseline,
                new SizeF(cx, this.FontContext.EmHeight));
            cxTotal -= FontContext.EmHeight;

            var pt = new PointF(this.ClientRectangle.Location.X + cx, 0);
            //this.MeasureGrid = new MeasureGrid(ptBaseline, cxTotal, ts);

            Cursor.Current = Cursors.WaitCursor;
            Task.Run(() => this.Init()).ContinueWith(InitCompleted).Wait();

#warning FIXME:
            //this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        #endregion

        #region Construction
#if false
        public StaffGrid(FontContext fontMetrics, Point location, float cxTotal, TimeSignature ts)
        {//| cxPrefix | m1 | m2 | m3 | m4 | m5 | m6 | m7 | m8 |
            this.FontContext = fontMetrics;
            this.LineSpacing = fontMetrics.EmHeight / 2;
            this.BaseLine = fontMetrics.BaseLine;

            var ptBaseline = new PointF(location.X, this.BaseLine);
            var cx = cxTotal / 9;
            this.StaffPrefixRectangle = new RectangleF(ptBaseline, new SizeF(cx, fontMetrics.EmHeight));
            cxTotal -= FontContext.EmHeight;

            var pt = new PointF(location.X + cx, 0);
            this.MeasureGrid = new MeasureGrid(ptBaseline, cxTotal, ts);

            Cursor.Current = Cursors.WaitCursor;
            Task.Run(() => this.Init()).ContinueWith(InitCompleted).Wait();
        }
#endif
        void InitCompleted(Task task)
        {
            Cursor.Current = Cursors.Default;
        }

        [Obsolete]
        async Task Init()
        {
            var json = Helpers.LoadEmbeddedResource("bravura_metadata.json");
            this.SmuflFontMetadata = JsonConvert.DeserializeObject<SMuFLFontMetadata>(json);

            var path = Path.Combine(TEST_FILES_PATH, @"Effendi MusicXml Files\I\AllBlues 1.xml");
            Debug.Assert(File.Exists(path));
            var parser = new MusicXmlImporter();
            this.Model = parser.Import(path);

            this.GetMeasureRectangles();
            this.GetStaffSize();
        }

        [Obsolete]
        string TEST_FILES_PATH
        {
            get
            {
                var path = Assembly.GetExecutingAssembly().Location;
                path = Path.GetDirectoryName(path);
                path = Path.GetDirectoryName(path);
                path = Path.GetDirectoryName(path);
                path = Path.GetDirectoryName(path);
                path = Path.GetDirectoryName(path);
                path = Path.Combine(path, @"HarmonyHelperTests\TEST_FILES");
                Debug.WriteLine(path);
                return path;

                //D:\CODE\HarmonyHelper\HarmonyHelper\HarmonyHelperTests\TEST_FILES\Effendi MusicXml Files\I\AllBlues 1.xml
            }
        }

        #endregion

        #region Initialization

        List<RectangleF> MeasureRectangles { get; set; } = new List<RectangleF>();
        List<RectangleF> GetMeasureRectangles()
        {
            const int MAX_MEASURES_PER_LINE = 4;
            if (!this.ClientRectangle.IsEmpty)
            {
                this.MeasureRectangles.Clear();
                var left = this.ClientRectangle.Left;
                var cx = this.ClientRectangle.Width;
                var top = this.ClientRectangle.Top + this.FontContext.LineSpacing;
                var cy = this.ClientRectangle.Height;
                var cxMeasure = cx / MAX_MEASURES_PER_LINE;
                var cyMeasure = this.FontContext.EmHeight;
                var cyLineSpacing = this.LineSpacing;

                this.MeasureSize = new SizeF(cxMeasure, cyMeasure);

                for (int i = 0; i <= MAX_MEASURES_PER_LINE; ++i)
                {
                    var pt = new PointF(left + (i * cxMeasure), top);
                    var size = new SizeF(cxMeasure, cyMeasure);
                    var rc = new RectangleF(pt, size);
                    this.MeasureRectangles.Add(rc);
                }
            }
            return this.MeasureRectangles;
        }

        void GetStaffSize()
        {
        }

        #endregion


        StaffGrid CreateStaffGrid(Point pt, int cx, TimeSignature ts)
        {
            var result = new StaffGrid(this.FontContext, pt, cx, ts);
            return result;
        }

        public RectangleF GetStaffRectangle(PaintEventArgs pea)
        {
            RectangleF result = RectangleF.Empty;

            var pt = pea.ClipRectangle.Location;
            var width = pea.ClipRectangle.Width;

            var size = new Size(width, (int)this.FontContext.LineSpacing);
            result = new RectangleF(pt, size);

            //using (var pen = new Pen(Brushes.Magenta, 3))
            //{
            //    pea.Graphics.DrawRectangle(pen, result);
            //}

            return result;
        }

        #region EventHandlers

        #endregion

        #region Drawing
        void Score_Paint(object sender, PaintEventArgs pea)
        {
            this.DrawClientRect(pea);
            var rc = this.GetStaffRectangle(pea);
            this.DrawStaff(pea, rc);
        }

        [Conditional("DEBUG")]
        void DrawClientRect(PaintEventArgs pea)
        {
            pea.Graphics.DrawRectangle(Pens.Red, this.ClientRectangle);
        }
        public void DrawStaff(PaintEventArgs pea, RectangleF rawRect)
        {
            this.DrawStaffPrefix(pea);
            this.DrawNotes(pea);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            this.DrawDebugRectangle($"{MethodBase.GetCurrentMethod().Name}, rawRect",
                pea,
                Brushes.Red,
                4,
                rawRect);
            this.DrawDebugRectangle($"{MethodBase.GetCurrentMethod().Name}, this.ClientRectangle",
                pea,
                Brushes.Blue,
                4,
                this.ClientRectangle);

            using (var pen = new Pen(Color.Black, 2))
            {
                var left = this.ClientRectangle.Left;
                var cx = this.ClientRectangle.Width;
                var top = this.ClientRectangle.Top + this.FontContext.LineSpacing;
                var cy = this.ClientRectangle.Height;

                var cyLineSpacing = this.LineSpacing;

                const int MAX_STAFF_LINES = 5;
                for (int i = 0; i < MAX_STAFF_LINES; ++i)
                {
                    pea.Graphics.DrawLine(pen,
                        new PointF(left, top - (i * cyLineSpacing)),
                        new PointF(cx, top - (i * cyLineSpacing)));
                }

                const int MAX_MEASURES_PER_LINE = 4;
                var cxMeasure = (cx - left) / MAX_MEASURES_PER_LINE + 1;
                for (int i = 0; i <= MAX_MEASURES_PER_LINE; ++i)
                {
                    pea.Graphics.DrawLine(pen,
                        new PointF(left + (i * cxMeasure), top),
                        new PointF(left + (i * cxMeasure), top - (4 * cyLineSpacing)));
                }
            }

            foreach (var measure in this.Model.Parts.First().Measures)
            {
                this.DrawMeasure(pea, measure);
            }
            new object();
        }

        public void DrawStaffPrefix(PaintEventArgs pea)
        {
            var str = Runes.G_clef.ToString();
            var szStr = pea.Graphics.MeasureString(str, this.FontContext.Font);

            //var yOffset = this.FontContext.EmHeight / 4;
            //var cxNote = new SizeF(0, -((FontContext.BaseLine * 2) + yOffset * 2));
            //var ptNe = PointF.Add(this.ClientRectangle.Location, cxNote);

            pea.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            //pea.Graphics.DrawString(str, this.FontContext.Font, Brushes.Black, ptNe);
            pea.Graphics.DrawString(str, this.FontContext.Font, Brushes.Black, this.ClientRectangle.Location);


            var json = Helpers.LoadEmbeddedResource("bravura_metadata.json");
            var meta = JsonConvert.DeserializeObject<SMuFLFontMetadata>(json);


            var bbox = meta.GlyphBBoxes.GClef;
            var ptNe = bbox.PointNe;
            this.LastPoint = bbox.PointSw;

            new object();
            str = SMuFLGlyphs.Instance.GClef.Rune.ToString();

            pea.Graphics.DrawString(str,
                this.FontContext.Font,
                Brushes.DarkMagenta,
                ptNe);

        }

        void DrawMeasure(PaintEventArgs pea, Measure measure)
        {
            throw new NotImplementedException("need to adjust Location.Y for measures past the first row!");

            var measureRects = this.GetMeasureRectangles();
            var measureRect = measureRects[measure.MeasureNumber % 4];
            var x = measureRect.Location.X;
            foreach (var note in measure.Notes)
            {
                var tcx = note.TimeContext;
                var de = tcx.DurationEnum;
                var evt = note.Event;
                new object();

                this.GetNotehead(note);
                var rune = this.GetStem(note);
                this.GetMeasurePosition();

                var bbox = this.SmuflFontMetadata.GlyphBBoxes.NoteheadBlack;
                var ptNe = bbox.PointNe;
                x += 50;
                ptNe.X += x;// this.LastPoint.X;

                new object();
                var str = rune.ToString();

                pea.Graphics.DrawString(str,
                    this.FontContext.Font,
                    Brushes.DarkBlue,
                    ptNe);


            }
        }

        void DrawNotes(PaintEventArgs pea)
        {

            var bbox = this.SmuflFontMetadata.GlyphBBoxes.NoteheadBlack;
            var ptNe = bbox.PointNe;
            ptNe.X += 50;// this.LastPoint.X;

            new object();
            var str = SMuFLGlyphs.Instance.NoteheadBlack.Rune.ToString();

            pea.Graphics.DrawString(str,
                this.FontContext.Font,
                Brushes.DarkBlue,
                ptNe);
        }

        void DrawDebugRectangle(string msg, PaintEventArgs pea,
            Brush brush, int cxPen, RectangleF src)
        {
            using (var pen = new Pen(Brushes.Red, 4))
            using (var font = new Font("Courier New", 10))
            {
                //src.Width /= 2;
                pea.Graphics.DrawRectangle(pen, src);

                var msgSize = pea.Graphics.MeasureString(msg, font);
                var x = src.Width - msgSize.Width;
                var msgLocation = new PointF(x, src.Top);
                var msgRect = new RectangleF(msgLocation, msgSize);

                pea.Graphics.FillRectangle(SystemBrushes.Control, msgRect);
                pea.Graphics.DrawString($"{msg}",
                    font,
                    brush,
                    new PointF(msgRect.Location.X + 20, msgRect.Location.Y - 5));
            }
        }

        #endregion

        void GetMeasurePosition()
        {
        }

        void GetNotehead(TimedEventNote ten)
        {
            var tcx = ten.TimeContext;
            var de = tcx.DurationEnum; //get stem
            var note = ten.Event; //get notehead

            Rune rune = new Rune();
            switch (de)
            {
                case DurationEnum.Duration_Whole:
                case DurationEnum.Duration_Half:
                    {
                        rune = SMuFLGlyphs.Instance.NoteheadWhole.Rune;
                        break;
                    }
                case DurationEnum.Duration_Quarter:
                case DurationEnum.Duration_Eighth:
                case DurationEnum.Duration_16th:
                case DurationEnum.Duration_32nd:
                case DurationEnum.Duration_64th:
                case DurationEnum.Duration_128th:
                case DurationEnum.Duration_256th:
                case DurationEnum.Duration_512th:
                case DurationEnum.Duration_1024th:
                    {
                        rune = SMuFLGlyphs.Instance.NoteheadBlack.Rune;
                        break;
                    }
                case DurationEnum.Duration_Maxima:
                case DurationEnum.Duration_Long:
                case DurationEnum.Duration_Breve:
                case DurationEnum.Unknown:
                case DurationEnum.None:
                default: throw new ArgumentOutOfRangeException(nameof(de));

            }

        }

        Rune GetStem(TimedEventNote ten)
        {
            var tcx = ten.TimeContext;
            var de = tcx.DurationEnum; //get stem
            var note = ten.Event; //get notehead

            Rune result = new Rune();
            switch (de)
            {
                case DurationEnum.Duration_Whole:
                    {
                        result = SMuFLGlyphs.Instance.NoteWhole.Rune;
                        break;
                    }
                case DurationEnum.Duration_Half:
                    {
                        result = SMuFLGlyphs.Instance.NoteHalfUp.Rune;
                        break;
                    }
                case DurationEnum.Duration_Quarter:
                    {
                        result = SMuFLGlyphs.Instance.NoteQuarterUp.Rune;
                        break;
                    }
                case DurationEnum.Duration_Eighth:
                    {
                        result = SMuFLGlyphs.Instance.Note8ThUp.Rune;
                        break;
                    }
                case DurationEnum.Duration_16th:
                    {
                        result = SMuFLGlyphs.Instance.Note16ThUp.Rune;
                        break;
                    }
                case DurationEnum.Duration_32nd:
                    {
                        result = SMuFLGlyphs.Instance.Note32NdUp.Rune;
                        break;
                    }
                case DurationEnum.Duration_64th:
                    {
                        result = SMuFLGlyphs.Instance.Note64ThUp.Rune;
                        break;
                    }
                case DurationEnum.Duration_128th:
                    {
                        result = SMuFLGlyphs.Instance.Note128ThUp.Rune;
                        break;
                    }
                case DurationEnum.Duration_256th:
                    {
                        result = SMuFLGlyphs.Instance.Note256ThUp.Rune;
                        break;
                    }
                case DurationEnum.Duration_512th:
                    {
                        result = SMuFLGlyphs.Instance.Note256ThUp.Rune;
                        break;
                    }
                case DurationEnum.Duration_1024th:
                    {
                        result = SMuFLGlyphs.Instance.Note1024ThUp.Rune;
                        break;
                    }
                case DurationEnum.Duration_Maxima:
                case DurationEnum.Duration_Long:
                case DurationEnum.Duration_Breve:
                case DurationEnum.Unknown:
                case DurationEnum.None:
                default: throw new ArgumentOutOfRangeException(nameof(de));
            }
            return result;
        }

    }//class
}//ns


