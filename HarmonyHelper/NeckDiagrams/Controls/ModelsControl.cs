using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison.Harmony;

namespace NeckDiagrams
{
	[Obsolete("", true)]
	public partial class ModelsControl<T> : UserControl where T : INoteNameContainer
    {
		HarmonyContext<T> Model { get { return HarmonyHelper.IoC.Container.Resolve<IHarmonyContext<junk>>() as HarmonyContext<T>; } }

		public ModelsControl()
		{
			InitializeComponent();
			this.Load += this.ModelItemsControl_Load;
		}

		private void ModelItemsControl_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
			}
		}

	}//class
}//ns
