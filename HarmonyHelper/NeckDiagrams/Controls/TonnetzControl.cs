using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;

using HarmonyHelper.Chords.NeoRiemannianTheory;

using HarmonyHelper_DryWetMidi;

using Newtonsoft.Json.Serialization;

using Note = Eric.Morrison.Harmony.Note;

namespace NeckDiagrams.Controls
{
    public partial class TonnetzControl : UserControl
    {
        #region Fields
        // The center point of the control, used as the (0,0) origin for the grid.
        private Point _center;

        // The pixel distance between nodes; defines the "zoom" level of the grid.
        private int _spacing = 100;

        private ChordState? _startChord;
        private ChordState? _selectedChord = null;
        private Bitmap _clickMap;

        private List<ChordState> _currentPath { get; set; } = new List<ChordState>();

        private Point _lastClickedGrid = new Point(-100, -100); // Initialize off-screen
        string _lastClickedContext = null;
        private Dictionary<Color, ChordState> _colorToChord = new();
        private Dictionary<ChordState, Color> _chordToColor = new();
        private Dictionary<NoteName, Bitmap> _noteBmpCache = new Dictionary<NoteName, Bitmap>();

        #endregion

        #region Properties
        public Tonnetz Tonnetz { get; private set; }
        private ChordState? SelectedChord
        {
            get { return _selectedChord; }
            set
            {
                _selectedChord = value;
                this.Play();
            }
        }


        #endregion

        #region Construction
        public TonnetzControl()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.Tonnetz = new Tonnetz();
            this.Init();
        }
        private void TonnetzControl_Load(object sender, EventArgs e)
        {
            this.RenderClickMap();
        }

        void Init()
        {
            this.MapChordsToColors();
            this.CacheNoteNames(this.Font, Color.White);
        }

        #endregion

        private void CacheNoteNames(Font font, Color color)
        {
            foreach (var bmp in _noteBmpCache.Values)
                bmp.Dispose();
            _noteBmpCache.Clear();

            var nns = new List<NoteName> { NoteName.C, NoteName.Db, NoteName.D, NoteName.Eb, NoteName.E, NoteName.F, NoteName.Gb, NoteName.G, NoteName.Ab, NoteName.A, NoteName.Bb, NoteName.B };
            foreach (var nn in nns)
            {
                string text = nn.ToString(); // Or note.Symbol
                Size size = TextRenderer.MeasureText(text, font, Size.Empty, TextFormatFlags.NoPadding);

                Bitmap bmp = new Bitmap(Math.Max(1, size.Width), Math.Max(1, size.Height));
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Transparent);
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    TextRenderer.DrawText(g, text, font, Point.Empty, color, TextFormatFlags.NoPadding);
                }
                _noteBmpCache[nn] = bmp;
            }
        }

        // Maps your Point (5ths, Maj3rds) to actual screen pixels
        private PointF old_GridToScreen(Point gridPos, Point center, int spacing)
        {
            // The "Skew" factor (spacing * 0.5f) is what turns a square grid into triangles.
            float x = center.X + (gridPos.X * spacing) + (gridPos.Y * spacing * 0.5f);
            float y = center.Y - (gridPos.Y * spacing);
            return new PointF(x, y);
        }

        public PointF GridToScreen(Point gridPos, Point center, int spacing)
        {
            // 1. Vertical move (Major Thirds)
            float y = gridPos.Y * spacing;

            // 2. Horizontal move (Fifths) + Skew 
            // We use (spacing * 0.5f) to ensure the triangles are equilateral/cleanly skewed
            float x = (gridPos.X * spacing) + (gridPos.Y * (spacing * 0.5f));

            return new PointF(center.X + x, center.Y + y);
        }

        private PointF[] GetTrianglePoints(Point gridPos, bool isMajor, Point center, int spacing)
        {
            // CRITICAL: We pass the loop's 'center' and 'spacing' through
            PointF p1 = GridToScreen(gridPos, center, spacing);
            PointF p2, p3;

            if (isMajor)
            {
                // Major: (Root) -> (Fifth) -> (Major 3rd)
                p2 = GridToScreen(new Point(gridPos.X + 1, gridPos.Y), center, spacing);
                p3 = GridToScreen(new Point(gridPos.X, gridPos.Y + 1), center, spacing);
            }
            else
            {
                // Minor: (Root) -> (Fourth/Fifth down) -> (Minor 3rd down)
                // This closes the "backside" of the major triad
                p2 = GridToScreen(new Point(gridPos.X - 1, gridPos.Y), center, spacing);
                p3 = GridToScreen(new Point(gridPos.X, gridPos.Y - 1), center, spacing);
            }

            return new[] { p1, p2, p3 };
        }


        public Point ScreenToGrid(PointF mousePos, Point center, int spacing)
        {
            // 1. Center the coordinates relative to your grid origin
            float relativeX = mousePos.X - center.X;
            float relativeY = mousePos.Y - center.Y;

            // 2. Solve for X (Perfect Fifths)
            // We reverse: screenX = center.X + (gridX * spacing) + (gridY * spacing * 0.5f)
            // Note: We solve for gridX and gridY as a system.

            // Reverse the Y-axis inversion first (screen Y increases downward)
            float gridY = -relativeY / spacing;

            // Remove the X-skew caused by the Y-position before solving for X
            float gridX = (relativeX - (gridY * spacing * 0.5f)) / spacing;

            // 3. Round to the nearest whole grid coordinate to "snap" to a vertex
            var result = new Point(
                (int)Math.Round(gridX),
                (int)Math.Round(gridY));
            return result;
        }

        void DebugClickEvent(MouseEventArgs e)
        {
#if DEBUG
            // Convert Mouse Pixel -> Grid Coordinate (X, Y)
            _lastClickedGrid = ScreenToGrid(e.Location, _center, _spacing);

            // For debugging: print the mapping
            var note = GetNoteAtGridPoint(_lastClickedGrid);
            _lastClickedContext = $"Mouse: {e.Location} -> Grid: {_lastClickedGrid} -> Note: {note}";
            Console.WriteLine($"Mouse: {e.Location} -> Grid: {_lastClickedGrid} -> Note: {note}");
            new object();

            // 1. Convert Pixels -> Grid Point (Discrete x,y)
            Point gridCoord = ScreenToGrid(e.Location, _center, _spacing);

            // 2. Convert Grid Point -> NoteName
            NoteName clickedNote = GetNoteAtGridPoint(gridCoord);
            Console.WriteLine($"Selected {clickedNote} at Grid({gridCoord.X}, {gridCoord.Y})");
#endif
        }

        private void TonnetzControl_SizeChanged(object sender, EventArgs e)
        {
            //_spacing = this.Size.Width / THIRTEEN;
            _center = new Point(this.Width / 2, this.Height / 2);

            this.RenderClickMap();
        }


        /// <summary>
        /// Populates the bi-directional dictionaries linking unique pixel colors 
        /// to specific musical chords at unique grid locations.
        /// </summary>
        /// <param name="range">The number of grid units to map in each direction from the center.</param>
        public void MapChordsToColors(int range = 10)
        {
            _colorToChord.Clear();
            _chordToColor.Clear();

            // The ID counter generates a unique integer for every triangle on the grid.
            // We skip 0 because Color.FromArgb(0,0,0) is typically used for the background.
            int idCounter = 1;

            for (int x = -range; x <= range; x++)
            {
                for (int y = -range; y <= range; y++)
                {
                    Point currentPt = new Point(x, y);
                    NoteName rootNote = GetNoteAtGridPoint(currentPt);

                    // 1. Register the Major Triad at this specific coordinate
                    var majorState = new ChordState(rootNote, ChordIntervalsEnum.Major, currentPt);
                    RegisterChordWithUniqueColor(majorState, idCounter++);

                    // 2. Register the Minor Triad at this specific coordinate
                    var minorState = new ChordState(rootNote, ChordIntervalsEnum.Minor, currentPt);
                    RegisterChordWithUniqueColor(minorState, idCounter++);
                }
            }
        }

        /// <summary>
        /// Helper to generate a unique Color ID and map it to a ChordState.
        /// </summary>
        private void RegisterChordWithUniqueColor(ChordState state, int id)
        {
            // Convert the unique integer ID into an ARGB Color.
            // This allows for up to 16.7 million unique triangles (2^24).
            Color idColor = Color.FromArgb(
                255,                 // Alpha: Fully Opaque
                (id >> 16) & 0xFF,   // Red channel
                (id >> 8) & 0xFF,    // Green channel
                id & 0xFF            // Blue channel
            );

            
            _chordToColor[state] = idColor;
            _colorToChord[idColor] = state;
#warning FIXME:
            if (state.Formula == ChordFormula.AMinor)
            {
                Debug.WriteLine(idColor);
                new object();
            }

        }

        private void RenderClickMap()
        {
            if (_clickMap == null || _clickMap.Size != this.Size)
            {
                _clickMap?.Dispose();
                _clickMap = new Bitmap(this.Width, this.Height);
            }

            using (Graphics g = Graphics.FromImage(_clickMap))
            {
                g.SmoothingMode = SmoothingMode.None; // Essential for pure colors
                g.Clear(Color.Black);

                // Use the same loop range as your DrawTonnetz
                for (int x = -12; x <= 12; x++)
                {
                    for (int y = -12; y <= 12; y++)
                    {
                        Point gridPt = new Point(x, y);

                        // 1. MAJOR Triangle (Anchor to this vertex)
                        var majNrt = GetNrtFromGridPoint(gridPt, true);
                        var majState = new ChordState(majNrt.Root, majNrt.ChordType, gridPt);
                        if (_chordToColor.TryGetValue(majState, out Color majColor))
                        {
                            using (var brush = new SolidBrush(majColor))
                                g.FillPolygon(brush, GetTrianglePoints(gridPt, true, _center, _spacing));
                        }

                        // 2. MINOR Triangle (Apply the Neighbor Fix)
                        // We use (x - 1, y) to match the visual "Fm/Am" label logic
                        Point minorRootPt = new Point(x - 1, y);
                        var minNrt = GetNrtFromGridPoint(minorRootPt, false);

                        // CRITICAL: The State must use the minorRootPt so the lookup finds the right chord
                        var minState = new ChordState(minNrt.Root, minNrt.ChordType, minorRootPt);

                        if (_chordToColor.TryGetValue(minState, out Color minColor))
                        {
                            // We still draw the triangle using gridPt because GetTrianglePoints(false) 
                            // handles the physical offset, but the IDENTITY is from minorRootPt.
                            using (var brush = new SolidBrush(minColor))
                                g.FillPolygon(brush, GetTrianglePoints(gridPt, false, _center, _spacing));
                        }
                    }
                }
            }
        }

        private void CalculateVisibleGridRange(out int minX, out int maxX, out int minY, out int maxY)
        {
            // Use _spacing directly as the pixel distance
            int horizontalUnits = (int)Math.Ceiling(this.Width / (float)_spacing) + 2;
            int verticalUnits = (int)Math.Ceiling(this.Height / (float)_spacing) + 2;

            int centerGridX = (int)(_center.X / _spacing);
            int centerGridY = (int)(_center.Y / _spacing);

            minX = -centerGridX - 2;
            maxX = minX + horizontalUnits;

            minY = -centerGridY - 2;
            maxY = minY + verticalUnits;
        }

        private void DrawChordToClickMap(Graphics g, int x, int y, bool isMajor)
        {
            var gridPt = new Point(x, y);

            // 1. Get the musical identity
            NoteName note = GetNoteAtGridPoint(new Point(x, y));
            var nrt = GetNrtFromGridPoint(new Point(x, y));
            var state = new ChordState(nrt.Root, nrt.ChordType, gridPt);

            // 2. YOUR CODE GOES HERE: Look up the unique ID color
            if (_chordToColor.TryGetValue(state, out Color idColor))
            {
                // 3. Get the physical points on screen
                PointF[] trianglePoints = GetTrianglePoints(new Point(x, y), isMajor, _center, _spacing);

                // 4. Fill the hidden triangle with the ID color
                using (Brush b = new SolidBrush(idColor))
                {
                    g.FillPolygon(b, trianglePoints);
                }
            }
        }

        Region GetTriangleRegion(Point gridPos, bool isMajor)
        {
            // Reuse your existing logic to get the three vertices
            PointF[] points = GetTrianglePoints(gridPos, isMajor, _center, _spacing);

            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(points);

            return new Region(path);
        }

        void Play()
        {
            var formula = _selectedChord.Value.Formula;
            var chord = new Chord(formula, NoteRange.Default);

            Debug.Assert(chord.Notes.Count == 3, "We shouldn't have more than 3 notes in a triad.");  
            this.MidiSender.Play(chord);
        }

        MidiEventsSender _MidiSender = null;
        private bool disposedValue;

        MidiEventsSender MidiSender
        {
            get
            {
                if (this._MidiSender == null)
                    this._MidiSender = new MidiEventsSender();
                return this._MidiSender;
            }
        }

        void Stop()
        {
            var formula = _selectedChord.Value.Formula;
            var chord = new Chord(formula, new NoteRange(new Note(NoteName.C, OctaveEnum.Octave4),
                new Note(NoteName.C, OctaveEnum.Octave5)));

            this.MidiSender.Stop(chord);
        }

        ChordState? GetSelectedChord(MouseEventArgs e)
        {
            ChordState? result = null;

            // 1. Get the pixel color from our hidden "Click Map"
            Color clickedColor = _clickMap.GetPixel(e.X, e.Y);

            // 2. Background Check (Opaque Black/Transparent check)
            if (clickedColor.A == 0 || clickedColor.ToArgb() == Color.FromArgb(255, 0, 0, 0).ToArgb())
            {
                throw new InvalidOperationException($"Clicked color {clickedColor} not found in _colorToChord dictionary.");
            }

            // 3. Identification via Dictionary
            if (_colorToChord.TryGetValue(clickedColor, out ChordState selectedChord))
            {
                result = selectedChord;
                this._selectedChord = selectedChord;
            }

            if (null == result)
                throw new InvalidOperationException($"Clicked color {clickedColor} not found in _colorToChord dictionary.");

            return result;
        }

        private void TonnetzPanel_MouseClick(object sender, MouseEventArgs e)
        {
            // Force focus so the control can receive keyboard events like 'Esc'
            this.Focus();

        }

        private void TonnetzControl_MouseDown(object sender, MouseEventArgs e)
        {
            _startChord = this.GetSelectedChord(e);
            Invalidate(); //YES!
            this.Play();
        }

        private void TonnetzControl_MouseUp(object sender, MouseEventArgs e)
        {
            this.Stop();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_DESTROY = 0x0002;

            if (m.Msg == WM_DESTROY)
            {
                if (null != this._MidiSender)
                {
                    this._MidiSender.Dispose();
                    this._MidiSender = null;
                }
            }

            base.WndProc(ref m);
        }

    }//class

    public static class Extensions
    {
        static List<uint> PitchClasses = new List<uint> { NoteName.C.RawValue, NoteName.Db.RawValue, NoteName.D.RawValue, NoteName.Eb.RawValue, NoteName.E.RawValue, NoteName.F.RawValue, NoteName.Gb.RawValue, NoteName.G.RawValue, NoteName.Ab.RawValue, NoteName.A.RawValue, NoteName.Bb.RawValue, NoteName.B.RawValue };

        public static ChordFormula ToChordFormula(this TonnetzNode src)
        {
            var result = src.NrtFormula.Formula;
            return result;
        }

        public static int ToPitchClass(this NoteName src)
        {
            var result = PitchClasses.IndexOf(src.RawValue);

            if (result == -1)
                throw new InvalidOperationException($"NoteName {src} not found in pitch class mapping.");
            return result;
        }

    }

}//ns


