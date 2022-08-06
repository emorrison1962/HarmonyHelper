using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
#if false

key
scale

#endif

namespace NeckDiagrams
{
	public partial class StringPositionControl : UserControl
	{
		[Flags]
		enum NoteTypeEnum
		{
			None = 0,
			ChordTone = 1,
			ScaleTone = 1 << 1
		}

		public Note Note { get; set; }
		public int Position { get; set; }
		const int NUT = 0;
		public bool IsActive { get; set; }
		public bool IsRoot { get; private set; }
		HarmonyModel Model { get { return HarmonyHelper.IoC.Container.Resolve<IHarmonyModel>() as HarmonyModel; } }

		private NoteTypeEnum NoteType { get; set; }

		public StringPositionControl()
		{
			InitializeComponent();
			this.Load += this.StringPositionControl_Load;
		}

		private void StringPositionControl_Load(object sender, System.EventArgs e)
		{
			this.Model.ModelChanged += this.ModelChanged_Handler;
			this.Init();
		}

		public StringPositionControl(int position, Note note)
			: this()
		{
			this.Position = position;
			Debug.Assert(null != note);
			this.Note = note;
		}

		void Init()
		{
			this.GetNoteType();
			this._toolTip.Popup += this._toolTip_Popup;
			this._toolTip.InitialDelay = 1000;
			this._toolTip.ToolTipTitle = "FIXME";
			this._toolTip.ShowAlways = true;
			this._toolTip.SetToolTip(this, "FIXME_02");
		}

		private void _toolTip_Popup(object sender, PopupEventArgs e)
		{
			var noteType = NoteTypeEnum.None;
			if (this.Model.Items.Any(mi => mi.ModelType == ModelItemTypeEnum.Scale
				&& mi.NoteNames
					.Contains(this.Note.NoteName)))
			{
				noteType |= NoteTypeEnum.ScaleTone;

				//var scales = this.Model.Items.Where(x => x.ModelType == ModelItemTypeEnum.Scale);
				//foreach (var scale in scales)
				//{
				//	scale.ScaleFormula.GetFunction(this.Note.NoteName);
				//}
			}
			if (this.Model.Items.Any(mi => mi.ModelType == ModelItemTypeEnum.Arpeggio
				&& mi.NoteNames
					.Contains(this.Note.NoteName)))
			{
				noteType |= NoteTypeEnum.ChordTone;
			}

		}

		private void StringPositionControl_Paint(object sender, PaintEventArgs e)
		{
			if (!DesignMode)
			{
				this.DrawText(e);
				this.DrawFrets(e);
				this.DrawString(e);
				this.DrawActiveDot(e);
				//Debug_DrawBoundary(e);
			}
		}

		private void DrawString(PaintEventArgs e)
		{
			var cyString = this.Height / 2;
			var p1 = new Point(0, cyString);
			var p2 = new Point(this.Width, cyString);
			e.Graphics.DrawLine(Pens.Black, p1, p2);
		}

		private void DrawFrets(PaintEventArgs e)
		{
			Pen pen = Pens.Black;
			Brush brush = Brushes.Black;
			var cxFret = this.Width / 2;

			Rectangle rcNut = Rectangle.Empty;
			List<Point> fretPoints = null;

			if ((this.Parent as StringControl)?.StringNumber == 0)
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
			else if ((this.Parent as StringControl)?.StringNumber == 5)
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
				e.Graphics.FillRectangle(brush, rcNut);
			}
			else
			{
				e.Graphics.DrawLine(pen,
					fretPoints.First(),
					fretPoints.Last());
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
					Brushes.Black,
					new Point(x, y));
			}
		}

		private static void DrawYinYang(Graphics gr, int xctr, int yctr, int rmax, int rint, int ysmall, int rsmall)
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

		private void DrawActiveDot(PaintEventArgs e)
		{
			if (this.IsActive)
			{
				var pen = Pens.Magenta;
				var brush = Brushes.Magenta;
				if (this.IsRoot)
				{
					pen = Pens.Red;
					brush = Brushes.Red;
				}
				else
				{
					if (this.NoteType == (NoteTypeEnum.ChordTone | NoteTypeEnum.ScaleTone))
					{
						pen = Pens.Purple;
						brush = Brushes.Purple;
					}
					else if (this.NoteType == NoteTypeEnum.ScaleTone)
					{
						pen = Pens.Blue;
						brush = Brushes.Blue;
					}
					else if (this.NoteType == NoteTypeEnum.ChordTone)
					{
						pen = Pens.Green;
						brush = Brushes.Green;
					}
				}

				brush = this.CreateBrush();

				var xCenter = CX_ELLIPSE;
				var yCenter = this.Height / 2;

				var x = xCenter - CX_ELLIPSE / 2;
				var y = yCenter - CY_ELLIPSE / 2;

				e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				e.Graphics.FillEllipse(brush, x, y, CX_ELLIPSE, CX_ELLIPSE);
			}
		}

		const int CX_ELLIPSE = 20;
		const int CY_ELLIPSE = 20;

		Brush CreateBrush()
		{
			var items = this.Model.Items
				.Where(mi => mi.NoteNames.Contains(this.Note.NoteName))
				.ToList();
			if (items.Count == 1)
			{
				return new SolidBrush(items[0].Color);
			}

			var colors = items.Select(mi => mi.Color).ToList();
			if (colors.Count > 1)
			{
				if (colors[0].GetBrightness() > .5)
				{
					//we'll need to outline this dot.
				}
				new object();
			}
			var floats = new List<float>();
			for (int i = 0; i < colors.Count; ++i)
			{
				var f = 1 / (float)i;
				if (float.IsInfinity(f))
				{
					f = 0;
				}
				floats.Add(f);
			}
			new object();

			var rc = new Rectangle(0, 0, CX_ELLIPSE, CX_ELLIPSE);
			LinearGradientBrush result = new LinearGradientBrush(rc, Color.Black, Color.Black, 0, false);
			ColorBlend cb = new ColorBlend();
			cb.Positions = floats.ToArray();
			cb.Colors = colors.ToArray();
			//cb.Positions = new[] 
			//{ 0, 
			//	1 / 6f, 
			//	2 / 6f, 
			//	3 / 6f, 
			//	4 / 6f, 
			//	5 / 6f, 
			//	1 };
			//cb.Colors = new[] 
			//{ Color.Red, 
			//	Color.Orange, 
			//	Color.Yellow, 
			//	Color.Green, 
			//	Color.Blue, 
			//	Color.Indigo, 
			//	Color.Violet };
			result.InterpolationColors = cb;
			// rotate
			result.RotateTransform(45);
			return result;

		}


		public void ModelChanged_Handler(object sender, HarmonyModel model)
		{
			if (null != this.Note)
			{
				if (model.Items.Any(x => x.Root == this.Note.NoteName))
				{
					this.IsRoot = true;
				}
				else if (model.Items.Any(x => x.NoteNames.Contains(this.Note.NoteName)))
				{
					this.Refresh();
				}
			}
		}

		void GetNoteType()
		{
			var noteType = NoteTypeEnum.None;
			if (this.Model.Items.Any(mi => mi.ModelType == ModelItemTypeEnum.Scale
				&& mi.NoteNames
					.Contains(this.Note.NoteName)))
			{
				noteType |= NoteTypeEnum.ScaleTone;
			}
			if (this.Model.Items.Any(mi => mi.ModelType == ModelItemTypeEnum.Arpeggio
				&& mi.NoteNames
					.Contains(this.Note.NoteName)))
			{
				noteType |= NoteTypeEnum.ChordTone;
			}

			this.NoteType = noteType;
		}

		private void StringPositionControl_Layout(object sender, LayoutEventArgs e)
		{
		}

        public override bool PreProcessMessage(ref Message msg)
        {
			Debug.WriteLine(msg.Msg);
            return base.PreProcessMessage(ref msg);
        }

    }//class
}//ns
