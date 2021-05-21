using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eric.Morrison;
using Eric.Morrison.Harmony;

namespace NeckDiagrams
{
	public partial class StringPositionControl : UserControl
	{
		public Note Note { get; set; }
		public int Position { get; set; }
		public bool IsActive { get; set; }
		public StringPositionControl()
		{
			InitializeComponent();
			var r = RandomValue.Next(127, 255);
			var g = RandomValue.Next(127, 255);
			var b = RandomValue.Next(127, 255);
			this.BackColor = Color.FromArgb(r, g, b);
		}

		public StringPositionControl(int position, Note note)
			: this()
		{
			this.Position = position;
			this.Note = note;
		}

		private void StringPositionControl_Paint(object sender, PaintEventArgs e)
		{
			if (!DesignMode)
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

				if ((this.Parent as StringControl)?.StringNumber == 0)
				{
					e.Graphics.DrawLine(Pens.Black,
						new Point(0, this.Height / 2),
						new Point(0, this.Height));
				}
				else if ((this.Parent as StringControl)?.StringNumber == 5)
				{
					e.Graphics.DrawLine(Pens.Black,
						new Point(0, 0),
						new Point(0, this.Height / 2));
				}
				else
				{
					e.Graphics.DrawLine(Pens.Black,
						new Point(0, 0),
						new Point(0, this.Height));
				}

				if (this.IsActive)
				{
					var xCenter = this.Width / 2;
					var yCenter = this.Height / 2;

					var cx = 20;
					var x = xCenter - cx / 2;
					var y = yCenter - cx / 2;

					var cy = this.Height / 3;

					e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
					e.Graphics.FillEllipse(Brushes.Black, x, y, cx, cx);
				}
			}
		}


	}//class
}//ns
