using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace NeckDiagrams.Controls.Buttons
{
    [DesignTimeVisible(true)]
    public class FeatureTypeButton : RadioButton
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public FeatureType FeatureType { get; set; } = FeatureType.None;


        #region Construction
        public FeatureTypeButton()
        {
            this.CheckedChanged += this.FeatureTypeButton_CheckedChanged;
        }

        private void FeatureTypeButton_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public FeatureTypeButton(FeatureType ft)
        {
            FeatureType = ft;
        }

        #endregion


    }//class

}
