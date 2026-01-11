using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Net.Mime.MediaTypeNames;

namespace NeckDiagrams.Controls
{
    public partial class ModalInterchangeGridControl : UserControl
    {
        public ModalInterchangeGridControl()
        {
            InitializeComponent();
            var nCols = this._panelMajor.ColumnCount - 1;
            var nRows = this._panelMajor.RowCount - 1;
            for (int ndxColumn = 1; ndxColumn < nCols; ndxColumn++)
            {
                for (int ndxRow = 1; ndxRow < nRows; ndxRow++)
                {
                    var tb = new TextBox() { ReadOnly = true, BorderStyle = BorderStyle.None };
                    this._panelMajor.Controls.Add(tb, ndxColumn, ndxRow);
                }
            }
        }

        public Control GetControl(int col, int row)
        {
            const int ZERO = 0;
            if (col < ZERO || col > this._panelMajor.ColumnCount)
                throw new ArgumentOutOfRangeException(nameof(col));
            if (row < ZERO || row > this._panelMajor.RowCount)
                throw new ArgumentOutOfRangeException(nameof(row));

            var result = this._panelMajor
                .GetControlFromPosition(col, row);
            return result;
        }
    }//class
}//ns
