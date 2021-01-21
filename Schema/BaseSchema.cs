using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Memenim.Core.Schema
{
    public abstract class BaseSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
