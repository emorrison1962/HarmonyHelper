using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Scales;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NeckDiagrams
{
	public partial class NeckControl : UserControl, IModelObserver
	{
		List<NoteRange> NoteRanges { get; set; } = new List<NoteRange>();
		Scale MusicalScale { get; set; }


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
				var mp = this.FindForm() as IModelProvider;
				mp.Model.ModelChanged += this.ModelChanged_Handler;


				this.Controls.Clear();
				var ctls = new List<StringControl>();

				var string1 = new NoteRange(
					new Note(NoteName.E, OctaveEnum.Octave3),
					new Note(NoteName.E, OctaveEnum.Octave4));

				var string2 = new NoteRange(
					new Note(NoteName.B, OctaveEnum.Octave3),
					new Note(NoteName.B, OctaveEnum.Octave4));

				var string3 = new NoteRange(
					new Note(NoteName.G, OctaveEnum.Octave2),
					new Note(NoteName.G, OctaveEnum.Octave3));

				var string4 = new NoteRange(
					new Note(NoteName.D, OctaveEnum.Octave2),
					new Note(NoteName.D, OctaveEnum.Octave3));

				var string5 = new NoteRange(
					new Note(NoteName.A, OctaveEnum.Octave1),
					new Note(NoteName.A, OctaveEnum.Octave2));

				var string6 = new NoteRange(
					new Note(NoteName.E, OctaveEnum.Octave1),
					new Note(NoteName.E, OctaveEnum.Octave2));

				this.NoteRanges = new List<NoteRange>()
				{ string1, string2, string3, string4, string5, string6 };

				for (int i = 0; i < this.NoteRanges.Count; ++i)
				{
					var noteRange = this.NoteRanges[i];
					var ctl = new StringControl(i, noteRange, new List<NoteName>());
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

		public void ModelChanged_Handler(object sender, HarmonyModel model)
		{
			new object();
		}
	}//class
}//ns
