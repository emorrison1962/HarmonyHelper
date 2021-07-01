using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Eric.Morrison.Harmony;
#if false

key
scale

#endif

namespace NeckDiagrams
{
	public partial class StringPositionControl : UserControl, IModelObserver
	{
		public Note Note { get; set; }
		public int Position { get; set; }
		public bool IsActive { get; set; }
		public bool IsRoot { get; private set; }
		IModelProvider ModelProvider { get; set; }
		HarmonyModel Model { get { return ModelProvider?.Model; } }

		public StringPositionControl()
		{
			InitializeComponent();
			this.Load += this.StringPositionControl_Load;
		}

		private void StringPositionControl_Load(object sender, System.EventArgs e)
		{
			this.ModelProvider = this.FindForm() as IModelProvider;
			this.ModelProvider.Model.ModelChanged += this.ModelChanged_Handler;
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

				var xCenter = this.Width / 2;
				var yCenter = this.Height / 2;

				var cx = 20;
				var x = xCenter - cx / 2;
				var y = yCenter - cx / 2;

				var cy = this.Height / 3;

				e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				e.Graphics.FillEllipse(brush, x, y, cx, cx);
			}
		}

		public void ModelChanged_Handler(object sender, HarmonyModel model)
		{
			if (null != this.Note)
			{
				this.IsRoot = model.Items.Any(x => x.Root == this.Note.NoteName);
				if (this.IsRoot)
				{
					new object();
				}
			}
		}
	}//class
}//ns
