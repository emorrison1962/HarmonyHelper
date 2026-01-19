using CommunityToolkit.Mvvm.ComponentModel;
using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace NeckDiagrams.Domain
{
    public class NoteVM : ObservableObject
    {
        #region Fields
        Note note = null;
        Color color = Color.Empty;

        #endregion

        #region Properties
        public Note Note
        {
            get => this.note;
            private set
            {
                if (SetProperty(ref note, value))
                {
                    OnPropertyChanged(nameof(Note));
                }
            }
        }

        public Color Color
        {
            get => color;
            set
            {
                if (SetProperty(ref color, value))
                {
                    OnPropertyChanged(nameof(Color));
                }
            }
        }

        IntervalRoleTypeEnum intervalRoleType = IntervalRoleTypeEnum.Unknown;
        public IntervalRoleTypeEnum IntervalRoleType
        {
            get => intervalRoleType;
            set
            {
                if (SetProperty(ref intervalRoleType, value))
                {
                    OnPropertyChanged(nameof(IntervalRoleType));
                }
            }
        }

        #endregion    
    }
}
