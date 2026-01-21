using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
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
        public TableLayoutPanel TableLayoutPanel { get { return this._panelTableLayout; } }
        public ModalInterchangeGridControl()
        {
            InitializeComponent();
            var nCols = this._panelTableLayout.ColumnCount;
            var nRows = this._panelTableLayout.RowCount;
            for (int ndxColumn = 0; ndxColumn < nCols; ndxColumn++)
            {
                for (int ndxRow = 0; ndxRow < nRows; ndxRow++)
                {
                    var existing = _panelTableLayout.GetControlFromPosition(ndxColumn, ndxRow);
                    if (null == existing)
                    {
                        new object();
                        var tb = new TextBox() 
                        { ReadOnly = true, BorderStyle = BorderStyle.None, Dock = DockStyle.Fill };
                        this._panelTableLayout.Controls.Add(tb, ndxColumn, ndxRow);
                    }
                    else
                    {
                        Debug.WriteLine($"ndxColumn: {ndxColumn}, ndxRow: {ndxRow}");
                    }

                }
            }
        }

        public Control GetControl(int col, int row)
        {
            const int ZERO = 0;
            if (col < ZERO || col > this._panelTableLayout.ColumnCount)
                throw new ArgumentOutOfRangeException(nameof(col));
            if (row < ZERO || row > this._panelTableLayout.RowCount)
                throw new ArgumentOutOfRangeException(nameof(row));

            var result = this._panelTableLayout
                .GetControlFromPosition(col, row);
            Debug.Assert(null != result);
            return result;
        }
    }//class
}//ns
