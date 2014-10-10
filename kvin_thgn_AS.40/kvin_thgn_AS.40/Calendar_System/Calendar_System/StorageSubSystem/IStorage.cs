using System.Collections.Generic;
using Calendar_System.AccountSubSystem;
using Calendar_System.EntrySubSystem;
using Calendar_System.WorkgroupSubSystem;

namespace Calendar_System.StorageSubSystem
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
        bool CheckPassword(User user, string password);
    }
}
