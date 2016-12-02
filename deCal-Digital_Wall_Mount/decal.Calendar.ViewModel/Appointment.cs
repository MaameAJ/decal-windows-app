using System;

using Model = decal.Calendar;

namespace decal.Calendar.ViewModel
{
    public class Appointment : ViewModel
    {
        private Model.Appointment _model;

        private Client _client;

        public string ClientName
        {
            get { return _client.Name; }
        }

        public DateTime Time
        {
            set { SetField(_model.Time, value); }
            get { return _model.Time; }
        }

        public Appointment(Model.Appointment appt)
        {
            _model = appt;
            _client = new Client(appt.With);
        }
    }
}
