using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decal.Calendar
{
    public class User
    {
        private int _id;
        private string _forename;
        private string _surname;

        public string FirstName
        {
            get { return _forename; }
        }

        public string LastName
        {
            get { return _surname; }
        }
    }
}
