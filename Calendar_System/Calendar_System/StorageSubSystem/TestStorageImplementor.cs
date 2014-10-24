using System;
using System.Collections.Generic;
using Calendar_System.AccountSubSystem;
using Calendar_System.EntrySubSystem;
using Calendar_System.WorkgroupSubSystem;

namespace Calendar_System.StorageSubSystem
{
    public class TestStorageImplementor : IStorage
    {
        private SortedList<int?, Entry> _entryList;
        private int _entryIdNumber;
        private SortedList<int?, User> _userList;
        private int _userIdNumber;
        private SortedList<int?, Workgroup> _workgroupList;
        private int _workgroupId;
        public TestStorageImplementor()
        {
            _entryList = new SortedList<int?, Entry>();
            _userList = new SortedList<int?, User>();
            _workgroupList = new SortedList<int?, Workgroup>();
            var user1 = new User("Hans", "Hansen", "hans@itu.dk", "42913392", "12345", true, null);
            CreateUser(user1);

            Entry entry1 = new Entry(new DateTime(2014, 11, 10), new DateTime(2014, 12, 10), "Atrium", _userList.Values, "Meeting", null, user1);
            CreateEntry(entry1);

            Workgroup workgroup1 = new Workgroup("Lecturers", _userList.Values, null);
            CreateWorkgroup(workgroup1);
        }

        public bool IsConnected()
        {
            return true;
        }
        public List<Entry> GetEntriesForUser(User user)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            List<Entry> entries = new List<Entry>();
            foreach (var entry in _entryList)
            {
                if (entry.Value.GetUserList().Contains(user))
                {
                    entries.Add(entry.Value);
                }
            }
            return entries;
        }

        public void SetEntriesForUser(List<Entry> entries, User user)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            throw new NotImplementedException();
        }

        public void UpdateEntry(Entry entry)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (!_entryList.ContainsKey(entry.GetId()) || entry.GetId() == null) { throw new EntryNotFoundException(); }
            _entryList.Add(entry.GetId(), entry);
        }

        public void CreateEntry(Entry entry)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (entry.GetId() != null) { throw new EntryNotFoundException(); }
            _entryList.Add(_entryIdNumber, entry);
            _entryIdNumber++;
        }

        public void DeleteEntry(int id)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (_entryList.ContainsKey(id)) { throw new EntryNotFoundException(); }
            _entryList.RemoveAt(id);
        }

        public void CreateUser(User user)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (user.GetId() != null) { throw new NoUserFoundException(); }
            _userList.Add(_userIdNumber, user);
            _userIdNumber++;
            foreach(var iou in _userList)
            {
                Console.WriteLine(iou.Value.GetFirstName());      
            }
        }

        public void DeleteUser(int id)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (GetUser(id) == null) { throw new NoUserFoundException(); }
            _userList.RemoveAt(id);
        }

        public IList<User> GetAllUsers()
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            return _userList.Values;
        }

        public void UpdateUser(User user)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (!_userList.ContainsKey(user.GetId())) { throw new NoUserFoundException(); }
            _userList.Remove(user.GetId());
            _userList.Add(user.GetId(), user);
        }
        public User GetUser(int id)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (!_userList.ContainsKey(id)) { throw new NoUserFoundException(); }
            User user; 
            if(_userList.TryGetValue(id, out user)) {throw new NoUserFoundException();}
            return user;
            
        }
        public void CreateWorkgroup(Workgroup wg)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (wg.GetId() != null) { throw new Exception(); }
            _workgroupList.Add(_workgroupId, wg);
            _workgroupId++;
        }

        public IList<Workgroup> GetWorkgroups()
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            throw new NotImplementedException();
        }

        public void DeleteWorkgroup(Workgroup wg)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            throw new NotImplementedException();
        }
        public void SyncAccount()
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            throw new NotImplementedException();
        }
        public User CheckPassword(string userName, string password)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            foreach (var user in _userList)
            {
                if(userName.Equals(user.Value.GetFirstName() + " " + user.Value.GetLastName()) && password.Equals(user.Value.GetPassword()))
                {
                    return user.Value;
                }
            }
            return null;
        }
    }
}
