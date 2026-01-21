using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Scales;

using NeckDiagrams.Domain;

namespace NeckDiagrams
{
    public partial class NeckControl : UserControl
    {
        const int FRET_COUNT = 13;
        const int CX_ELLIPSE = 30;

        #region Properties
        //GuitarStringCollection GuitarStringCollection { get; set; }
        //ChordFormula _ChordFormula { get; set; }
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public ChordFormula ChordFormula
        //{
        //    get { return this._ChordFormula; }
        //    set
        //    {
        //        this._ChordFormula = value;
        //        if (null != this._ChordFormula)
        //            this.SetChord();
        //    }
        //}

        public IChordShapeVM model;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IChordShapeVM Model
        {
            get { return this.model; }
            set
            {
                model = value;
            }
        }
        GuitarStringCollection GuitarStringCollection { get { return this.Model.GuitarStringCollection; } }

        public PrintDocument PrintDocument { get { return this.printDocument; } }

        #endregion

        #region Construction
        public NeckControl()
        {
            InitializeComponent();
            this.Load += this.NeckControl_Load;
            this.Layout += this.NeckControl_Layout;
        }

        private void NeckControl_Load(object sender, EventArgs e)
        {
            Init();
        }

        void Init()
        {
            if (this.Model == null)
            {
                this.Model = HarmonyHelper.IoC.Container.Resolve<IChordShapeVM>();
            }
            this.Model.PropertyChanged += Model_PropertyChanged;
            this.DataBindings.Add("Model", this.Model, null, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.Model.ChordFormula))
            {
                this.Model_ChordFormulaChanged(sender, this.Model.ChordFormula);
            }
        }
        private void Model_ChordFormulaChanged(object sender, ChordFormula e)
        {
            this.PopulateControls();
        }


        private void Model_ModelChanged(object sender, ChordShapeVM e)
        {
            this.PopulateControls();
        }

        private void Model_GuitarStringCollectionChanged(object sender, GuitarStringCollection e)
        {
            //Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        private void Model_GuitarStringModelChanged(object sender, GuitarStringVM e)
        {
            //Debug.WriteLine(e.ToString());
            //Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        void SetChord()
        {
            foreach (var gs in this.GuitarStringCollection.Dictionary.Values)
            {
                gs.SetActiveNotes(this.Model.ChordFormula.NoteNames);
            }
            //this.Model.ModelChanged += this.ModelChanged_Handler;

            this.Refresh();
        }


        #endregion

        void PopulateControls()
        {
            if (!DesignMode)
            {
                this.Controls.Clear();
                var ctls = new List<GuitarStringControl>();

                foreach (var gsModel in this.Model.GuitarStringCollection.Dictionary.Values)
                {
                    //this.Model.GuitarStringModelChanged += Model_GuitarStringModelChanged;
                    var ctlString = new GuitarStringControl(gsModel.GuitarStringNdx);
                    ctlString.Dock = DockStyle.Top;
                    //ctls.Insert(0, ctl);
                    ctls.Add(ctlString);
                }

                this.Controls.AddRange(ctls.ToArray());
                this.SetChord();
                this.PerformLayout();
            }
        }

        #region Windows Event Handlers
        private void NeckControl_MouseMove(object sender, MouseEventArgs e)
        {
#if false
			var graphics = Graphics.FromHwnd(this.Handle);
			var rc = new Rectangle(e.X - 50, e.Y - 50, e.X + 50, e.Y + 50);
			using (var font = new Font(FontFamily.GenericMonospace, 20))
			{
				graphics.FillRectangle(Brushes.White, new Rectangle(100, 100, 200, 50));
				graphics.DrawString($"X={e.X}, Y={e.Y}",
					font,
					Brushes.Black,
					new Point(100, 100));
			}
#endif
        }

        private void NeckControl_Layout(object sender, LayoutEventArgs e)
        {
            var cy = this.Height / 6;
            foreach (var ctl in this.Controls.Cast<Control>())
            {
                ctl.Height = cy;
                ctl.Width = this.Width;
            }
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            new object();
        }

        private void printDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            new object();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            this.OnPaint(new PaintEventArgs(e.Graphics, e.MarginBounds));
            new object();
        }

        private void printDocument_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {
            new object();
        }

        #endregion

        private void NeckControl_Paint(object sender, PaintEventArgs e)
        {
            var cxFret = this.Width / FRET_COUNT;
            List<int> cxFrets = new List<int>();
            for (int i = 0; i <= FRET_COUNT; ++i)
            {
                var l = (i * cxFret);
                cxFrets.Add(l);
            }
            var top = (this.Height / 2);

            var left = cxFrets.Skip(3).Take(1).First();
            DrawFretMarker(e, top, left);
            left = cxFrets.Skip(5).Take(1).First();
            DrawFretMarker(e, top, left);
            left = cxFrets.Skip(7).Take(1).First();
            DrawFretMarker(e, top, left);
            left = cxFrets.Skip(9).Take(1).First();
            DrawFretMarker(e, top, left);
            left = cxFrets.Skip(12).Take(1).First();
            DrawTwelfthFretMarker(e, top, left);
        }

        private void DrawFretMarker(PaintEventArgs e, int top, int left)
        {
            using var pen = this.CreatePen();
            using var brush = this.CreateBrush();

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.FillEllipse(brush,
                left - (CX_ELLIPSE / 2),
                top - (CX_ELLIPSE / 2),
                CX_ELLIPSE,
                CX_ELLIPSE);
        }

        private void DrawTwelfthFretMarker(PaintEventArgs e, int top, int left)
        {
            using var pen = this.CreatePen();
            using var brush = this.CreateBrush();

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            var cy = this.Height / 8; //8 is purely for aesthetic reasons.
            e.Graphics.FillEllipse(brush,
                left - (CX_ELLIPSE / 2),
                top - (CX_ELLIPSE / 2) - (cy * 2),
                CX_ELLIPSE,
                CX_ELLIPSE);
            e.Graphics.FillEllipse(brush,
                left - (CX_ELLIPSE / 2),
                top - (CX_ELLIPSE / 2) + (cy * 2),
                CX_ELLIPSE,
                CX_ELLIPSE);
        }

        Pen CreatePen()
        {
            return new Pen(SystemColors.ControlDarkDark);
        }

        Brush CreateBrush()
        {
            return new SolidBrush(SystemColors.ControlDarkDark);
        }


    }//class
}//ns
