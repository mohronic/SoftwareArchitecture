using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.model
{
    class StorageImp : AbstractStorage
    {
        public StorageImp()
        {
            
        }

        public override List<Entry> GetEntries(User user)
        {
            throw new NotImplementedException();
        }

        public override void UpdateEntry(Entry entry)
        {
            throw new NotImplementedException();
        }

        public override void CreateEntry(Entry entry)
        {
            throw new NotImplementedException();
        }

        public override void DeleteEntry(Entry entry)
        {
            throw new NotImplementedException();
        }

        public override void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public override List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public override void CreateWorkgroup(Workgroup wg)
        {
            throw new NotImplementedException();
        }

        public override List<Workgroup> GetWorkgroups()
        {
            throw new NotImplementedException();
        }

        public override void DeleteWorkgroup(Workgroup wg)
        {
            throw new NotImplementedException();
        }
    }
}
