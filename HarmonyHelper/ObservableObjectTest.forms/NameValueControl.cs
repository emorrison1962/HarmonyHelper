using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace ObservableObjectTest.forms
{
    public partial class NameValueControl : UserControl
    {
        //NameValueVM

        public NameValueControl()
        {
            InitializeComponent();

            var vm = new NameValueVM();

            //this.DataContext = vm;
            _tbName.DataBindings.Add("Text", vm, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            _tbValue.DataBindings.Add("Text", vm, "Value", true, DataSourceUpdateMode.OnPropertyChanged);

        }
    }
}
