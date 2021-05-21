using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NeckDiagrams
{
	public partial class NeckControl : UserControl
	{
		List<NoteRange> NoteRanges { get; set; } = new List<NoteRange>();
		Scale Scale { get; set; }


		public NeckControl()
		{
			InitializeComponent();
			this.Load += this.NeckControl_Load;
			this.Layout += this.NeckControl_Layout;
		}

		private void NeckControl_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				var key = KeySignature.AMinor;
				var formula = new PentatonicMinorScaleFormula(key);
				var noteNames = formula.NoteNames;

				this.Controls.Clear();
				var ctls = new List<StringControl>();

				var string1 = new NoteRange(
					new Note(NoteName.E, OctaveEnum.Octave3),
					new Note(NoteName.Eb, OctaveEnum.Octave4));

				var string2 = new NoteRange(
					new Note(NoteName.B, OctaveEnum.Octave3),
					new Note(NoteName.Bb, OctaveEnum.Octave4));

				var string3 = new NoteRange(
					new Note(NoteName.G, OctaveEnum.Octave2),
					new Note(NoteName.Gb, OctaveEnum.Octave3));

				var string4 = new NoteRange(
					new Note(NoteName.D, OctaveEnum.Octave2),
					new Note(NoteName.Db, OctaveEnum.Octave3));

				var string5 = new NoteRange(
					new Note(NoteName.A, OctaveEnum.Octave1),
					new Note(NoteName.Ab, OctaveEnum.Octave2));

				var string6 = new NoteRange(
					new Note(NoteName.E, OctaveEnum.Octave1),
					new Note(NoteName.Eb, OctaveEnum.Octave2));

				this.NoteRanges = new List<NoteRange>()
				{ string1, string2, string3, string4, string5, string6 };

				for (int i = 0; i < this.NoteRanges.Count; ++i)
				{
					var noteRange = this.NoteRanges[i];
					var ctl = new StringControl(i, noteRange, formula.NoteNames);
					ctl.Dock = DockStyle.Top;
					ctls.Insert(0, ctl);
				}

				this.Controls.AddRange(ctls.ToArray());
				this.PerformLayout();
			}
		}


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
	}//class
}//ns
