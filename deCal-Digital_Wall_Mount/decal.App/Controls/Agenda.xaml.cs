using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using decal.Calendar.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace decal.App.Controls
{
    /// <summary>
    /// Interaction logic for Agenda.xaml
    /// </summary>
    public partial class Agenda : UserControl, INotifyPropertyChanged
    {
        private DateTime _date;

        public event PropertyChangedEventHandler PropertyChanged;

        public interface AbstractElement
        {
            Brush Colour { get; set; }
            double FontSize { get; set; }
        }

        public class AgendaTitle : AbstractElement
        {
            private Agenda _owner;
              
            public Brush Colour
            {
                get { return _owner.title.Foreground; }
                set { _owner.title.Foreground = value; }
            }

            public double FontSize
            {
                get { return _owner.title.FontSize; }
                set { _owner.title.FontSize = value; }
            }

            public AgendaTitle(Agenda parent)
            {
                _owner = parent;
            }
        }

        //public class AgendaAppointment : AbstractElement
        //{
        //    private Agenda _owner;

        //    public Brush Colour
        //    {
        //        get { return _owner.appts.ItemTemplate
        //        }

        //        set
        //        {
        //            throw new NotImplementedException();
        //        }
        //    }

        //    public double FontSize
        //    {
        //        get
        //        {
        //            throw new NotImplementedException();
        //        }

        //        set
        //        {
        //            throw new NotImplementedException();
        //        }
        //    }

        //    public class Time
        //    {
        //        private AgendaAppointment _owner;
                
        //        public class  

        //    }
        //}


        public AgendaTitle Title
        {
            get;
        }

        public DateTime SelectedDate
        {
            get { return _date; }
            set { SetField(_date, value); }
        }

        public ObservableCollection<Appointment> Appointments
        {
            get; set;
        }

        public Agenda()
        {
            InitializeComponent();
            Title = new AgendaTitle(this);

            /* testing */
            Appointments = new ObservableCollection<Appointment>();
            Appointments.Add(new Appointment(new Calendar.Appointment(new Calendar.User(), new Calendar.Client("John", "Smith", "905-001-01010"), DateTime.Now)));
            appts.ItemsSource = Appointments;
            System.Diagnostics.Debug.WriteLine(Appointments.Count);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected void SetField<T>(T field, T value, [CallerMemberName] string name = null)
        {
            if (field.Equals(value))
            {
                return;
            }

            field = value;

            OnPropertyChanged(name);
        }
    }
}
