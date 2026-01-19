using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NeckDiagrams.Controls.ComboBoxes;

namespace NeckDiagrams.Controls
{
    public partial class NavPanelControl : UserControl
    {
        FeatureType _SelectedFeatureType = FeatureType.None;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FeatureType SelectedFeatureType
        {
            get { return this._SelectedFeatureType; }
            set
            {
                this._SelectedFeatureType = value;
                this.OnSelectedFeatureTypeChanged();

            }
        }

        public event EventHandler<FeatureType> SelectedFeatureTypeChanged;

        public NavPanelControl()
        {
            InitializeComponent();
        }


        private void _CheckedChanged(object sender, EventArgs e)
        {
            var bnFeature = sender as FeatureTypeButton;
            this.SelectedFeatureType = bnFeature.FeatureType;
        }

        void OnSelectedFeatureTypeChanged()
        {
            //Debug.WriteLine($"+{MethodBase.GetCurrentMethod().Name}");
            SelectedFeatureTypeChanged?.Invoke(this, this.SelectedFeatureType);
            //Debug.WriteLine($"-{MethodBase.GetCurrentMethod().Name}");
        }

        private void bnOptions_Click(object sender, EventArgs e)
        {
            var dlg = new OptionsDialog();
            dlg.ShowDialog();
        }
    }
}
