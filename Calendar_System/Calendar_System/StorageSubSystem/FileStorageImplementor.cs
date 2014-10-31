using System;
using System.Collections.Generic;
using Calendar_System.AccountSubSystem;
using Calendar_System.EntrySubSystem;
using Calendar_System.WorkgroupSubSystem;

namespace Calendar_System.StorageSubSystem
{
    public class FileStorageImplementor : IStorage
    {
        public bool IsConnected()
        {
            throw new NotImplementedException();
        }

        public List<Entry> GetEntriesForUser(ProxyUser user)
        {
            throw new NotImplementedException();
        }

        public void SetEntriesForUser(List<Entry> entries, ProxyUser user)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntry(int userId, Entry entry)
        {
            throw new NotImplementedException();
        }

        public void CreateEntry(int userId, Entry entry)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntry(int userId, int entryId)
        {
            throw new NotImplementedException();
        }
        public void CreateUser(ProxyUser user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ProxyUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(ProxyUser user)
        {
            throw new NotImplementedException();
        }
        public ProxyUser GetUser(int id)
        {
            throw new NotImplementedException();
        }
        public void CreateWorkgroup(Workgroup wg)
        {
            throw new NotImplementedException();
        }

        public Workgroup GetWorkgroup(int workgroupId)
        {
            throw new NotImplementedException();
        }

        public IList<Workgroup> GetAllWorkgroups()
        {
            throw new NotImplementedException();
        }

        public void DeleteWorkgroup(int workgroupId)
        {
            throw new NotImplementedException();
        }

        public void SyncAccount()
        {
            throw new NotImplementedException();
        }

        public ProxyUser CheckPassword(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void SetConnection(bool connection)
        {
            throw new NotImplementedException();
        }
    }
}
