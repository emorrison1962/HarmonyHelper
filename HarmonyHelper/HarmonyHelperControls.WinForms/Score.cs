using System;
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
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.MusicXml;
using Eric.Morrison.Harmony.Rhythm;

using HarmonyHelperControls.WinForms.Domain;

using Manufaktura.Controls.SMuFL.EagerLoading;

using Newtonsoft.Json;

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

        List<RectangleF> _MeasureRectangles = new List<RectangleF>();
        List<RectangleF> MeasureRectangles
        {
            get
            {
                if (!_MeasureRectangles.Any())
                    _MeasureRectangles = this.GetMeasureRectangles();
                return _MeasureRectangles;
            }
        }
        List<RectangleF> GetMeasureRectangles()
        {
            var result = new List<RectangleF>();
            const int MAX_MEASURES_PER_LINE = 4;
            if (!this.ClientRectangle.IsEmpty)
            {
                var left = (float)this.ClientRectangle.Left;
                var cx = (float)this.ClientRectangle.Width;
                var top = (float)this.ClientRectangle.Top;
                var cy = (float)this.ClientRectangle.Height;
                var cxMeasure = cx / MAX_MEASURES_PER_LINE;
                var cyMeasure = this.FontContext.EmHeight;
                var cyLineSpacing = this.LineSpacing;

                this.MeasureSize = new SizeF(cxMeasure, cyMeasure);


                var nMeasures = this.Model.Parts.First().Measures.Count;
                for (int i = 0; i < nMeasures; ++i)
                {
                    var measure = this.Model.Parts.First().Measures[i];
                    if (i % MAX_MEASURES_PER_LINE == 0)
                    {
                        top += this.FontContext.LineSpacing;
                    }

                    {
                        var pt = new PointF(left + ((i % 4) * cxMeasure), top);
                        var size = new SizeF(cxMeasure, cyMeasure);
                        var rc = new RectangleF(pt, size);
                        result.Add(rc);
                    }
                }
            }

            result.ForEach(x => Debug.WriteLine(x));
            return result;
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

            using (var pen = new Pen(Brushes.Magenta, 3))
            {
                pea.Graphics.DrawRectangle(pen, result);
            }

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

            #region Draw the staff.
            for (int j = 0; j < this.MeasureRectangles.Count; j += 4)
            {
                var measureRect = this.MeasureRectangles[j];
                var left = this.ClientRectangle.Left;
                var cx = this.ClientRectangle.Width;
#warning FIXME: MAGIC NUMBER
                var top = measureRect.Top - 34;
                var cy = this.ClientRectangle.Height;

                using (var pen2 = new Pen(Color.Green, 2))
                {
                    pea.Graphics.DrawRectangle(pen2, measureRect);
                }


                pea.Graphics.DrawString(Runes.Five_line_staff_wide.ToString(),
                    this.FontContext.Font,
                    Brushes.Red,
                    this.CurrentLocation);


                var cyLineSpacing = this.LineSpacing;
                using (var pen = new Pen(Color.Black, 2))
                {
                    const int MAX_STAFF_LINES = 5;
                    for (int i = 0; i < MAX_STAFF_LINES; ++i)
                    {
#warning FIXME: MAGIC NUMBER
                        pea.Graphics.DrawLine(pen,
                            new PointF(left, top - (i * 21 /*cyLineSpacing*/)),
                            new PointF(cx, top - (i * 21 /*cyLineSpacing*/)));
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
            }

            #endregion

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

            pea.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            var pt = new PointF(0, 0);

            #region Why do I have to manually adjust the clef Y location?
            var baseline = -this.FontContext.EmHeight / 2;
            var ptClef = new PointF(0, baseline);

            #endregion

            #region Draw the clef.
            new object();
            str = SMuFLGlyphs.Instance.GClef.Rune.ToString();
            pea.Graphics.DrawString(str,
                this.FontContext.Font,
                Brushes.Black,
                ptClef);

            #endregion

            #region Draw the time signature.

            pt.X += szStr.Width;
            str = Runes.Control_character_for_numerator_digit.ToString() + Runes.Time_signature_Six.ToString();
            pea.Graphics.DrawString(str,
                this.FontContext.Font,
                Brushes.Black,
                pt);

            str = Runes.Control_character_for_denominator_digit.ToString() + Runes.Time_signature_Eight.ToString();
            pea.Graphics.DrawString(str,
                this.FontContext.Font,
                Brushes.Black,
                pt);

            #endregion

            szStr = pea.Graphics.MeasureString(str, this.FontContext.Font);
            pt.X += szStr.Width;
            this.CurrentLocation = pt;
        }

        PointF CurrentLocation { get; set; }

        public class NoteMetrics
        {
            public TimedEventNote Note { get; set; }
            public Rune Rune { get; set; }
            public RectangleF Rectangle { get; set; }
            public PointF Location { get; set; }
        }
        void DrawMeasure(PaintEventArgs pea, Measure measure)
        {
            var measureRect = this.MeasureRectangles[measure.MeasureNumber % 4];
            var x = measureRect.Location.X;
            var y = this.CurrentLocation.Y;
            foreach (var note in measure.Notes)
            {

                var tcx = note.TimeContext;
                var de = tcx.DurationEnum;
                var evt = note.Event;
                new object();

                //var rune = this.GetNotehead(note);
                var rune = this.GetStem(note);
                NoteMetrics nm = this.GetNoteMetrics(note);
                this.GetMeasurePosition();

                var bbox = this.SmuflFontMetadata.GlyphBBoxes.NoteheadBlack;
                var ptNe = bbox.PointNe;
                x += 50;
                ptNe.X += x;// this.LastPoint.X;
                //ptNe.Y = measureRect.Location.Y;
                ptNe.Y = y;
                y += 10.0F;


                new object();
                var str = rune.ToString();

                pea.Graphics.DrawString(str,
                    this.FontContext.Font,
                    Brushes.Black,
                    ptNe);

                this.CurrentLocation = ptNe;
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

        #endregion

        void GetMeasurePosition()
        {
        }


        private NoteMetrics GetNoteMetrics(TimedEventNote note)
        {
            var result = new NoteMetrics();
            result.Note = note;
            var rune = this.GetStem(note);
            result.Rune = rune;
            var rc = this.GetBoundingBox(note);
            result.Rectangle = rc;
            return result;
        }


        Rune GetNotehead(TimedEventNote ten)
        {
            Rune result = new Rune();

            var tcx = ten.TimeContext;
            var de = tcx.DurationEnum; //get stem
            var note = ten.Event; //get notehead

            Rune rune = new Rune();
            switch (de)
            {
                case DurationEnum.Duration_Whole:
                case DurationEnum.Duration_Half:
                    {
                        result = SMuFLGlyphs.Instance.NoteheadWhole.Rune;
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
                        result = SMuFLGlyphs.Instance.NoteheadBlack.Rune;
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
        RectangleF GetBoundingBox(TimedEventNote ten)
        {
            RectangleF result = RectangleF.Empty;
            var width = MeasureSize.Width;

            var tcx = ten.TimeContext;
            var de = tcx.DurationEnum; //get stem
            var note = ten.Event; //get notehead

            switch (de)
            {
                case DurationEnum.Duration_Whole:
                    {
                        break;
                    }
                case DurationEnum.Duration_Half:
                    {
                        width = width / 2;
                        break;
                    }
                case DurationEnum.Duration_Quarter:
                    {
                        width = width / 4;
                        break;
                    }
                case DurationEnum.Duration_Eighth:
                    {
                        width = width / 8;
                        break;
                    }
                case DurationEnum.Duration_16th:
                    {
                        width = width / 16;
                        break;
                    }
                case DurationEnum.Duration_32nd:
                    {
                        width = width / 32;
                        break;
                    }
                case DurationEnum.Duration_64th:
                    {
                        width = width / 64;
                        break;
                    }
                case DurationEnum.Duration_128th:
                    {
                        width = width / 128;
                        break;
                    }
                case DurationEnum.Duration_256th:
                    {
                        width = width / 256;
                        break;
                    }
                case DurationEnum.Duration_512th:
                    {
                        width = width / 512;
                        break;
                    }
                case DurationEnum.Duration_1024th:
                    {
                        width = width / 1024;
                        break;
                    }
                case DurationEnum.Duration_Maxima:
                case DurationEnum.Duration_Long:
                case DurationEnum.Duration_Breve:
                case DurationEnum.Unknown:
                case DurationEnum.None:
                default: throw new ArgumentOutOfRangeException(nameof(de));
            }

            result = new RectangleF(this.CurrentLocation, new SizeF(width, MeasureSize.Height));
            return result;
        }
        PointF GetLocation(TimedEventNote ten)
        {
            var result = PointF.Empty;
            var note = ten.Event;

            //c4 is middle C.

            switch (note.Octave)
            {
                case OctaveEnum.Octave0:
                    {
                        break;
                    }
                case OctaveEnum.Octave1:
                    {
                        break;
                    }
                case OctaveEnum.Octave2:
                    {
                        break;
                    }
                case OctaveEnum.Octave3:
                    {
                        break;
                    }
                case OctaveEnum.Octave4:
                    {
                        break;
                    }
                case OctaveEnum.Octave5:
                    {
                        break;
                    }
                case OctaveEnum.Octave6:
                    {
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(note.Octave));
                    }
            }

            switch (note.NoteName.NameAscii[0])
            {
                case 'A':
                    {
                        break;
                    }
                case 'B':
                    {
                        break;
                    }
                case 'C':
                    {
                        break;
                    }
                case 'D':
                    {
                        break;
                    }
                case 'E':
                    {
                        break;
                    }
                case 'F':
                    {
                        break;
                    }
                case 'G':
                    {
                        break;
                    }
                default: throw new ArgumentOutOfRangeException(nameof(note.NoteName));
            }

            return result;
        }

        PointF ToPointF(TimedEventNote ten)
        {
            var result = PointF.Empty;
            var note = ten.Event;

            //Every Good Boy Does Fine & FACE 
            //Good Boys Do Fine Always and All Cows Eat Grass
            //
            switch (note)
            { 
                case Note.
            }
            return result;
        }
    }//class
}//ns


