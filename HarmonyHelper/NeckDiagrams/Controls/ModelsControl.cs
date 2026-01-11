using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeckDiagrams
{
	[Obsolete("", true)]
	public partial class ModelsControl : UserControl
	{
		HarmonyContext Model { get { return HarmonyHelper.IoC.Container.Resolve<IHarmonyContext>() as HarmonyContext; } }

		public ModelsControl()
		{
			InitializeComponent();
			this.Load += this.ModelItemsControl_Load;
		}

		private void ModelItemsControl_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				this.Model.ModelChanged += this.ModelChanged_Handler;
			}
		}

		public void ModelChanged_Handler(object sender, HarmonyContext model)
		{
			this.itemsPanel.Controls.Clear();
			foreach (var item in model.Items)
			{
				var control = new ModelItemControl(item);
				this.itemsPanel.Controls.Add(control);
			}
		}

	}//class
}//ns
