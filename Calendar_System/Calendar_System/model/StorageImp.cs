using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar_System.model
{
    public class StorageImp : AbstractStorage
    {
        public List<Entry> _entryList;
        private List<User> _userList;
        private List<Workgroup> _workgroupList;
        private Dictionary<string, string> _passwordDictionary;
        public StorageImp()
        {
            _entryList = new List<Entry>();
            _userList = new List<User>();
            _workgroupList = new List<Workgroup>();
            User user1 = new User("Hans", "Hansen", "hans@itu.dk", "42913392");
            _userList.Add(user1);

            Entry entry1 = new Entry(new DateTime(2014, 10, 10), new DateTime(2014, 10, 10), "Atrium", _userList, "Meeting");
            _entryList.Add(entry1);

            Workgroup workgroup1 = new Workgroup("Lecturers", _userList);
            _workgroupList.Add(workgroup1);
            _passwordDictionary = new Dictionary<string, string>();
            _passwordDictionary.Add(user1.FirstName, "12345");
        }

        public override List<Entry> GetEntriesForUser(User user)
        {
            List<Entry> entries = new List<Entry>();
            foreach (var entry in _entryList)
            {
                if (entry.UserList.Contains(user))
                {
                    entries.Add(entry);
                }
            }
            return entries;
        }

        public override void UpdateEntry(Entry entry)
        {
            throw new NotImplementedException();
        }

        public override void CreateEntry(Entry entry)
        {
            _entryList.Add(entry);
        }

        public override void DeleteEntry(Entry entry)
        {
            throw new NotImplementedException();
        }

        public override void CreateUser(User user)
        {
            _userList.Add(user);
        }

        public override void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public override List<User> GetUsers()
        {
            return _userList;
        }

        public override void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public override void CreateWorkgroup(Workgroup wg)
        {
            throw new NotImplementedException();
        }

        public override List<Workgroup> GetWorkgroups()
        {
            throw new NotImplementedException();
        }

        public override void DeleteWorkgroup(Workgroup wg)
        {
            throw new NotImplementedException();
        }
        public override void SyncAccount()
        {
            throw new NotImplementedException();
        }
        public override bool CheckPassword(string userName, string password)
        {
            string value;
            if (_passwordDictionary.TryGetValue(userName, out value))
            {
                if (value.Equals(password))
                {
                    return true;
                }   
            }
            return false;
        }
    }
}
