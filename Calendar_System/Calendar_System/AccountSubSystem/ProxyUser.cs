using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.EntrySubSystem;
using Calendar_System.MainSystem;

namespace Calendar_System.AccountSubSystem
{
    public class ProxyUser : IUser
    {
        private IUser _realUser;

        public ProxyUser(string firstName, string lastName, string email, string phone, string password, bool admin, int? id, List<Entry> entryList)
        {
            _realUser = new User(firstName, lastName, email, phone, password, admin, id, entryList);
        }
        public ProxyUser()
        {
            _realUser = new User();
        }
        public ProxyUser(SerializationInfo info, StreamingContext ctxt)
        {
            _realUser = new User(info, ctxt);
        }
        public string GetFirstName()
        {
            return _realUser.GetFirstName();
        }

        public string GetLastName()
        {
            return _realUser.GetLastName();
        }

        public string GetEmail()
        {
            return _realUser.GetEmail();
        }

        public string GetPhone()
        {
            return _realUser.GetPhone();
        }
        public bool GetAdmin()
        {
            return _realUser.GetAdmin();
        }
        public string GetPassword()
        {
            //TODO
            // Check if user is admin. Currently dies because of initial password check.

            //if (CalendarControl.User.GetAdmin())
            //{
            //    return _realUser.GetPassword();
            //}
            //throw new AccessDeniedException("Current user is not admin");
            return _realUser.GetPassword();
        }
        public List<Entry> GetEntryList()
        {
            return _realUser.GetEntryList();
        }

        public int? GetId()
        {
            return _realUser.GetId();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            _realUser.GetObjectData(info, context);
        }

        public int CompareTo(object obj)
        {
            return _realUser.CompareTo(obj);
        }

        public bool UpdateUser(string firstName, string lastName, string email, string phone, string password, bool admin,
            List<Entry> entryList)
        {
            if (CalendarControl.User.GetAdmin())
            {
                return _realUser.UpdateUser(firstName, lastName, email, phone, password, admin, entryList);
            }
            throw new AccessDeniedException("Current user is not admin");
        }
    }
}
