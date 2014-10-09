using System.Collections.Generic;

namespace Calendar_System.model.Storage
{
    class AbstractStorage : IAbstractStorage
    {
        private IStorage _storage;

        public bool IsConnected()
        {
            return _storage.IsConnected();
        }

        public void CreateUser(User user)
        {
            _storage.CreateUser(user);
        }

        public bool CheckPassword(User user, string password)
        {
            return _storage.CheckPassword(user, password);
        }

        public void CreateEntry(Entry entry)
        {
            _storage.CreateEntry(entry);
        }

        public void CreateWorkgroup(Workgroup workgroup)
        {
            _storage.CreateWorkgroup(workgroup);
        }

        public void DeleteEntry(Entry entry)
        {
            _storage.DeleteEntry(entry);
        }

        public void DeleteUser(User user)
        {
            _storage.DeleteUser(user);
        }

        public void DeleteWorkgroup(Workgroup workgroup)
        {
            _storage.DeleteWorkgroup(workgroup);
        }

        public List<Entry> GetEntriesForUser(User user)
        {
            return _storage.GetEntriesForUser(user);
        }

        public void SetEntriesForUser(List<Entry> entries, User user)
        {
            if (IsConnected())
            {
                _storage.SetEntriesForUser(entries, user);   
            }
            else
            {
                SerializeEntries objectToSerialize = new SerializeEntries {Entries = entries};

                Serializer serializer = new Serializer();
                serializer.SerializeObject("tempEntries.txt", objectToSerialize);
            }
        }

        public List<User> GetUsers()
        {
            return _storage.GetUsers();
        }

        public List<Workgroup> GetWorkgroups()
        {
            return _storage.GetWorkgroups();
        }

        public void SyncAccount()
        {
            _storage.SyncAccount();
        }

        public void UpdateEntry(Entry entry)
        {
            _storage.UpdateEntry(entry);
        }

        public void UpdateUser(User user)
        {
            _storage.UpdateUser(user);
        }

        public void SetStorage(IStorage storage)
        {
            _storage = storage;
        }
    }
}
