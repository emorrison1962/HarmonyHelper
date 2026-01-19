using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Eric.Morrison.Harmony;

using NeckDiagrams.Domain;

namespace NeckDiagrams.Controls
{
    public partial class GuitarStringsControl : UserControl
    {
        GuitarStringCollection MementoGuitarStringCollection {  get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]

        public GuitarStringCollection GuitarStringCollection {  get; set; }
        public GuitarStringsControl()
        {
            InitializeComponent();
            this.noteNameComboBox6.SelectionChanged += ComboBox6_SelectionChanged;
            this.noteNameComboBox5.SelectionChanged += ComboBox5_SelectionChanged;
            this.noteNameComboBox4.SelectionChanged += ComboBox4_SelectionChanged;
            this.noteNameComboBox3.SelectionChanged += ComboBox3_SelectionChanged;
            this.noteNameComboBox2.SelectionChanged += ComboBox2_SelectionChanged;
            this.noteNameComboBox1.SelectionChanged += ComboBox1_SelectionChanged;
        }
        public void Set(GuitarStringCollection coll)
        {
            this.GuitarStringCollection = coll;
            this.MementoGuitarStringCollection = GuitarStringCollection.Clone(coll);
            this.noteNameComboBox6.SelectedNoteName = coll.Get(GuitarStringNdxEnum.Sixth).OpenNote.NoteName;
            this.noteNameComboBox5.SelectedNoteName = coll.Get(GuitarStringNdxEnum.Fifth).OpenNote.NoteName;
            this.noteNameComboBox4.SelectedNoteName = coll.Get(GuitarStringNdxEnum.Fourth).OpenNote.NoteName;
            this.noteNameComboBox3.SelectedNoteName = coll.Get(GuitarStringNdxEnum.Third).OpenNote.NoteName;
            this.noteNameComboBox2.SelectedNoteName = coll.Get(GuitarStringNdxEnum.Second).OpenNote.NoteName;
            this.noteNameComboBox1.SelectedNoteName = coll.Get(GuitarStringNdxEnum.First).OpenNote.NoteName;
        }

        private void ComboBox6_SelectionChanged(object sender, Eric.Morrison.Harmony.NoteName nn)
        {
            UpdateGuitarString(nn, GuitarStringNdxEnum.Sixth);
        }

        private void ComboBox5_SelectionChanged(object sender, Eric.Morrison.Harmony.NoteName nn)
        {
            UpdateGuitarString(nn, GuitarStringNdxEnum.Fifth);
        }

        private void ComboBox4_SelectionChanged(object sender, Eric.Morrison.Harmony.NoteName nn)
        {
            UpdateGuitarString(nn, GuitarStringNdxEnum.Fourth);
        }

        private void ComboBox3_SelectionChanged(object sender, Eric.Morrison.Harmony.NoteName nn)
        {
            UpdateGuitarString(nn, GuitarStringNdxEnum.Third);
        }

        private void ComboBox2_SelectionChanged(object sender, Eric.Morrison.Harmony.NoteName nn)
        {
            UpdateGuitarString(nn, GuitarStringNdxEnum.Second);
        }

        private void ComboBox1_SelectionChanged(object sender, Eric.Morrison.Harmony.NoteName nn)
        {
            UpdateGuitarString(nn, GuitarStringNdxEnum.First);
        }

        private void UpdateGuitarString(NoteName nn, GuitarStringNdxEnum ndx)
        {
            var guitarStr = this.GuitarStringCollection.Get(ndx);
            var octave = this.MementoGuitarStringCollection.Get(ndx).OpenNote.Octave;
            guitarStr.OpenNote = new Note(nn, octave);
        }



    }//class
}//ns
