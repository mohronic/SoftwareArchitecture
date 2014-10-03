using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.model
{
    interface IAbstractStorage
    {
        bool IsConnected();
        void CreateUser(User user);
        bool CheckPassword(string userName, string passWord);
        void CreateEntry(Entry entry);
        void CreateWorkgroup(Workgroup workgroup);
        void DeleteEntry(Entry entry);
        void DeleteUser(User user);
        void DeleteWorkgroup(Workgroup workgroup);
        List<Entry> GetEntriesForUser(User user);
        void SetEntriesForUser(List<Entry> entries, User user);
        List<User> GetUsers();
        List<Workgroup> GetWorkgroups();
        void SyncAccount();
        void UpdateEntry(Entry entry);
        void UpdateUser(User user);
    }
}
