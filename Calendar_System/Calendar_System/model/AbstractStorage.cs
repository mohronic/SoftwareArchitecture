using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.control;
using Calendar_System.Utility;

namespace Calendar_System.model
{
    abstract class AbstractStorage : Observable
    {
        public abstract List<Entry> GetEntriesForUser(User user);
        public abstract void UpdateEntry(Entry entry);
        public abstract void CreateEntry(Entry entry);
        public abstract void DeleteEntry(Entry entry);
        public abstract void CreateUser(User user);
        public abstract void DeleteUser(User user);
        public abstract List<User> GetUsers();
        public abstract void UpdateUser(User user);
        public abstract void CreateWorkgroup(Workgroup wg);
        public abstract List<Workgroup> GetWorkgroups();
        public abstract void DeleteWorkgroup(Workgroup wg);
        public abstract void SyncAccount();
        public abstract bool CheckPassword(string userName, string password);
    }
}
