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
        /// <summary>
        /// In standard tuning, a guitar's open strings from lowest to highest are E, A, D, G, B, E, covering approximately two octaves, with the low E (E2) and high E (E4) being an octave apart, and the middle strings (A, D, G, B) falling within the E2-E4 range, forming fundamental notes for playing music. An octave is 12 half-steps (frets) higher on the same string, with the 12th fret being the octave of the open string. 
        /// 
        /// E2 - 6th string (lowest)
        /// A2 - 5th string
        /// D3 - 4th string
        /// G3 - 3rd string
        /// B3 - 2nd string
        /// E4 - 1st string (highest)
        /// </summary>
        /// 

        #region Properties
        GuitarStringCollection MementoGuitarStringCollection { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public GuitarStringCollection GuitarStringCollection { get; set; }

        #endregion

        #region Construction

        public GuitarStringsControl()
        {
            this.Load += GuitarStringsControl_Load;
            InitializeComponent();

            this.noteComboBox6.SelectionChanged += ComboBox6_SelectionChanged;
            this.noteComboBox5.SelectionChanged += ComboBox5_SelectionChanged;
            this.noteComboBox4.SelectionChanged += ComboBox4_SelectionChanged;
            this.noteComboBox3.SelectionChanged += ComboBox3_SelectionChanged;
            this.noteComboBox2.SelectionChanged += ComboBox2_SelectionChanged;
            this.noteComboBox1.SelectionChanged += ComboBox1_SelectionChanged;
        }

        private void GuitarStringsControl_Load(object sender, EventArgs e)
        {
            this.GuitarStringCollection = GuitarStringCollection.LoadSettingsOrDefault();
            this.noteComboBox6.SelectedNote = this.GuitarStringCollection.Get(GuitarStringNdxEnum.Sixth).OpenNote;
            this.noteComboBox5.SelectedNote = this.GuitarStringCollection.Get(GuitarStringNdxEnum.Fifth).OpenNote;
            this.noteComboBox4.SelectedNote = this.GuitarStringCollection.Get(GuitarStringNdxEnum.Fourth).OpenNote;
            this.noteComboBox3.SelectedNote = this.GuitarStringCollection.Get(GuitarStringNdxEnum.Third).OpenNote;
            this.noteComboBox2.SelectedNote = this.GuitarStringCollection.Get(GuitarStringNdxEnum.Second).OpenNote;
            this.noteComboBox1.SelectedNote = this.GuitarStringCollection.Get(GuitarStringNdxEnum.First).OpenNote;
        }

        #endregion

        [Obsolete("", true)]
        public void Set(GuitarStringCollection coll)
        {
            this.GuitarStringCollection = coll;
            this.MementoGuitarStringCollection = GuitarStringCollection.Clone(coll);
            this.noteComboBox6.SelectedNote = coll.Get(GuitarStringNdxEnum.Sixth).OpenNote;
            this.noteComboBox5.SelectedNote = coll.Get(GuitarStringNdxEnum.Fifth).OpenNote;
            this.noteComboBox4.SelectedNote = coll.Get(GuitarStringNdxEnum.Fourth).OpenNote;
            this.noteComboBox3.SelectedNote = coll.Get(GuitarStringNdxEnum.Third).OpenNote;
            this.noteComboBox2.SelectedNote = coll.Get(GuitarStringNdxEnum.Second).OpenNote;
            this.noteComboBox1.SelectedNote = coll.Get(GuitarStringNdxEnum.First).OpenNote;
        }

        private void ComboBox6_SelectionChanged(object sender, Eric.Morrison.Harmony.Note nn)
        {
            UpdateGuitarString(nn, GuitarStringNdxEnum.Sixth);
        }

        private void ComboBox5_SelectionChanged(object sender, Eric.Morrison.Harmony.Note nn)
        {
            UpdateGuitarString(nn, GuitarStringNdxEnum.Fifth);
        }

        private void ComboBox4_SelectionChanged(object sender, Eric.Morrison.Harmony.Note nn)
        {
            UpdateGuitarString(nn, GuitarStringNdxEnum.Fourth);
        }

        private void ComboBox3_SelectionChanged(object sender, Eric.Morrison.Harmony.Note nn)
        {
            UpdateGuitarString(nn, GuitarStringNdxEnum.Third);
        }

        private void ComboBox2_SelectionChanged(object sender, Eric.Morrison.Harmony.Note nn)
        {
            UpdateGuitarString(nn, GuitarStringNdxEnum.Second);
        }

        private void ComboBox1_SelectionChanged(object sender, Eric.Morrison.Harmony.Note nn)
        {
            UpdateGuitarString(nn, GuitarStringNdxEnum.First);
        }

        private void UpdateGuitarString(Note note, GuitarStringNdxEnum ndx)
        {
            var guitarStr = this.GuitarStringCollection.Get(ndx);
            guitarStr.OpenNote = note;
        }



    }//class
}//ns
