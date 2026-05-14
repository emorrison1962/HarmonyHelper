using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

using HarmonyHelper.Chords.NeoRiemannianTheory;

namespace NeckDiagrams.Controls
{
    public partial class TonnetzControl /*: UserControl*/
    {
        #region Painting
        private void TonnetzControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            e.Graphics.Clear(this.BackColor);
            this.DrawTonnetz(g, _currentPath, this.Size.Width, this.Size.Height);
        }

        public void DrawTonnetz(Graphics g, List<ChordState> path, int width, int height)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            Point center = new Point(width / 2, height / 2);
            int spacing = _spacing;

            // 1. Setup Static Resources
            using Font chordFont = new Font("Arial", 9, FontStyle.Bold);
            using var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            using var vertexHaloPen = new Pen(Color.FromArgb(100, Color.LightGray), 1);

            // Use SystemBrushes carefully (don't dispose)
            Brush highlightBrush = SystemBrushes.Highlight;

            this.HighlightSelectedChords(g, center, spacing);


            // 2. Pass 1: Lattice and Chord Labels
            // We iterate through a range that covers the visible screen
            for (int x = -12; x <= 12; x++)
            {
                for (int y = -12; y <= 12; y++)
                {
                    Point gridPt = new Point(x, y);
                    PointF screenPos = GridToScreen(gridPt, center, spacing);
                    NoteName currentNote = GetNoteAtGridPoint(gridPt);

                    // A. Draw Lattice Lines (This closes the triangle shapes)
                    this.DrawLatticeLines(g, screenPos, gridPt, center, spacing);

                    // B. Draw Major Chord Label
                    // The Major triad rooted at currentNote (e.g. C -> C Major)
                    var majNode = this.Tonnetz.Nodes.First(n =>
                        n.NrtFormula.Root.EnharmonicallyEquals(currentNote) && n.NrtFormula.IsMajor);
                    this.DrawChordLabel(g, majNode.NrtFormula, gridPt, center, spacing, Brushes.White, chordFont, sf);

                    // C. Draw Minor Chord Label
                    // THE FIX: Find the correct root for the upward triangle rooted at (x,y).
                    // Based on your p1=(x,y), p2=(x-1,y), p3=(x,y-1), the "Root" of this 
                    // specific minor triad (the note it is named after) is (x-1, y).
                    Point minorRootPt = new Point(x - 1, y);
                    NoteName minorRootNote = GetNoteAtGridPoint(minorRootPt);

                    var minNode = this.Tonnetz.Nodes.First(n =>
                        n.NrtFormula.Root.EnharmonicallyEquals(minorRootNote) && n.NrtFormula.IsMinor);

                    // Draw the minor label using the current gridPt so it stays in the triangle
                    this.DrawChordLabel(g, minNode.NrtFormula, gridPt, center, spacing, Brushes.LightGray, chordFont, sf);
                }
            }

            // 3. Pass 2: Vertex Overlays (Notes)
            // Drawn last to ensure they are on top
            for (int x = -12; x <= 12; x++)
            {
                for (int y = -12; y <= 12; y++)
                {
                    Point gridPt = new Point(x, y);
                    NoteName currentNote = GetNoteAtGridPoint(gridPt);
                    this.DrawVertexLabel(g, currentNote, gridPt, vertexHaloPen, highlightBrush);
                }
            }

            // 4. Overlays
            if (path != null && path.Count > 1)
                DrawPathLines(g, path, center, spacing);

            this.DrawDebug(g);
        }

        public void old_DrawTonnetz(Graphics g, List<ChordState> path, int width, int height)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Point center = new Point(width / 2, height / 2);
            int spacing = _spacing;

            // 1. Setup Static Resources (Cached for performance)
            using Font chordFont = new Font("Arial", 12, FontStyle.Regular);
            using var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            using var vertexHaloPen = new Pen(Color.LightGray);

            // 2. Draw global selection highlights (background layer)
            this.HighlightSelectedChords(g, center, spacing);

            // 3. Main Grid Loop
            for (int x = -10; x <= 10; x++)
            {
                for (int y = -10; y <= 10; y++)
                {
                    Point gridPt = new Point(x, y);
                    PointF screenPos = GridToScreen(gridPt, center, spacing);
                    NoteName currentNote = GetNoteAtGridPoint(gridPt);

                    // A. Lattice Geometry
                    this.DrawLatticeLines(g, screenPos, gridPt, center, spacing);

                    // B. Chord Labels (Correcting the Minor "Off-by-one")
                    // Major triad associated with this vertex
                    var majNode = this.Tonnetz.Nodes.First(n => n.NrtFormula.Root.EnharmonicallyEquals(currentNote) && n.NrtFormula.IsMajor);
                    this.DrawChordLabel(g, majNode.NrtFormula, gridPt, center, spacing, Brushes.White, chordFont, sf);

                    {
                        // Minor triad logic: In a standard Tonnetz, the minor triad "m" 
                        // label usually needs to be anchored to a neighbor to center correctly.
                        // Adjust the gridPt here if your GetTrianglePoints(gridPt, false) uses offsets.
                        //var minNode = this.Tonnetz.Nodes.First(n => n.NrtFormula.Root.EnharmonicallyEquals(currentNote) && n.NrtFormula.IsMinor);
                        //var minorPt = new Point(gridPt.X - 1, gridPt.Y);
                        //this.DrawChordLabel(g, minNode.NrtFormula, minorPt, center, spacing, Brushes.White, chordFont, sf);
                        var minorPt = new Point(gridPt.X - 1, gridPt.Y);
                        // Second, get the note name for THAT specific point (e.g. if gridPt is C, minorPt might be A)
                        NoteName minorNote = GetNoteAtGridPoint(minorPt);
                        // Third, find the Minor chord for THAT root
                        var minNode = this.Tonnetz.Nodes.First(n =>
                            n.NrtFormula.Root.EnharmonicallyEquals(minorNote) && n.NrtFormula.IsMinor);
                        this.DrawChordLabel(g, minNode.NrtFormula, minorPt, center, spacing, Brushes.White, chordFont, sf);
                    }

                    // C. Vertex Visuals
                    g.FillEllipse(Brushes.LightGray, screenPos.X - 2, screenPos.Y - 2, 4, 4);
                    this.DrawVertexLabel(g, currentNote, gridPt, vertexHaloPen, SystemBrushes.Highlight);
                }
            }

            // 4. Path Overlay
            if (path != null && path.Count > 1)
            {
                DrawPathLines(g, path, center, spacing);
            }

            this.DrawDebug(g);
        }

        private void old_DrawChordLabel(Graphics g, NrtChordFormula nrt, Point gridPt, Point center, int spacing, Brush brush, Font font, StringFormat sf)
        {
#warning FIXME:
            if (nrt.Formula == ChordFormula.AMinor)
            {
                new object();
            }
            PointF[] pts = GetTrianglePoints(gridPt, nrt.IsMajor, center, spacing);

            // Use the new helper
            PointF chordCenter = GetTriangleCentroid(pts);

            string label = nrt.IsMajor
                ? $"{nrt.Root.NameAscii}"
                : $"{nrt.Root.NameAscii}m";

            g.DrawString(label, font, brush, chordCenter, sf);
        }
        private void DrawChordLabel(Graphics g, NrtChordFormula nrt, Point gridPt, Point center, int spacing, Brush brush, Font font, StringFormat sf)
        {
            // Pass center and spacing here!
            PointF[] pts = GetTrianglePoints(gridPt, nrt.IsMajor, center, spacing);
            PointF chordCenter = GetTriangleCentroid(pts);

            string label = nrt.IsMajor ? $"{nrt.Root.NameAscii}" : $"{nrt.Root.NameAscii}m";
            g.DrawString(label, font, brush, chordCenter, sf);
        }



        public void DrawVertexLabel(Graphics g, NoteName note, Point gridPos, Pen defaultHalo, Brush highlightHalo)
        {
            if (note == null)
                throw new ArgumentNullException(nameof(note));

            PointF screenPos = GridToScreen(gridPos, _center, _spacing);

            if (note != null && _noteBmpCache.TryGetValue(note, out Bitmap noteBmp))
            {
                // 1. Safe Selection Check: use ?. and Any() for pitch comparison
                if (_selectedChord?.NrtFormula.Formula == ChordFormula.AMajor && note == NoteName.Db)
                {
                    new object();
                }
                bool isSelected = _selectedChord?.NrtFormula.NoteNames
                                    .Any(n => n.ToPitchClass() == note.ToPitchClass()) ?? false;

                #region coordinates
                float diameter = Math.Max(noteBmp.Width, noteBmp.Height) + 6;
                float x = screenPos.X - (diameter / 2f);
                float y = screenPos.Y - (diameter / 2f);

                #endregion

                // 2. Fill first (if selected), then outline
                if (isSelected)
                {
                    g.FillEllipse(highlightHalo, x, y, diameter, diameter);
                }

                // Use the passed-in Pen for the boundary
                g.DrawEllipse(defaultHalo, x, y, diameter, diameter);

                // 3. Draw Note Name
                g.DrawImage(noteBmp,
                    screenPos.X - (noteBmp.Width / 2f),
                    screenPos.Y - (noteBmp.Height / 2f));
            }
            else
            {
                throw new Exception($"Note {note} not found in bitmap cache. Ensure all NoteNames are preloaded into _noteBmpCache.");
            }
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

        private void DrawLatticeLines(Graphics g, PointF screenPos, Point gridPos, Point center, int spacing)
        {
            using Pen fifthPen = new Pen(Color.FromArgb(100, Color.DimGray), 1);
            using Pen maj3rdPen = new Pen(Color.FromArgb(100, Color.SteelBlue), 1);
            using Pen min3rdPen = new Pen(Color.FromArgb(100, Color.Chocolate), 1);

            PointF pFifth = GridToScreen(new Point(gridPos.X + 1, gridPos.Y), center, spacing);
            PointF pMaj3rd = GridToScreen(new Point(gridPos.X, gridPos.Y + 1), center, spacing);

            // 1. Root to Fifth (X+1)
            g.DrawLine(fifthPen, screenPos, pFifth);
            // 2. Root to Major 3rd (Y+1)
            g.DrawLine(maj3rdPen, screenPos, pMaj3rd);
            // 3. Fifth to Major 3rd (This closes the triangle and creates the Minor 3rd axis)
            g.DrawLine(min3rdPen, pFifth, pMaj3rd);
        }

        private void HighlightSelectedChords(Graphics g, Point center, int spacing)
        {
            // Draw Start Chord Highlight
            if (_startChord != null)
            {
                var color = _startChord.Value.IsMajor ? Color.Crimson : Color.LimeGreen;
                HighlightChord(g, _startChord, color, center, spacing);
            }
        }

        private void HighlightChord(Graphics g, ChordState? state, Color highlightColor, Point center, int spacing)
        {
            if (state == null) return;

            // THE FIX:
            // If it's a Major chord, the GridPosition is the anchor.
            // If it's a Minor chord, we must shift the position +1 on X 
            // to find the vertex where GetTrianglePoints(false) draws the visual triangle.
            Point visualPos = state.Value.GridPosition;
            if (!state.Value.Formula.IsMajor)
            {
                visualPos = new Point(visualPos.X + 1, visualPos.Y);
            }

            // 1. Get the screen points using the visual anchor
            PointF[] points = GetTrianglePoints(visualPos, state.Value.Formula.IsMajor, center, spacing);

            // 2. Fill the triangle
            using (Brush fillBrush = new SolidBrush(Color.FromArgb(120, highlightColor)))
            {
                // Use FillPolygon instead of Region for better performance and anti-aliasing
                g.FillPolygon(fillBrush, points);
            }

            // 3. Draw a bold border
            using (Pen borderPen = new Pen(highlightColor, 3))
            {
                borderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                g.DrawPolygon(borderPen, points);
            }
        }

        private void old_HighlightChord(Graphics g, ChordState? state, Color highlightColor, Point center, int spacing)
        {
            if (state == null)
                return;

            // 1. Get the triangle vertices based on the GridPosition stored in the state
            // This ensures it highlights the EXACT triangle you clicked, not just any "C Major"
            Region region = GetTriangleRegion(state.Value.GridPosition, state.Value.Formula.IsMajor);

            // 2. Fill the triangle with a semi-transparent "glow"
            using (Brush fillBrush = new SolidBrush(Color.FromArgb(120, highlightColor)))
            {
                g.FillRegion(fillBrush, region);
            }

            // 3. Draw a bold border to make it distinct
            using (Pen borderPen = new Pen(highlightColor, 3))
            {
                borderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                g.DrawPolygon(borderPen, this.GetTrianglePoints(state.Value.GridPosition, state.Value.Formula.IsMajor, _center, _spacing));
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

        private void DrawTriangleToMap(Graphics g, Point pt, bool isMajor)
        {
            var nrt = GetNrtFromGridPoint(pt, isMajor);
            var state = new ChordState(nrt.Root, nrt.ChordType, pt);

            if (_chordToColor.TryGetValue(state, out Color color))
            {
                // Use a using block to avoid GDI handle leaks
                using (var brush = new SolidBrush(color))
                {
                    g.FillPolygon(brush, GetTrianglePoints(pt, isMajor, _center, _spacing));
                }
            }
        }

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
        #endregion

        public void GetTriangleBounds(PointF[] points, out float minX, out float maxX, out float minY, out float maxY)
        {
            // Initialize with the first point to handle comparison correctly
            minX = maxX = points[0].X;
            minY = maxY = points[0].Y;

            for (int i = 1; i < points.Length; i++)
            {
                if (points[i].X < minX) minX = points[i].X;
                if (points[i].X > maxX) maxX = points[i].X;
                if (points[i].Y < minY) minY = points[i].Y;
                if (points[i].Y > maxY) maxY = points[i].Y;
            }
        }

        /// <summary>
        /// Returns the screen centroid (average position) of the triangle formed by the chord's root, major third, and perfect fifth.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="type"></param>
        /// <param name="center"></param>
        /// <param name="spacing"></param>
        /// <returns></returns>
        private PointF GetChordCentroid(NoteName root, ChordIntervalsEnum type, Point center, int spacing)
        {
            // Find the specific grid position for this note (near the origin)
            Point gridPos = GetLocation(root);

            // Use your existing helper to get the 3 vertex pixels
            PointF[] vertices = GetTrianglePoints(gridPos, type == ChordIntervalsEnum.Major, center, spacing);

            // Calculate the average (Centroid)
            return new PointF(
                (vertices[0].X + vertices[1].X + vertices[2].X) / 3f,
                (vertices[0].Y + vertices[1].Y + vertices[2].Y) / 3f
            );
        }

        public Point GetLocation(NoteName root)
        {
            // We map the RawNoteValue (bitwise) to a fixed Point on the Tonnetz.
            // X = Perfect Fifths (7 semitones), Y = Major Thirds (4 semitones)
            var result = Point.Empty;
            switch (root.NameAscii)
            {
                case "C": result = new Point(0, 0); break;
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

            return result;
        }

        private int GetPitchClass(Point gridCoord)
        {
            // The modulo operator (%) in C# can return negative values for negative inputs.
            // This formula ensures we always get a valid pitch class between 0 and 11.
            int semitone = (7 * gridCoord.X + 4 * gridCoord.Y) % 12;
            var result = semitone < 0 ? semitone + 12 : semitone;
            if (result < 0 || result > 11)
                throw new Exception($"Invalid pitch class calculation: {result} for gridCoord {gridCoord}");
            return result;
        }

        NrtChordFormula GetNrtFromGridPoint(Point gridPt, bool isMajor)
        {
            NrtChordFormula result = null;
            var nn = GetNoteAtGridPoint(gridPt);
            TonnetzNode node = null;
            if (isMajor)
            {
                node = this.Tonnetz.Nodes
                    .First(n => n.NrtFormula.Root.EnharmonicallyEquals(nn)
                        && n.NrtFormula.IsMajor);
            }
            else
            {
                node = this.Tonnetz.Nodes
                    .First(n => n.NrtFormula.Root.EnharmonicallyEquals(nn)
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
                .First(n => n.NrtFormula.Root.EnharmonicallyEquals(nn));

            result = node.NrtFormula;
            return result;
        }

        public NoteName GetNoteAtGridPoint(Point gridCoord)
        {
            // 1. Calculate semitone 0-11
            int semitone = this.GetPitchClass(gridCoord);
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

        private PointF GetTriangleCentroid(PointF[] points)
        {
            // The centroid is the average of the x-coordinates and the average of the y-coordinates
            float x = (points[0].X + points[1].X + points[2].X) / 3f;
            float y = (points[0].Y + points[1].Y + points[2].Y) / 3f;

            return new PointF(x, y);
        }



    }//class
}//ns
