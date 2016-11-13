using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decal.Calendar
{
    class User
    {
        private int _id;
        private string _forename;
        private string _surname;

        public String FirstName
        {
            get { return _forename; }
        }

        public String LastName
        {
            get { return _surname; }
        }
    }
}
