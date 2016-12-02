using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model = decal.Calendar;

namespace decal.Calendar.ViewModel
{
    public class Client : ViewModel
    {

        private Model.Client _model;

        public string Name
        {
            get { return string.Format("{0} {1}", _model.FirstName, _model.LastName); }
        }

        public string PhoneNumber
        {
            get { return _model.PhoneNumber; }
            set { SetField(_model.PhoneNumber, value); }
        }

        public Client(Model.Client model)
        {
            _model = model;
        }

        
    }
}
