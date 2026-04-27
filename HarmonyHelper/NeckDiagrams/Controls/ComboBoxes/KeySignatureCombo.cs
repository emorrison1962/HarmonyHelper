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
        bool _MajorKeysOnly;
        bool _MinorKeysOnly;
        bool _SharpsOnly;
        bool _FlatsOnly;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool MajorKeysOnly { get=> _MajorKeysOnly; set { _MajorKeysOnly = value;  this.OnFilterChanged(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool MinorKeysOnly { get=>_MinorKeysOnly; set { _MinorKeysOnly = value; this.OnFilterChanged(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool SharpsOnly { get=> _SharpsOnly; set { _SharpsOnly = value; this.OnFilterChanged(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool FlatsOnly { get=> _FlatsOnly; set { _FlatsOnly = value; this.OnFilterChanged(); } }

        public event EventHandler<KeySignature> KeySignatureChanged;

        #region Construction
        public KeySignatureCombo()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            Init();
        }

        void OnFilterChanged()
        {
            Items.Clear();
            Init();
        }

        void Init()
        {
            foreach (var key in KeySignature.Catalog)
            {
                var omit = false;
                if (this.MajorKeysOnly) 
                {
                    if (key.IsMinor)
                        omit = true;
                }
                if (this.MinorKeysOnly) 
                {
                    if (key.IsMajor)
                        omit = true;
                }
                if (this.SharpsOnly) 
                {
                    if (key.UsesFlats)
                        omit = true;
                }
                if (this.FlatsOnly) 
                {
                    if (key.UsesSharps)
                        omit = true;
                }


                if (!omit)
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

}//ns
