using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel; // Added for INotifyPropertyChanged

namespace ObservableObjectTest.forms
{
    public class NameValueVM : ObservableObject
    {
        static int counter = 0;
        public string name = string.Empty;
        public string value = string.Empty;
        public string Name
        {
            get => this.name;
            private set
            {
                if (SetProperty(ref name, value))
                {
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string Value
        {
            get => this.value;
            private set
            {
                if (SetProperty(ref this.value, value))
                {
                    OnPropertyChanged(nameof(Value));
                }
            }
        }

        public NameValueVM()
        {
            counter++;
            this.name = $"Name{counter}";
            this.value = $"Value{counter}";
        }
    }
}
