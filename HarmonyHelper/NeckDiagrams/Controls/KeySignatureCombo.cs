using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison.Harmony;

namespace NeckDiagrams.Controls
{
    public class KeySignatureCombo : ComboBox
    {
        public event EventHandler<KeySignature> KeySignatureChanged;

        #region Construction
        public KeySignatureCombo()
        {
            this.Init();
        }

        void Init()
        {
            foreach (var key in KeySignature.Catalog)
            {
                this.Items.Add(key);
            }
        }

        #endregion

        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            var item = this.SelectedItem as KeySignature;
            if (null != item)
                this.OnKeySignatureChanged(item);
        }

        public void OnKeySignatureChanged(KeySignature key)
        {
            KeySignatureChanged?.Invoke(this, key);
        }

    }//class
}//ns
