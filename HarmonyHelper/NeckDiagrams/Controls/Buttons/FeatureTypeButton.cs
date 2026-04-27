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
        }

        public FeatureTypeButton(FeatureType ft) :this()
        {
            FeatureType = ft;
        }

        #endregion


    }//class

}
