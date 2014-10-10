using System;
using System.Collections.Generic;
using Calendar_System.AccountSubSystem;
using Calendar_System.EntrySubSystem;
using Calendar_System.WorkgroupSubSystem;

namespace Calendar_System.StorageSubSystem
{
    public class TestStorageImplementor : IStorage
    {
        private List<Entry> _entryList;
        private List<User> _userList;
        private List<Workgroup> _workgroupList;
        private Dictionary<User, string> _passwordDictionary;
        public TestStorageImplementor()
        {
            _entryList = new List<Entry>();
            _userList = new List<User>();
            _workgroupList = new List<Workgroup>();
            var user1 = new User("Hans", "Hansen", "hans@itu.dk", "42913392", true);
            _userList.Add(user1);

            Entry entry1 = new Entry(new DateTime(2014, 11, 10), new DateTime(2014, 12, 10), "Atrium", _userList, "Meeting");
            _entryList.Add(entry1);

            Workgroup workgroup1 = new Workgroup("Lecturers", _userList);
            _workgroupList.Add(workgroup1);
            _passwordDictionary = new Dictionary<User, string>();
            _passwordDictionary.Add(user1, "12345");
        }

        public bool IsConnected()
        {
            return true;
        }

        public List<Entry> GetEntriesForUser(User user)
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

        public void SetEntriesForUser(List<Entry> entries, User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntry(Entry entry)
        {
            throw new NotImplementedException();
        }

        public void CreateEntry(Entry entry)
        {
            _entryList.Add(entry);
        }

        public void DeleteEntry(Entry entry)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(User user)
        {
            _userList.Add(user);
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            return _userList;
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void CreateWorkgroup(Workgroup wg)
        {
            throw new NotImplementedException();
        }

        public List<Workgroup> GetWorkgroups()
        {
            throw new NotImplementedException();
        }

        public void DeleteWorkgroup(Workgroup wg)
        {
            throw new NotImplementedException();
        }
        public void SyncAccount()
        {
            throw new NotImplementedException();
        }

        public bool CheckPassword(User user, string password)
        {
            string value;
            if (_passwordDictionary.TryGetValue(user, out value))
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
