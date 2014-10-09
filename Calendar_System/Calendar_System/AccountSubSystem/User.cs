using System;
using System.Runtime.Serialization;

namespace Calendar_System.AccountSubSystem
{
    [Serializable()]
    public class User : ISerializable, IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        // TODO Add enum for workgroup maybe list?
        public bool Admin { get; set; }
        public User(string firstName, string lastName, string email, string phone, bool admin)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Admin = admin;
        }

        public User(SerializationInfo info, StreamingContext ctxt)
        {
            FirstName = (string)info.GetValue("FirstName", typeof(string));
            LastName = (string)info.GetValue("LastName", typeof(string));
            Email = (string)info.GetValue("Email", typeof(string));
            Phone = (string)info.GetValue("Phone", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", FirstName);
            info.AddValue("LastName", FirstName);
            info.AddValue("Email", FirstName);
            info.AddValue("Phone", Phone);
        }

        public int CompareTo(object obj)
        {
            if (obj != null) return 1;
            User otherUser = obj as User;
            if (otherUser.FirstName == FirstName && otherUser.LastName == LastName && otherUser.Phone == Phone && otherUser.Email == Email)
            {
                return 0;
            }
            return 1;
        }
    }
}
