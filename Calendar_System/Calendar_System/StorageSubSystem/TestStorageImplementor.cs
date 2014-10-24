using System;
using System.Collections.Generic;
using System.Linq;
using Calendar_System.AccountSubSystem;
using Calendar_System.EntrySubSystem;
using Calendar_System.WorkgroupSubSystem;

namespace Calendar_System.StorageSubSystem
{
    public class TestStorageImplementor : IStorage
    {
        private SortedList<int?, ProxyUser> _userList;
        private int _userIdNumber;
        private SortedList<int?, Workgroup> _workgroupList;
        private int _workgroupId;
        public TestStorageImplementor()
        {
            _userList = new SortedList<int?, ProxyUser>();
            _workgroupList = new SortedList<int?, Workgroup>();
            var user1 = new ProxyUser("Hans", "Hansen", "hans@itu.dk", "42913392", "12345", true, 0, new List<Entry>());
            CreateUserInitializationOnly(user1);

            var entry = new Entry(new DateTime(2014, 11, 10), new DateTime(2014, 12, 10), "Atrium", _userList.Values, "Meeting", 0, user1);
            CreateEntryInitializationOnly(0, entry);

            var workgroup1 = new Workgroup("Lecturers", _userList.Values, null);
            CreateWorkgroup(workgroup1);
        }

        private void CreateUserInitializationOnly(ProxyUser user)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            _userList.Add(_userIdNumber, user);
            _userIdNumber++;
        }
        private void CreateEntryInitializationOnly(int userId, Entry entry)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            GetUser(userId).GetEntryList().Add(entry);
        }

        public bool IsConnected()
        {
            return true;
        }
        public List<Entry> GetEntriesForUser(ProxyUser user)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            return user.GetEntryList();
        }

        public void SetEntriesForUser(List<Entry> entries, ProxyUser user)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (!user.UpdateUser(user.GetFirstName(), user.GetLastName(), user.GetEmail(), user.GetPhone(),
                user.GetPassword(), user.GetAdmin(), entries))
            {
                throw new Exception();
            }
        }

        public void UpdateEntry(int userId, Entry entry)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (GetUser(userId).GetEntryList().All(user => user.GetId() != userId) || entry.GetId() == null) { throw new NotInDatabaseException("Entry ID: " + entry.GetId()); }
            GetUser(userId).GetEntryList().Add(entry);
        }

        public void CreateEntry(int userId, Entry entry)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (entry.GetId() != null) { throw new AlreadyInDatabaseException(); }
            GetUser(userId).GetEntryList().Add(entry);
        }

        public void DeleteEntry(int userId, int id)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            try
            {
                GetUser(userId).GetEntryList().RemoveAt(id);
            }
            catch (Exception)
            {
                throw new NotInDatabaseException("Entry ID: " + id);
            }
        }

        public void CreateUser(ProxyUser user)
        {
            _userIdNumber++;
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (user.GetId() != null) { throw new AlreadyInDatabaseException("User ID: " + user.GetId()); }
            _userList.Add(_userIdNumber, user);
        }

        public void DeleteUser(int id)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (GetUser(id) == null) { throw new NotInDatabaseException("User ID: " + id); }
            _userList.RemoveAt(id);
        }

        public IList<ProxyUser> GetAllUsers()
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            return _userList.Values;
        }

        public void UpdateUser(ProxyUser user)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (!_userList.ContainsKey(user.GetId())) { throw new NotInDatabaseException("User ID: " + user.GetId()); }
            _userList.Remove(user.GetId());
            _userList.Add(user.GetId(), user);
        }
        public ProxyUser GetUser(int id)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (!_userList.ContainsKey(id)) { throw new NotInDatabaseException(); }
            ProxyUser user;
            if (!_userList.TryGetValue(id, out user)) { throw new NotInDatabaseException(); }
            return user;

        }
        public void CreateWorkgroup(Workgroup wg)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (wg.GetId() != null) { throw new AlreadyInDatabaseException(); }
            _workgroupList.Add(_workgroupId, wg);
            _workgroupId++;
        }

        public IList<Workgroup> GetAllWorkgroups()
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            return _workgroupList.Values;
        }

        public void DeleteWorkgroup(int workgroupId)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (GetWorkgroup(workgroupId) == null) { throw new NotInDatabaseException(); }
            _workgroupList.RemoveAt(workgroupId);
        }
        public Workgroup GetWorkgroup(int workgroupId)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            if (!_workgroupList.ContainsKey(workgroupId)) { throw new NotInDatabaseException(); }
            Workgroup workgroup;
            if (!_workgroupList.TryGetValue(workgroupId, out workgroup)) { throw new NotInDatabaseException(); }
            return workgroup;
        }
        public void SyncAccount()
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            throw new NotImplementedException();
        }
        public ProxyUser CheckPassword(string userName, string password)
        {
            if (!IsConnected()) { throw new NoConnectionException(); }
            foreach (var user in _userList)
            {
                if (userName.Equals(user.Value.GetFirstName() + " " + user.Value.GetLastName()) && password.Equals(user.Value.GetPassword()))
                {
                    return user.Value;
                }
            }
            return null;
        }
    }
}