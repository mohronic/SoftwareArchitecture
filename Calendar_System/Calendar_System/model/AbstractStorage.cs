using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.Utility;

namespace Calendar_System.model
{
    abstract class AbstractStorage : Observable
    {
        public abstract List<Entry> GetEntries(User user);
        public abstract void UpdateEntry(Entry entry);
        public abstract void CreateEntry(Entry entry);
        public abstract void CreateUser(User user);
        public abstract List<User> GetUsers();
        public abstract void UpdateUser(User user);
        public abstract void CreateWorkgroup(Workgroup wg);
        public abstract List<Workgroup> GetWorkgroups();
        public abstract void DeleteWorkgroup(Workgroup wg);
    }
}
