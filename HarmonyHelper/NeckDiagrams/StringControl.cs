using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Eric.Morrison.Harmony;

namespace NeckDiagrams
{
	public partial class StringControl : UserControl, IModelObserver
	{
		NoteRange NoteRange { get; set; }
		List<NoteName> ActiveNotes { get; set; } = new List<NoteName>();
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
			var mp = this.FindForm() as IModelProvider;
			mp.ModelChanged += this.ModelChanged_Handler;
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

				this.UpdatePositions();
			}
		}

		private void UpdatePositions()
		{
			var ctls = this.Controls.Cast<StringPositionControl>();
			foreach (var ctl in ctls)
			{
				ctl.IsActive = this.ActiveNotes.Contains(ctl.Note.NoteName);
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

		public void ModelChanged_Handler(object sender, HarmonyModel model)
		{
			if (null != model.NoteNames)
			{
				this.ActiveNotes = model.NoteNames;
				this.UpdatePositions();
				this.Refresh();
			}
		}
	}//class
}//ns
