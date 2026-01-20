using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

using Eric.Morrison.Harmony;

namespace NeckDiagrams
{
	public partial class NoteComboBox : UserControl
	{
		public event EventHandler<Note> SelectionChanged;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Note SelectedNote 
		{ 
			get { return this._cbNoteName.SelectedItem as Note; }
			set { this._cbNoteName.SelectedItem = value; }  
		}
		public NoteComboBox()
		{
			InitializeComponent();
			this.Load += this.NoteComboBox_Load;

		}

		private void NoteComboBox_Load(object sender, EventArgs e)
		{
			if (!DesignMode) 
			{
				this.Populate();
			}
		}

		private void Populate()
		{
			this._cbNoteName.Items.Clear();

			var ll = new Note(NoteName.C, OctaveEnum.Octave0);
            var ul = new Note(NoteName.B, OctaveEnum.Octave6);
			var nr = new NoteRange(ll, ul);

            foreach (var n in nr.Notes)
			{
				this._cbNoteName.Items.Add(n);
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
					this.SelectionChanged(this, this._cbNoteName.SelectedItem as Note);
				}
			}
		}
	}//class
}//ns
