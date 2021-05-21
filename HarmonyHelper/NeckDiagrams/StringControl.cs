using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace NeckDiagrams
{
	public partial class StringControl : UserControl
	{
		NoteRange NoteRange { get; set; }
		List<NoteName> ActiveNotes { get; set; }
		public int StringNumber { get; set; }

		public StringControl()
		{
			InitializeComponent();
			this.Load += this.StringControl_Load;
			this.Layout += this.StringControl_Layout;
		}
		public StringControl(int stringNum, NoteRange noteRange, List<NoteName> activeNotes)
			: this()
		{
			this.StringNumber = stringNum;
			this.NoteRange = noteRange;
			this.ActiveNotes = activeNotes;
		}

		private void StringControl_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				this.Controls.Clear();
				var ctls = new List<Control>();

				for (int i = 0; i < this.NoteRange.Notes.Count; ++i)
				{
					var note = this.NoteRange.Notes[i];
					var ctl = new StringPositionControl(i, note);
					ctl.Dock = DockStyle.Left;
					ctls.Insert(0, ctl);
				}

				this.Controls.AddRange(ctls.ToArray());

				var active = this.Controls.Cast<StringPositionControl>()
					.Where(x => this.ActiveNotes.Contains(x.Note.NoteName));
				foreach (var ctl in active)
				{
					ctl.IsActive = true;
				}
			}
		}

		private void StringControl_Layout(object sender, LayoutEventArgs e)
		{
			var cx = this.Width / 12;
			foreach (var ctl in this.Controls.Cast<Control>())
			{
				ctl.Width = cx;
			}
		}



	}//class
}//ns
