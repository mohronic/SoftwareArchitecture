using System;
using System.Runtime.Serialization;

namespace Calendar_System.AccountSubSystem
{
    [Serializable()]
    public class User : ISerializable, IComparable
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private string _password;
        private bool _admin;
        // TODO Add enum for workgroup maybe list?     
        public string GetFirstName()
        {
            return _firstName;
        }
        public string GetLastName()
        {
            return _lastName;
        }
        public string GetEmail()
        {
            return _email;
        }
        public string GetPhone()
        {
            return _phone;
        }
        public bool GetAdmin()
        {
            return _admin;
        }
        public string GetPassword()
        {
            return _password;
        }
        public User(string firstName, string lastName, string email, string phone, string password, bool admin)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phone = phone;
            _password = password;
            _admin = admin;
        }
        public User()
        {

        }
        public User(SerializationInfo info, StreamingContext ctxt)
        {
            _firstName = (string)info.GetValue("FirstName", typeof(string));
            _lastName = (string)info.GetValue("LastName", typeof(string));
            _email = (string)info.GetValue("Email", typeof(string));
            _phone = (string)info.GetValue("Phone", typeof(string));
            _password = (string)info.GetValue("Password", typeof(string));
            _admin = (bool)info.GetValue("Admin", typeof(bool));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", _firstName);
            info.AddValue("LastName", _lastName);
            info.AddValue("Email", _email);
            info.AddValue("Phone", _phone);
            info.AddValue("Password", _password);
            info.AddValue("Admin", _admin);
        }

        public int CompareTo(object obj)
        {
            if (obj != null) return 1;
            User otherUser = obj as User;
            if (otherUser._firstName == _firstName && otherUser._lastName == _lastName && otherUser._phone == _phone && 
                otherUser._email == _email && otherUser._password == _password && otherUser._admin == _admin)
            {
                return 0;
            }
            return 1;
        }
        public bool UpdateUser(string firstName, string lastName, string email, string phone, string password, bool admin)
        {
            if(string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            // If some checks fail return false; else:
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phone = phone;
            _admin = admin;
            _password = password;
            return true;
        }
    }
}