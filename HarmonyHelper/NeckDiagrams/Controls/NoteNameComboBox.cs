using System;
using System.Linq;
using System.Windows.Forms;
using Eric.Morrison.Harmony;

namespace NeckDiagrams
{
	public partial class NoteNameComboBox : UserControl
	{
		public event EventHandler<NoteName> SelectionChanged;
		public NoteName SelectedNoteName 
		{ 
			get { return this._cbNoteName.SelectedItem as NoteName; }
			set { this._cbNoteName.SelectedItem = value; }  
		}
		public NoteNameComboBox()
		{
			InitializeComponent();
			this.Load += this.NoteNameComboBox_Load;

		}

		private void NoteNameComboBox_Load(object sender, EventArgs e)
		{
			if (!DesignMode) 
			{
				this.Populate();
			}
		}

		private void Populate()
		{
			this._cbNoteName.Items.Clear();
			var set = KeySignature.Catalog
				.Select(x => x.NoteName)
				.ToList()
				.OrderBy(x => x)
				.ToHashSet(new NoteNameAlphaEqualityComparer());

			foreach (var nn in set)
			{
				this._cbNoteName.Items.Add(nn);
			}
		}

		private void _cbNoteName_SelectedValueChanged(object sender, EventArgs e)
		{
			this.OnSelectionChanged();
		}

		void OnSelectionChanged()
		{
			if (null != this.SelectionChanged)
			{
				if (null != this._cbNoteName.SelectedItem)
				{
					this.SelectionChanged(this, this._cbNoteName.SelectedItem as NoteName);
				}
			}
		}
	}//class
}//ns
