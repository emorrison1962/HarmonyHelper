using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Harmony = Eric.Morrison.Harmony;

namespace HarmornyHelper.forms.Controls
{
	public class KeySignatureComboBox : ComboBox
	{
		public List<Harmony.KeySignature> Keys { get; set; } = new List<Harmony.KeySignature>();
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.PopulateKeysCombo();
		}
		void PopulateKeysCombo()
		{
			this.Keys = Harmony.KeySignature.MajorKeys;
			this.Items.AddRange(this.Keys.ToArray());
			if (!this.DesignMode)
			{
				this.SelectedItem = this.Keys[0];
				//this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			}
		}
		protected override void InitLayout()
		{
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.FlatStyle = FlatStyle.Standard;
		}


	}//class
}//ns
