using System.Collections.Generic;
using Calendar_System.AccountSubSystem;
using Calendar_System.EntrySubSystem;
using Calendar_System.Utility;
using Calendar_System.WorkgroupSubSystem;

namespace Calendar_System.StorageSubSystem
{
    public class AbstractStorage : IAbstractStorage
    {
        private IStorage _storage;

        public AbstractStorage(IStorage storage)
        {
            _storage = storage;
        }
    
        public bool IsConnected()
        {
            return _storage.IsConnected();
        }

        public void CreateUser(User user)
        {
            _storage.CreateUser(user);
        }

        public User CheckPassword(string userName, string password)
        {
            return _storage.CheckPassword(userName, password);
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
            _storage.DeleteEntry((int)entry.GetId());
        }

        public void DeleteUser(User user)
        {
            _storage.DeleteUser((int)user.GetId());
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

        public IList<User> GetUsers()
        {
            return _storage.GetAllUsers();
        }

        public IList<Workgroup> GetWorkgroups()
        {
            return _storage.GetWorkgroups();
        }

        public void SyncAccount()
        {
            _storage.SyncAccount();
        }
        public void UserToDb(User user)
        {
            if(user.GetId() == null)
            {
                _storage.CreateUser(user);
            }
            else
            {
                _storage.UpdateUser(user);
            }
        }
        public void SetStorage(IStorage storage)
        {
            _storage = storage;
        }
    }
}
