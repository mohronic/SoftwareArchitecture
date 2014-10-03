using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.model
{
    class DatabaseStorage : IStorage
    {
        public bool IsConnected()
        {
            // Mock connect
            var random = new Random();
            var next = random.Next(2);
            return next.Equals(0);
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

        public bool CheckPassword(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
