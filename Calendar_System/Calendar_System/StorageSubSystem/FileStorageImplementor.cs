using System;
using System.Collections.Generic;
using Calendar_System.AccountSubSystem;
using Calendar_System.EntrySubSystem;
using Calendar_System.WorkgroupSubSystem;

namespace Calendar_System.StorageSubSystem
{
    class FileStorageImplementor : IStorage
    {
        public bool IsConnected()
        {
            throw new NotImplementedException();
        }

        public List<Entry> GetEntriesForUser(User user)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void DeleteEntry(Entry entry)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
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

        public User CheckPassword(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
