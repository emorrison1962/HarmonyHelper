using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison.Harmony;

namespace NeckDiagrams.Controls.ComboBoxes
{
    public class KeySignatureCombo : ComboBox
    {
        public event EventHandler<KeySignature> KeySignatureChanged;

        #region Construction
        public KeySignatureCombo()
        {
            Init();
        }

        void Init()
        {
            foreach (var key in KeySignature.Catalog)
            {
                Items.Add(key);
            }
        }

        #endregion

        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            var item = SelectedItem as KeySignature;
            if (null != item)
                OnKeySignatureChanged(item);
        }

        public void OnKeySignatureChanged(KeySignature key)
        {
            KeySignatureChanged?.Invoke(this, key);
        }

    }//class

    [DesignTimeVisible(true)]
    public class FeatureTypeButton : RadioButton
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public FeatureType FeatureType{ get; set; } = FeatureType.None;


        #region Construction
        public FeatureTypeButton()
        {
        }

        
        public FeatureTypeButton(FeatureType ft)
        {
            FeatureType = ft;
        }

        #endregion


    }//class

}//ns
