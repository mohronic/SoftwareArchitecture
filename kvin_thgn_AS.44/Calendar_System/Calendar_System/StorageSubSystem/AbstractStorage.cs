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

        public void CreateUser(ProxyUser user)
        {
            _storage.CreateUser(user);
        }

        public ProxyUser GetUserFromDb(int userId)
        {
            return _storage.GetUser(userId);
        }

        public ProxyUser CheckPassword(string userName, string password)
        {
            return _storage.CheckPassword(userName, password);
        }

        public void SendEntryToDb(ProxyUser user, Entry entry)
        {
            _storage.CreateEntry((int)user.GetId(), entry);
        }

        public void SendWorkgroupToDb(Workgroup workgroup)
        {
            _storage.CreateWorkgroup(workgroup);
        }

        public void DeleteEntryFromDb(ProxyUser user, Entry entry)
        {
            _storage.DeleteEntry((int)user.GetId(), (int)entry.GetId());
        }

        public void DeleteUserFromDb(ProxyUser user)
        {
            _storage.DeleteUser((int)user.GetId());
        }

        public void DeleteWorkgroupFromDb(Workgroup workgroup)
        {
            _storage.DeleteWorkgroup((int)workgroup.GetId());
        }
        public void SendUserEntriesToDb(List<Entry> entries, ProxyUser user)
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

        public IList<ProxyUser> GetAllUsersFromDb()
        {
            return _storage.GetAllUsers();
        }

        public IList<Workgroup> GetAllWorkgroupsFromDb()
        {
            return _storage.GetAllWorkgroups();
        }

        public void SyncAccount()
        {
            _storage.SyncAccount();
        }
        public void SendUserToDb(ProxyUser user)
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

        public IStorage GetStorage()
        {
            return _storage;
        }

        public Workgroup GetWorkgroup(int workgroupId)
        {
            return _storage.GetWorkgroup(workgroupId);
        }
    }
}
