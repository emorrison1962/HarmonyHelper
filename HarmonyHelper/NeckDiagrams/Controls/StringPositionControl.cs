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
		public Note Note { get; set; }
		public int Position { get; set; }
		public bool IsActive { get; set; }
		public bool IsRoot { get; private set; }
		HarmonyModel Model { get { return HarmonyHelper.IoC.Container.Resolve<IHarmonyModel>() as HarmonyModel; } }

		public StringPositionControl()
		{
			InitializeComponent();
			this.Load += this.StringPositionControl_Load;
		}

		private void StringPositionControl_Load(object sender, System.EventArgs e)
		{
			this.Model.ModelChanged += this.ModelChanged_Handler;
		}

		public StringPositionControl(int position, Note note)
			: this()
		{
			this.Position = position;
			Debug.Assert(null != note);
			this.Note = note;
		}

		[Flags]
		enum NoteTypeEnum
		{
			None = 0,
			ChordTone = 1,
			ScaleTone = 1 << 1
		}


		private void StringPositionControl_Paint(object sender, PaintEventArgs e)
		{
			if (!DesignMode)
			{
				Pen pen = Pens.Black;
				Brush brush = Brushes.Black;

				if ((this.Parent as StringControl)?.StringNumber == 0)
				{
					if (this.Position == 0)
					{
						var rc = new Rectangle(new Point(0, this.Height / 2), new Size(5, this.Height));
						e.Graphics.FillRectangle(brush, rc);
					}
					else
					{
						e.Graphics.DrawLine(pen,
							new Point(0, this.Height / 2),
							new Point(0, this.Height));
					}
				}
				else if ((this.Parent as StringControl)?.StringNumber == 5)
				{
					if (this.Position == 0)
					{
						var rc = new Rectangle(
							new Point(0, 0),
							new Size(5, this.Height / 2));
						e.Graphics.FillRectangle(brush, rc);
					}
					else
					{
						e.Graphics.DrawLine(Pens.Black,
						new Point(0, 0),
						new Point(0, this.Height / 2));
					}
				}
				else
				{
					if (this.Position == 0)
					{
						var rc = new Rectangle(
							new Point(0, 0),
							new Size(5, this.Height));
						e.Graphics.FillRectangle(brush, rc);
					}
					else
					{
						e.Graphics.DrawLine(Pens.Black,
						new Point(0, 0),
						new Point(0, this.Height));
					}
				}

				this.DrawText(e);
				this.DrawActiveDot(e);
			}
		}

		private void DrawText(PaintEventArgs e)
		{
			using (var font = new Font(FontFamily.GenericMonospace, 11))
			{
				var p1 = new Point(0, this.Height / 2);
				var p2 = new Point(this.Width, this.Height / 2);
				e.Graphics.DrawString($"{this.Note.ToString()}",
					font,
					Brushes.Black,
					new Point(0, 0));
				e.Graphics.DrawLine(Pens.Black, p1, p2);
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

					if (noteType == (NoteTypeEnum.ChordTone | NoteTypeEnum.ScaleTone))
					{
						pen = Pens.Purple;
						brush = Brushes.Purple;
					}
					else if (noteType == NoteTypeEnum.ScaleTone)
					{
						pen = Pens.Blue;
						brush = Brushes.Blue;
					}
					else if (noteType == NoteTypeEnum.ChordTone)
					{
						pen = Pens.Green;
						brush = Brushes.Green;
					}
				}

				brush = this.CreateBrush();

				var xCenter = this.Width / 2;
				var yCenter = this.Height / 2;

				var x = xCenter - CX_ELLIPSE / 2;
				var y = yCenter - CX_ELLIPSE / 2;

				var cy = this.Height / 3;

				e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				e.Graphics.FillEllipse(brush, x, y, CX_ELLIPSE, CX_ELLIPSE);
			}
		}

		const int CX_ELLIPSE = 20;

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
	}//class
}//ns
