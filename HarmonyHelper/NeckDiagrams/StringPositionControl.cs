using System.Diagnostics;
using System.Drawing;
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

		public StringPositionControl()
		{
			InitializeComponent();
			this.Load += this.StringPositionControl_Load;
		}

		private void StringPositionControl_Load(object sender, System.EventArgs e)
		{
			var mp = this.FindForm() as IModelProvider;
			mp.ModelChanged += this.ModelChanged_Handler;
		}

		public StringPositionControl(int position, Note note)
			: this()
		{
			this.Position = position;
			Debug.Assert(null != note);
			this.Note = note;
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

		private void DrawActiveDot(PaintEventArgs e)
		{
			if (this.IsActive)
			{
				Pen pen;
				Brush brush;
				if (this.IsRoot)
				{
					pen = Pens.Red;
					brush = Brushes.Red;
				}
				else
				{
					pen = Pens.Black;
					brush = Brushes.Black;
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
				this.IsRoot = this.Note.NoteName == model.ScaleFormula?.Root;
				if (this.IsRoot)
				{
					new object();
				}
			}
		}
	}//class
}//ns
