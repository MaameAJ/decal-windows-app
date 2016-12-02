using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace decal.Calendar.ViewModel
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetField<T> (T field, T value, [CallerMemberName] string name = null)
        {
            if(field.Equals(value))
            {
                return;
            }

            field = value;

            OnPropertyChanged(name);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
