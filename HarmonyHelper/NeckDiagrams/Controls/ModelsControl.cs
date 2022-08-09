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
	public partial class ModelsControl : UserControl
	{
		HarmonyModel Model { get { return HarmonyHelper.IoC.Container.Resolve<IHarmonyModel>() as HarmonyModel; } }

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

		public void ModelChanged_Handler(object sender, HarmonyModel model)
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
