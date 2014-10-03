using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.control;
using Calendar_System.Utility;

namespace Calendar_System.model
{
    public interface IStorage
    {
        bool IsConnected();
        List<Entry> GetEntriesForUser(User user);
        void SetEntriesForUser(List<Entry> entries, User user);
        void UpdateEntry(Entry entry);
        void CreateEntry(Entry entry);
        void DeleteEntry(Entry entry);
        void CreateUser(User user);
        void DeleteUser(User user);
        List<User> GetUsers();
        void UpdateUser(User user);
        void CreateWorkgroup(Workgroup wg);
        List<Workgroup> GetWorkgroups();
        void DeleteWorkgroup(Workgroup wg);
        void SyncAccount();
        bool CheckPassword(string userName, string password);
    }
}
