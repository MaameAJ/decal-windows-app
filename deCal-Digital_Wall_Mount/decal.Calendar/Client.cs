using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace decal.Calendar
{
    public class Client
    {
        private string _forename;
        private string _surname;
        private string _phoneNumber;

        public string FirstName
        {
            get { return _forename; }
        }

        public string LastName
        {
            get { return _surname; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        private static bool isInvalid(string str)
        {
            return (String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str));
        }

        public Client(string firstName, string lastName, string phoneNumber)
        {
            if(isInvalid(firstName))
            {
                throw new ArgumentNullException("firstName cannot be null or empty.");
            }
            else if(isInvalid(lastName))
            {
                throw new ArgumentNullException("lastName cannot be null or empty.");
            }
            else if(isInvalid(phoneNumber))
            {
                throw new ArgumentNullException("phoneNumber cannot be null or empty.");
            }
            else
            {
                _forename = firstName;
                _surname = lastName;
                _phoneNumber = phoneNumber;
            }
        }
    }
}
