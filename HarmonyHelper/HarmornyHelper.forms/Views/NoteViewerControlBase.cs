using Manufaktura.Controls.Extensions;
using Manufaktura.Controls.Model;
using Manufaktura.Controls.WinForms;
using Manufaktura.Music.Model;
using Manufaktura.Music.Model.MajorAndMinor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Harmony = Eric.Morrison.Harmony;

namespace HarmornyHelper.forms.Controls
{
	public class NoteViewerControlBase : UserControl
	{
		protected NoteViewer NoteViewer { get; set; } = new NoteViewer();

		public NoteViewerControlBase()
		{
			// InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			this.Dock = System.Windows.Forms.DockStyle.Fill;
			base.OnLoad(e);

			//this.SuspendLayout();
			//this.ResumeLayout();

			this.NoteViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NoteViewer.CreateControl();
		}

		#region Initialization

		#endregion

	}//class
}//ns
