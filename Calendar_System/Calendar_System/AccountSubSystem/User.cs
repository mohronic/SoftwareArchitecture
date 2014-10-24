using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Calendar_System.EntrySubSystem;

namespace Calendar_System.AccountSubSystem
{
    [Serializable()]
    public class User : ISerializable, IComparable, IUser
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private string _password;
        private bool _admin;
        private List<Entry> _entryList; 
        // If _id has been set, it should always be 0 or larger. If not set, it should be null.
        // @Invariant: 0 <= _id || _id == null;
        private int? _id;
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
        public List<Entry> GetEntryList()
        {
            return _entryList;
        }
        public int? GetId()
        {
            return _id;
        }
        public User(string firstName, string lastName, string email, string phone, string password, bool admin, int? id, List<Entry> entryList)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phone = phone;
            _password = password;
            _admin = admin;
            _id = id;
            _entryList = entryList;
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
            _id = (int)info.GetValue("Id", typeof(int));
            _entryList = (List<Entry>) info.GetValue("EntryList", typeof (List<Entry>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", _firstName);
            info.AddValue("LastName", _lastName);
            info.AddValue("Email", _email);
            info.AddValue("Phone", _phone);
            info.AddValue("Password", _password);
            info.AddValue("Admin", _admin);
            info.AddValue("Id", _id);
            info.AddValue("EntryList", _entryList);
        }

        public int CompareTo(object obj)
        {
            if (obj != null) return 1;
            ProxyUser otherUser = obj as ProxyUser;
            if (otherUser.GetId() == _id)
            {
                return 0;
            }
            return 1;
        }
        public bool UpdateUser(string firstName, string lastName, string email, string phone, string password, bool admin, List<Entry> entryList)
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
            _entryList = entryList;
            return true;
        }
    }
}