using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NeckDiagrams
{
	public partial class StringControl : UserControl
	{
		const int FRET_COUNT = 13;
		NoteRange NoteRange { get; set; }
		List<NoteName> ActiveNotes { get; set; } = new List<NoteName>();
		public int StringNumber { get; set; }
		HarmonyModel Model { get { return HarmonyHelper.IoC.Container.Resolve<IHarmonyModel>() as HarmonyModel; } }

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
			this.Model.ModelChanged += this.ModelChanged_Handler;

			if (!DesignMode)
			{
				this.Controls.Clear();
				var ctls = new List<Control>();

				for (int i = 0; i < FRET_COUNT; ++i)
				{
					var note = this.NoteRange.Notes.NextOrFirst(i);
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
			var cx = this.Width / FRET_COUNT;
			foreach (var ctl in this.Controls.Cast<Control>())
			{
				ctl.Width = cx;
				ctl.Height = this.Height;
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
