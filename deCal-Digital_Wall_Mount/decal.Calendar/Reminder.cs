using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decal.Calendar
{
    class Reminder
    {
        Appointment _owner;
        DateTime _datetime;

        public Appointment Owner
        {
            get { return _owner; }
        }

        public DateTime Time
        {
            get { return _datetime; }
            set { _datetime = value;  }
        }
    }
}
