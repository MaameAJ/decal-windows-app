using System;
using Model = decal.Calendar;

namespace decal.Calendar.ViewModel
{
    public class Reminder : ViewModel
    {
        private Model.Reminder _model;

        public Model.Appointment Owner
        {
            get { return _model.Owner; }
        }

        public DateTime Time
        {
            get { return _model.Time; }
            set { SetField(_model.Time, value); }
        }

        public Reminder(Model.Reminder model)
        {
            _model = model;
        }
    }
}
