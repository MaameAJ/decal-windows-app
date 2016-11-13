using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decal.Calendar
{
    class Appointment
    {
        private User _owner;
        private Client _client;
        private DateTime _datetime;

        public User Owner
        {
            get { return _owner; }
        }

        public Client With
        {
            get { return _client; }
        }

        public DateTime Time
        {
            set { _datetime = value; }
            get { return _datetime; }
        }

        public Appointment(User owner, Client with, DateTime dt)
        {
            _owner = owner;
            _client = with;
            _datetime = dt;
        }
    }
}
