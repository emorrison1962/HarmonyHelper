using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cambia
{
	public static class ControlExtensions
	{
		public static Point FormRelativeLocation(this Control control, Form form = null)
		{
			if (form == null)
			{
				form = control.FindForm();
				if (form == null)
				{
					throw new Exception("Form not found.");
				}
			}

			foreach (var ctl in form.Controls.Cast<Control>())
			{
				Debug.WriteLine($"{ctl.Name}");
				Debug.WriteLine(form.PointToClient(ctl.PointToScreen(ctl.Location)).ToString());
			}

			Point cScreen = control.PointToScreen(control.Location);
			Point fScreen = form.Location;
			Point cFormRel = new Point(cScreen.X - fScreen.X, cScreen.Y - fScreen.Y);

			return cFormRel;

		}

	}
}