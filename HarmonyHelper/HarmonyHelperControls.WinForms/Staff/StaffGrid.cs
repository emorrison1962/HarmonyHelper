using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Eric.Morrison;
using Eric.Morrison.Harmony.MusicXml;
using Eric.Morrison.Harmony.Rhythm;

using HarmonyHelperControls.WinForms.Domain;

using Manufaktura.Controls.SMuFL.EagerLoading;

using Newtonsoft.Json;

namespace HarmonyHelperControls.WinForms
{
    public class StaffGrid
    {
        #region Properties
        public RectangleF StaffPrefixRectangle { get; set; }
        public MeasureGrid MeasureGrid { get; set; }
        public FontContext FontContext { get; private set; }
        float LineSpacing { get; set; }
        public float BaseLine { get; private set; }
        public MusicXmlModel Model { get; private set; }
        SMuFLFontMetadata SmuflFontMetadata { get; set; }
        SizeF MeasureSize { get; set; }
        PointF LastPoint { get; set; }
        RectangleF Rectangle { get; set; }
        PointF MeasureLocation { get; set; }
        PointF NoteLocation { get; set; }

        #endregion

        #region Construction
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

        void InitCompleted(Task task)
        {
            Cursor.Current = Cursors.Default;
        }

        [Obsolete]
        async private Task Init()
        {
            var json = Helpers.LoadEmbeddedResource("bravura_metadata.json");
            this.SmuflFontMetadata = JsonConvert.DeserializeObject<SMuFLFontMetadata>(json);

            var path = Path.Combine(TEST_FILES_PATH, @"Effendi MusicXml Files\I\AllBlues 1.xml");
            Debug.Assert(File.Exists(path));
            var parser = new MusicXmlImporter();
            this.Model = parser.Import(path);

            this.GetMeasureSize();
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
        RectangleF GetRectangle(RectangleF rc)
        {
            var x = rc.Location.X;
            var y = rc.Location.Y;// + this.FontContext.BaseLine;// + this.FontContext.EmHeight; 
            var cx = rc.Width;
            var cy = rc.Height;
            var result = new RectangleF(x, y, cx, cy);
            return result;
        }

        List<RectangleF> MeasureRectangles { get; set; } = new List<RectangleF>();
        private void GetMeasureSize()
        {
            if (!this.Rectangle.IsEmpty)
            {
                this.MeasureRectangles.Clear();
                var left = this.Rectangle.Left;
                var cx = this.Rectangle.Width;
                var top = this.Rectangle.Top + this.FontContext.LineSpacing;
                var cy = this.Rectangle.Height;
                const int MAX_MEASURES_PER_LINE = 4;
                var cxMeasure = (cx - left) / MAX_MEASURES_PER_LINE + 1;
                var cyMeasure = this.FontContext.EmHeight;
                var cyLineSpacing = this.LineSpacing;

                this.MeasureSize = new SizeF(cxMeasure, cyMeasure);

                for (int i = 0; i <= MAX_MEASURES_PER_LINE; ++i)
                {
                    var pt = new PointF(left + (i * cxMeasure), top);
                    var size = new SizeF(left + (i * cxMeasure), top - (4 * cyLineSpacing));
                    var rc = new RectangleF(pt, size);
                    this.MeasureRectangles.Add(rc);
                }
            }
        }

        private void GetStaffSize()
        {
        }

        #endregion

        private void GetMeasurePosition()
        {
        }

        void GetNotehead(TimedEventNote ten)
        {
            var tcx = ten.TimeContext;
            var de = tcx.Duration; //get stem
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
                case DurationEnum.None:
                default: throw new ArgumentOutOfRangeException(nameof(de));

            }

        }

        Rune GetStem(TimedEventNote ten)
        {
            var tcx = ten.TimeContext;
            var de = tcx.Duration; //get stem
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
                case DurationEnum.None:
                default: throw new ArgumentOutOfRangeException(nameof(de));
            }
            return result;
        }

        #region Drawing
        public void DrawStaffPrefix(PaintEventArgs pea)
        {
            var str = Runes.G_clef.ToString();
            var szStr = pea.Graphics.MeasureString(str, this.FontContext.Font);

            //var yOffset = this.FontContext.EmHeight / 4;
            //var cxNote = new SizeF(0, -((FontContext.BaseLine * 2) + yOffset * 2));
            //var ptNe = PointF.Add(this.Rectangle.Location, cxNote);

            pea.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            //pea.Graphics.DrawString(str, this.FontContext.Font, Brushes.Black, ptNe);
            pea.Graphics.DrawString(str, this.FontContext.Font, Brushes.Black, this.Rectangle.Location);


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

        public void DrawStaff(PaintEventArgs pea, RectangleF rawRect)
        {
            this.Rectangle = this.GetRectangle(rawRect);
            this.DrawStaffPrefix(pea);
            this.DrawNotes(pea);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            this.DrawDebugRectangle($"{MethodBase.GetCurrentMethod().Name}, rawRect",
                pea,
                Brushes.Red,
                4,
                rawRect);
            this.DrawDebugRectangle($"{MethodBase.GetCurrentMethod().Name}, this.Rectangle",
                pea,
                Brushes.Blue,
                4,
                this.Rectangle);

            using (var pen = new Pen(Color.Black, 2))
            {
                var left = this.Rectangle.Left;
                var cx = this.Rectangle.Width;
                var top = this.Rectangle.Top + this.FontContext.LineSpacing;
                var cy = this.Rectangle.Height;

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
                //this.Measure
                if (measure.MeasureNumber % 4 == 0)
                this.DrawMeasure(pea, measure);
            }
            new object();
        }

        private void DrawMeasure(PaintEventArgs pea, Measure measure)
        {
            var neasureRect = this.MeasureRectangles[measure.MeasureNumber % 4];
            var x = 0;
            foreach (var note in measure.Notes)
            {
                var tcx = note.TimeContext;
                var de = tcx.Duration;
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

        private void DrawNotes(PaintEventArgs pea)
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

        private void oldDrawNotes(PaintEventArgs pea)
        {
            var pt = this.Rectangle.Location;
            var zz = this.FontContext.EmHeight / 4;
            pt.X += 80;
            for (int i = 0; i < 9; ++i)
            {
                var str = Runes.Black_notehead.ToString();
                pea.Graphics.DrawString(str,
                    this.FontContext.Font, Brushes.Black, pt);
                pt.X += 50;
                pt.Y -= (zz);
            }
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

        internal void Resize(Rectangle clientRectangle)
        {
            this.Rectangle = clientRectangle;
            this.GetMeasureSize();
            this.GetStaffSize();
        }

        #endregion

    }//class
}//ns
