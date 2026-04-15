using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
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

using Manufaktura.Controls.Model;
using Manufaktura.Music.Model.MajorAndMinor;

using Newtonsoft.Json.Serialization;

namespace NeckDiagrams.Controls
{
    public partial class TonnetzControl : UserControl
    {
        #region Fields
        // The center point of the control, used as the (0,0) origin for the grid.
        private Point _center;

        // The pixel distance between nodes; defines the "zoom" level of the grid.
        private int _spacing = 100;

        // The chord the user starts from (e.g., C Major).
        private ChordState? _startChord = null;

        // The destination chord for the A* search (e.g., F# Minor).
        private ChordState? _targetChord = null;
        private List<ChordState> _currentPath { get; set; } = new List<ChordState>();

        private Point _lastClickedGrid = new Point(-100, -100); // Initialize off-screen
        string _lastClickedContext = null;
        private Dictionary<Color, ChordState> _colorToChord = new();
        private Dictionary<ChordState, Color> _chordToColor = new();


        #endregion

        #region Properties
        public Tonnetz Tonnetz { get; private set; }

        #endregion

        public TonnetzControl()
        {
            InitializeComponent();

            this.Tonnetz = new Tonnetz();
            this.MapChordsToColors();
        }

        #region Painting
        private void TonnetzControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            this.DrawTonnetz(g, _currentPath, this.Size.Width, this.Size.Height);
        }

        public void DrawTonnetz(Graphics g, List<ChordState> path, int width, int height)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias; // Beautiful smooth lines for the eye
            Point center = new Point(width / 2, height / 2);
            int spacing = _spacing;


            // 2. Draw the Selection Highlights (Visual feedback for the "Pro" click)
            HighlightSelectedChords(g, center, spacing);


            using Font chordFont = new Font("Arial", 12, FontStyle.Regular);
            using StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            // 1. Draw the Background Lattice & Chord Labels
            for (int x = -10; x <= 10; x++)
            {
                for (int y = -10; y <= 10; y++)
                {
                    Point gridPt = new Point(x, y);
                    PointF screenPos = GridToScreen(gridPt, center, spacing);

                    // Draw the lines (Fifths, Maj3rds, Min3rds)
                    DrawLatticeLines(g, screenPos, gridPt, center, spacing);

                    // Draw Chord Labels (Major and Minor)
                    var nn = GetNoteAtGridPoint(gridPt);
                    var node = this.Tonnetz.Nodes
                        .First(n => n.NrtFormula.Root == nn
                            && n.NrtFormula.IsMajor);
                    var nrtMajor = node.NrtFormula;
                    this.DrawChordLabel(g, nrtMajor, gridPt, center, spacing, Brushes.RoyalBlue, chordFont, sf);

                    node = this.Tonnetz.Nodes
                        .First(n => n.NrtFormula.Root == nn
                            && n.NrtFormula.IsMinor);
                    var nrtMinor = node.NrtFormula;
                    this.DrawChordLabel(g, nrtMinor, gridPt, center, spacing, Brushes.DarkRed, chordFont, sf);

                    // Draw the pitch node
                    g.FillEllipse(Brushes.LightGray, screenPos.X - 2, screenPos.Y - 2, 4, 4);
                }
            }

            // 3. Draw the Path
            if (path != null && path.Count > 1)
            {
                DrawPathLines(g, path, center, spacing);
            }

            this.DrawDebug(g);
        }

        private void DrawChordLabel(Graphics g, NrtChordFormula nrt, Point gridPt, Point center, int spacing, Brush brush, Font font, StringFormat sf)
        {
            PointF[] pts = GetTrianglePoints(gridPt, nrt.IsMajor);
            // Centroid of the triangle
            PointF chordCenter = new PointF((pts[0].X + pts[1].X + pts[2].X) / 3, (pts[0].Y + pts[1].Y + pts[2].Y) / 3);

            string label = nrt.IsMajor
                ? $"{nrt.Root.NameAscii}"
                : $"{nrt.Root.NameAscii}m";

            g.DrawString(label, font, brush, chordCenter, sf);
        }

        private void DrawPathLines(Graphics g, List<ChordState> path, Point center, int spacing)
        {
            if (path == null || path.Count < 2) return;

            using Pen pathPen = new Pen(Color.Orange, 4) { DashStyle = DashStyle.Solid, StartCap = LineCap.Round, EndCap = LineCap.ArrowAnchor };

            for (int i = 0; i < path.Count - 1; i++)
            {
                // 1. Calculate centers for current and next chord
                PointF start = GetChordCentroid(path[i].Root, path[i].ChordType, center, spacing);
                PointF end = GetChordCentroid(path[i + 1].Root, path[i + 1].ChordType, center, spacing);

                // 2. Draw the connection
                g.DrawLine(pathPen, start, end);

                // 3. Optional: Draw a small 'joint' circle at each chord center
                g.FillEllipse(Brushes.Orange, start.X - 4, start.Y - 4, 8, 8);
            }
        }
        private PointF GetChordCentroid(NoteName root, ChordIntervalsEnum type, Point center, int spacing)
        {
            // Find the specific grid position for this note (near the origin)
            Point gridPos = GetCoordinates(root);

            // Use your existing helper to get the 3 vertex pixels
            PointF[] vertices = GetTrianglePoints(gridPos, type == ChordIntervalsEnum.Major);

            // Calculate the average (Centroid)
            return new PointF(
                (vertices[0].X + vertices[1].X + vertices[2].X) / 3f,
                (vertices[0].Y + vertices[1].Y + vertices[2].Y) / 3f
            );
        }

        public Point GetCoordinates(NoteName root)
        {
            // We map the RawNoteValue (bitwise) to a fixed Point on the Tonnetz.
            // X = Perfect Fifths (7 semitones), Y = Major Thirds (4 semitones)
            var result = Point.Empty;
            switch (root.NameAscii)
            {
                case "C.": result = new Point(0, 0); break;
                case "G": result = new Point(1, 0); break;
                case "D": result = new Point(2, 0); break;
                case "A": result = new Point(3, 0); break;
                case "E": result = new Point(0, 1); break;
                case "B": result = new Point(1, 1); break;
                case "F#": result = new Point(2, 1); break; // F#
                case "Gb": result = new Point(2, 1); break; // F#
                case "Db": result = new Point(3, 1); break; // C#
                case "C#": result = new Point(3, 1); break; // C#
                case "Ab": result = new Point(0, -1); break;
                case "G#": result = new Point(0, -1); break;
                case "Eb": result = new Point(1, -1); break;
                case "D#": result = new Point(1, -1); break;
                case "Bb": result = new Point(2, -1); break;
                case "A#": result = new Point(2, -1); break;
                case "F": result = new Point(3, -1); break;

                default: throw new ArgumentOutOfRangeException(nameof(root));
            }
            ;
            return result;
        }


        private PointF GetCentroid(PointF[] pts) => new PointF((pts[0].X + pts[1].X + pts[2].X) / 3, (pts[0].Y + pts[1].Y + pts[2].Y) / 3);

        void DrawDebug(Graphics g)
        {
            // Inside DrawTonnetz at the very end
            //if (_lastClickedGrid.X != -100)
            {
                PointF debugPos = GridToScreen(_lastClickedGrid, _center, _spacing);

                using (Pen debugPen = new Pen(Color.Red, 3))
                {
                    // Draw a large circle around the "snapped" grid node
                    g.DrawEllipse(debugPen, debugPos.X - 10, debugPos.Y - 10, 20, 20);

                    // Fill a small dot exactly at the calculated vertex
                    g.FillEllipse(Brushes.Red, debugPos.X - 3, debugPos.Y - 3, 6, 6);

                    g.DrawString(_lastClickedContext, new Font("Arial", 30), Brushes.LightGray, 50, 50);
                    g.DrawString($"_spacing= {_spacing}", new Font("Arial", 30), Brushes.LightGray, 50, 100);
                }
            }

            this.DrawPathDebug(g);
        }

        private void DrawPathDebug(Graphics g)
        {
            var str = string.Join(", ", this._currentPath);
            g.DrawString(str, new Font("Arial", 30), Brushes.LightGray, 50, 150);
        }


        /// <summary>
        /// Draws the connecting interval lines of the Tonnetz lattice for a specific pitch node.
        /// </summary>
        /// <param name="g">The <see cref="Graphics""")/>> surface used for drawing.</param>
        /// <param name="screenPos">The calculated <see cref="PointF""")/>> pixel position of the current node.</param>
        /// <param name="gridPos">The <see cref="Point""")/>> representing the node's position in the Tonnetz coordinate space (X: Fifths, Y: Major Thirds).</param>
        /// <param name="center">The <see cref="Point""")/>> representing the screen's center origin.</param>
        /// <param name="spacing">The pixel distance between adjacent nodes in the grid.</param>
        /// <remarks>
        /// This method renders the three primary harmonic axes of the Tonnetz:
        /// <list type="bullet">
        /// <item><description>Horizontal: Perfect Fifths (7 semitones)</description></item>
        /// <item><description>Diagonal Up-Right: Major Thirds (4 semitones)</description></item>
        /// <item><description>Diagonal Down-Right: Minor Thirds (3 semitones)</description></item>
        /// </list>
        /// </remarks>
        private void DrawLatticeLines(Graphics g, PointF screenPos, Point gridPos, Point center, int spacing)
        {
            // Define pens for different intervals to make the grid readable
            using Pen fifthPen = new Pen(Color.FromArgb(50, Color.LightGray), 1);      // Horizontal
            using Pen maj3rdPen = new Pen(Color.FromArgb(50, Color.LightBlue), 1);    // Up-Right
            using Pen min3rdPen = new Pen(Color.FromArgb(50, Color.Orange), 1);  // Down-Right

            // 1. Draw Perfect Fifth Connection (Right)
            PointF rightNode = GridToScreen(new Point(gridPos.X + 1, gridPos.Y), center, spacing);
            g.DrawLine(fifthPen, screenPos, rightNode);

            // 2. Draw Major Third Connection (Up-Right)
            PointF upRightNode = GridToScreen(new Point(gridPos.X, gridPos.Y + 1), center, spacing);
            g.DrawLine(maj3rdPen, screenPos, upRightNode);

            // 3. Draw Minor Third Connection (Down-Right)
            // In our coordinate system (7x + 4y), the minor third (3 semitones) 
            // is achieved by moving +1 on X and -1 on Y: (7*1) + (4*-1) = 3.
            PointF downRightNode = GridToScreen(new Point(gridPos.X + 1, gridPos.Y - 1), center, spacing);
            g.DrawLine(min3rdPen, screenPos, downRightNode);
        }

        private void HighlightSelectedChords(Graphics g, Point center, int spacing)
        {
            // Draw Start Chord Highlight
            if (_startChord != null)
            {
                HighlightChord(g, _startChord, Color.FromArgb(120, Color.LimeGreen), center, spacing);
            }

            // Draw Target Chord Highlight
            if (_targetChord != null)
            {
                HighlightChord(g, _targetChord, Color.FromArgb(120, Color.Crimson), center, spacing);
            }
        }

        private void HighlightChord(Graphics g, ChordState? state, Color highlightColor, Point center, int spacing)
        {
            if (state == null)
                return;

            // 1. Get the triangle vertices based on the GridPosition stored in the state
            // This ensures it highlights the EXACT triangle you clicked, not just any "C Major"
            PointF[] points = GetTrianglePoints(state.Value.GridPosition, state.Value.Formula.IsMajor);

            // 2. Fill the triangle with a semi-transparent "glow"
            using (Brush fillBrush = new SolidBrush(Color.FromArgb(120, highlightColor)))
            {
                g.FillPolygon(fillBrush, points);
            }

            // 3. Draw a bold border to make it distinct
            using (Pen borderPen = new Pen(highlightColor, 3))
            {
                borderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                g.DrawPolygon(borderPen, points);
            }
        }

        private PointF GetChordCenter(Point gridPos, bool isMajor, Point center, int spacing)
        {
            // Use the specific gridPos passed in (e.g., 5, -3) 
            // instead of letting the NoteName snap it back to 0,0
            PointF p1 = GridToScreen(gridPos, center, spacing);
            PointF p2, p3;

            if (isMajor)
            {
                // Major: Root, Maj3rd (Y+1), Perf5th (X+1)
                p2 = GridToScreen(new Point(gridPos.X, gridPos.Y + 1), center, spacing);
                p3 = GridToScreen(new Point(gridPos.X + 1, gridPos.Y), center, spacing);
            }
            else
            {
                // Minor: Root, Maj3rd down (Y-1), Perf5th down (X-1)
                p2 = GridToScreen(new Point(gridPos.X, gridPos.Y - 1), center, spacing);
                p3 = GridToScreen(new Point(gridPos.X - 1, gridPos.Y), center, spacing);
            }

            return new PointF((p1.X + p2.X + p3.X) / 3f, (p1.Y + p2.Y + p3.Y) / 3f);
        }

        #endregion

        // Maps your Point (5ths, Maj3rds) to actual screen pixels
        private PointF GridToScreen(Point gridPos, Point center, int spacing)
        {
            // The "Skew" factor (spacing * 0.5f) is what turns a square grid into triangles.
            float x = center.X + (gridPos.X * spacing) + (gridPos.Y * spacing * 0.5f);
            float y = center.Y - (gridPos.Y * spacing);
            return new PointF(x, y);
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

        //private void TonnetzPanel_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (_clickMap == null)
        //        return;

        //    // Peek at the hidden pixel color
        //    Color pixel = _clickMap.GetPixel(e.X, e.Y);

        //    if (pixel.ToArgb() == Color.Black.ToArgb())
        //        return; // Clicked on background

        //    int semitone = pixel.R;
        //    bool isMajor = pixel.G == 1;

        //    NoteName note = NoteName.FromSemitone(semitone);
        //    var chordType = isMajor ? ChordIntervalsEnum.Major : ChordIntervalsEnum.Minor;

        //    // NEW: We can also store the grid X/Y in the Blue channel if we need 
        //    // to know EXACTLY which repeating C on the grid was clicked!

        //    _targetChord = new ChordState(note, chordType);
        //    this.Invalidate();
        //}

        //private void TonnetzPanel_MouseClick(object sender, MouseEventArgs e)
        //{
        //    // Force focus so Keyboard events (like Esc) work immediately
        //    this.Focus();

        //    // 1. Map pixels to musical grid
        //    Point gridCoord = ScreenToGrid(e.Location, _center, _spacing);
        //    NoteName clickedNote = GetNoteAtGridPoint(gridCoord);

        //    // 2. Create the state (Defaulting to Major, or use a toggle logic)
        //    var clickedState = new ChordState(clickedNote, ChordIntervalsEnum.Major);

        //    // 3. Update specific end of the path
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        _startChord = clickedState;
        //    }
        //    else if (e.Button == MouseButtons.Right)
        //    {
        //        _targetChord = clickedState;
        //    }

        //    // 4. Update path only if both are set
        //    if (_startChord != null && _targetChord != null)
        //    {
        //        _currentPath = FindShortestPath(_startChord, _targetChord);
        //    }
        //    DebugClickEvent(e);

        //    this.Invalidate();
        //}

        //List<ChordState> FindShortestPath(ChordState? startChord, ChordState? targetChord)
        //{
        //    var result = Task.Run(()=> this.Tonnetz.FindShortestPathAsync(
        //        startChord.GetValueOrDefault(),
        //        targetChord.GetValueOrDefault())).Result;
        //    return result;
        //}

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                // Clear all path data
                _startChord = null;
                _targetChord = null;
                _currentPath?.Clear();

                // Redraw to show the empty grid
                this.Invalidate();
            }
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

        public NoteName GetNoteAtGridPoint(Point gridCoord)
        {
            // 1. Calculate semitone 0-11
            int semitone = (7 * gridCoord.X + 4 * gridCoord.Y) % 12;
            if (semitone < 0)
                semitone += 12;

            // 2. Map semitone to your RawNoteValuesEnum bit (C=1<<1, Db=1<<2...)
            var rawValue = (NoteName.RawNoteValuesEnum)(1 << (semitone + 1));

            // 3. Find the matching NoteName from your static Catalog
            // This ensures you get the actual static instance (like NoteName.C)
            // and not a new disconnected object.
            var result = NoteName.Catalog
                .FirstOrDefault(n => n.RawValue == (int)rawValue
                    && n.IsSharped == false)
                   ?? NoteName.C; // Default to C if not found

            return result;
        }


        //private void UpdatePath()
        //{
        //    if (null != this._startChord && this._targetChord != null)
        //    {

        //        var startChord = new ChordState(new NrtChordFormula(this._startChord));
        //        var targetChord = new ChordState(new NrtChordFormula(this._targetChord));
        //        // Run the A* search we built earlier
        //        // This returns the sequence of chords (Nodes) to visit
        //        _currentPath = this.Tonnetz.FindShortestPath(startChord, targetChord);

        //        // Force the control to call the Paint/Draw method
        //        this.Invalidate();
        //    }
        //}

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
        }


        //private void TonnetzPanel_MouseClick(object sender, MouseEventArgs e)
        //{
        //    // Force focus so Keyboard events (like Esc) work immediately
        //    this.Focus();

        //    // 1. Get the color of the pixel exactly where the user clicked
        //    Color clickedColor = _clickMap.GetPixel(e.X, e.Y);

        //    if (_colorToChord.TryGetValue(clickedColor, out ChordState selectedChord))
        //    {
        //        // selectedChord ALREADY knows its GridPosition and Formula 
        //        // because we mapped them in MapChordsToColors.
        //        if (e.Button == MouseButtons.Left) 
        //            _startChord = selectedChord;
        //        if (e.Button == MouseButtons.Right) 
        //            _targetChord = selectedChord;

        //        this.Invalidate();
        //    }
        //}

        //private Rectangle GetTriangleBounds(PointF[] pts)
        //{
        //    float minX = pts.Min(p => p.X);
        //    float minY = pts.Min(p => p.Y);
        //    float maxX = pts.Max(p => p.X);
        //    float maxY = pts.Max(p => p.Y);

        //    // Add 2-3 pixels of padding to account for pen thickness
        //    return new Rectangle(
        //        (int)minX - 2,
        //        (int)minY - 2,
        //        (int)(maxX - minX) + 4,
        //        (int)(maxY - minY) + 4
        //    );
        //}

        private void TonnetzPanel_MouseClick(object sender, MouseEventArgs e)
        {
            // Force focus so the control can receive keyboard events like 'Esc'
            this.Focus();

            if (_clickMap == null) return;

            // 1. Get the pixel color from our hidden "Click Map"
            Color clickedColor = _clickMap.GetPixel(e.X, e.Y);

            // 2. Background Check (Opaque Black/Transparent check)
            if (clickedColor.A == 0 || clickedColor.ToArgb() == Color.FromArgb(255, 0, 0, 0).ToArgb())
                return;

            // 3. Identification via Dictionary
            if (_colorToChord.TryGetValue(clickedColor, out ChordState selectedChord))
            {
                // Capture the old area for invalidation before updating the state
                if (e.Button == MouseButtons.Left)
                {
                    if (_startChord != null)
                        Invalidate(GetTriangleBounds(GetTrianglePoints(_startChord.Value.GridPosition, _startChord.Value.Formula.IsMajor)));

                    _startChord = selectedChord;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (_targetChord != null)
                        Invalidate(GetTriangleBounds(GetTrianglePoints(_targetChord.Value.GridPosition, _targetChord.Value.Formula.IsMajor)));

                    _targetChord = selectedChord;
                }

                // 4. Update the "dirty" area for the NEW selection
                PointF[] newPts = GetTrianglePoints(selectedChord.GridPosition, selectedChord.Formula.IsMajor);
                Invalidate(GetTriangleBounds(newPts));

                // 5. If we have a path, we usually need to invalidate the whole thing 
                // since the lines stretch across multiple triangles.
                if (_startChord != null && _targetChord != null)
                {
                    // Note: If you add pathfinding back, you'll likely need a full Invalidate() 
                    // here unless you calculate a bounding box for the entire path.
                    //this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Calculates the bounding rectangle for a set of points to use for targeted invalidation.
        /// </summary>
        private Rectangle GetTriangleBounds(PointF[] pts)
        {
            float minX = pts[0].X;
            float minY = pts[0].Y;
            float maxX = pts[0].X;
            float maxY = pts[0].Y;

            for (int i = 1; i < pts.Length; i++)
            {
                if (pts[i].X < minX) minX = pts[i].X;
                if (pts[i].X > maxX) maxX = pts[i].X;
                if (pts[i].Y < minY) minY = pts[i].Y;
                if (pts[i].Y > maxY) maxY = pts[i].Y;
            }

            // Add padding for pen width and anti-aliasing
            return new Rectangle(
                (int)Math.Floor(minX) - 5,
                (int)Math.Floor(minY) - 5,
                (int)Math.Ceiling(maxX - minX) + 10,
                (int)Math.Ceiling(maxY - minY) + 10
            );
        }


        private Bitmap _clickMap;

        private void new_RenderClickMap()
        {
            _clickMap?.Dispose();
            _clickMap = new Bitmap(this.Width, this.Height);

            using (Graphics g = Graphics.FromImage(_clickMap))
            {
                g.SmoothingMode = SmoothingMode.None; // MUST be none for pixel-perfect IDs
                g.Clear(Color.Black);

                // Standard drawing loop
                for (int x = -10; x <= 10; x++)
                {
                    for (int y = -10; y <= 10; y++)
                    {
                        // Draw triangles using _chordToColor[state]
                        // and the same GridToScreen logic as your visible DrawTonnetz
                    }
                }
            }
        }
        private void RenderClickMap()
        {
            // Re-initialize bitmap if control size changed
            if (_clickMap == null || _clickMap.Size != this.Size)
            {
                _clickMap?.Dispose();
                _clickMap = new Bitmap(this.Width, this.Height);
            }

            using (Graphics g = Graphics.FromImage(_clickMap))
            {
                // MUST disable smoothing so pixel colors stay pure for dictionary lookup
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                g.Clear(Color.FromArgb(255, 0, 0, 0));

                for (int x = -10; x <= 10; x++)
                {
                    for (int y = -10; y <= 10; y++)
                    {
                        var gridPt = new Point(x, y);

                        // Draw Major triangle to hidden map
                        var nrt = GetNrtFromGridPoint(gridPt, true);
                        var majState = new ChordState(nrt.Root, nrt.ChordType, gridPt);
                        if (_chordToColor.TryGetValue(majState, out Color majColor))
                        {
                            g.FillPolygon(new SolidBrush(majColor), GetTrianglePoints(new Point(x, y), true));
                        }

                        // Draw Minor triangle to hidden map
                        nrt = GetNrtFromGridPoint(gridPt, false);
                        var minState = new ChordState(nrt.Root, nrt.ChordType, gridPt);
                        if (_chordToColor.TryGetValue(minState, out Color minColor))
                        {
                            g.FillPolygon(new SolidBrush(minColor), GetTrianglePoints(new Point(x, y), false));
                        }
                    }
                }
            }
        }

        NrtChordFormula GetNrtFromGridPoint(Point gridPt, bool isMajor)
        {
            NrtChordFormula result = null;
            var nn = GetNoteAtGridPoint(gridPt);
            TonnetzNode node = null;
            if (isMajor)
            {
                node = this.Tonnetz.Nodes
                    .First(n => n.NrtFormula.Root == nn
                        && n.NrtFormula.IsMajor);
            }
            else
            {
                node = this.Tonnetz.Nodes
                    .First(n => n.NrtFormula.Root == nn
                        && n.NrtFormula.IsMinor);
            }
            result = node.NrtFormula;
            return result;
        }

        NrtChordFormula GetNrtFromGridPoint(Point gridPt)
        {
            NrtChordFormula result = null;
            var nn = GetNoteAtGridPoint(gridPt);
            TonnetzNode node = null;

            node = this.Tonnetz.Nodes
                .First(n => n.NrtFormula.Root == nn);

            result = node.NrtFormula;
            return result;
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
                PointF[] trianglePoints = GetTrianglePoints(new Point(x, y), isMajor);

                // 4. Fill the hidden triangle with the ID color
                using (Brush b = new SolidBrush(idColor))
                {
                    g.FillPolygon(b, trianglePoints);
                }
            }
        }

        private PointF[] GetTrianglePoints(Point gridPos, bool isMajor)
        {
            // Vertex 1: The Root Note
            PointF p1 = GridToScreen(gridPos, _center, _spacing);
            PointF p2, p3;

            if (isMajor)
            {
                // Major triads point "downwards" in standard Tonnetz layouts
                // Connections: Root -> Major 3rd (Y+1) -> Perfect 5th (X+1)
                p2 = GridToScreen(new Point(gridPos.X, gridPos.Y + 1), _center, _spacing);
                p3 = GridToScreen(new Point(gridPos.X + 1, gridPos.Y), _center, _spacing);
            }
            else
            {
                // Minor triads point "upwards"
                // Connections: Root -> Major 3rd down (Y-1) -> Perfect 5th down (X-1)
                p2 = GridToScreen(new Point(gridPos.X, gridPos.Y - 1), _center, _spacing);
                p3 = GridToScreen(new Point(gridPos.X - 1, gridPos.Y), _center, _spacing);
            }

            return new[] { p1, p2, p3 };
        }

        private void TonnetzControl_Load(object sender, EventArgs e)
        {
            this.RenderClickMap();
        }


#if false

        private void UpdateClickMap(int width, int height, Point center, int spacing)
        {
            _clickMap?.Dispose();
            _clickMap = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(_clickMap))
            {
                g.SmoothingMode = SmoothingMode.None; // CRITICAL: No anti-aliasing!
                g.Clear(Color.Black); // Black = No Chord

                for (int x = -10; x <= 10; x++)
                {
                    for (int y = -10; y <= 10; y++)
                    {
                        int semitone = (7 * x + 4 * y) % 12;
                        if (semitone < 0) semitone += 12;

                        // Draw Major Triangle for this coord
                        DrawIdTriangle(g, new Point(x, y), true, semitone);
                        // Draw Minor Triangle for this coord
                        DrawIdTriangle(g, new Point(x, y), false, semitone);
                    }
                }
            }
        }

        private void DrawIdTriangle(Graphics g, Point gridPos, bool isMajor, int semitone)
        {
            PointF p1 = GridToScreen(gridPos, _center, _spacing);
            PointF p2, p3;

            if (isMajor)
            {
                p2 = GridToScreen(new Point(gridPos.X, gridPos.Y + 1), _center, _spacing);
                p3 = GridToScreen(new Point(gridPos.X + 1, gridPos.Y), _center, _spacing);
            }
            else
            {
                p2 = GridToScreen(new Point(gridPos.X, gridPos.Y - 1), _center, _spacing);
                p3 = GridToScreen(new Point(gridPos.X - 1, gridPos.Y), _center, _spacing);
            }

            // Encode ChordState into a Color
            // Red = Semitone (0-11), Green = Quality (0 or 1)
            Color idColor = Color.FromArgb(semitone, isMajor ? 1 : 0, 0);
            using (Brush b = new SolidBrush(idColor))
            {
                g.FillPolygon(b, new[] { p1, p2, p3 });
            }
        }

        HashSet<ChordState> ChordStateMap { get; set; } = new HashSet<ChordState>();
#endif

    }//class

    public static class Extensions
    {
        public static ChordFormula ToChordFormula(this TonnetzNode src)
        {
            var result = src.NrtFormula.Formula;
            return result;
        }
    }

}//ns


