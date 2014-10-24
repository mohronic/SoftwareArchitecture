using System.Collections.Generic;
using Calendar_System.AccountSubSystem;
using Calendar_System.EntrySubSystem;
using Calendar_System.WorkgroupSubSystem;

namespace Calendar_System.StorageSubSystem
{
    public interface IStorage
    {
        bool IsConnected();
        List<Entry> GetEntriesForUser(ProxyUser user);
        void SetEntriesForUser(List<Entry> entries, ProxyUser user);
        // @Pre: entry.GetId() != null;
        // @Pre: IsConnected() == true;
        // @Post: GetUser(userId).GetEntryList().Count == @Pre GetUser(userId).GetEntryList().Count;
        // @Post: GetEntriesForUser(entry.GetCreator()).GroupBy(x => x.getId()).Where(g => g.Count()>1).Select(y => y.Key).ToList().Count() == 0;
        void UpdateEntry(int userId, Entry entry);
        // @Pre: entry.GetId() == null;
        // @Pre: IsConnected() == true;
        // @Post: GetUser(userId).GetEntryList().Count == @Pre GetUser(userId).GetEntryList().Count + 1;
        // @Post: GetEntriesForUser(entry.GetCreator()).GroupBy(x => x.getId()).Where(g => g.Count()>1).Select(y => y.Key).ToList().Count() == 0;
        void CreateEntry(int userId, Entry entry);
        void DeleteEntry(int userId, int entryId);
        // @Pre: user.GetId() == null;
        // @Pre: IsConnected() == true;
        // @Post: GetUsers() == self@Pre GetUsers() + 1;
        // @Post: GetUsers().GroupBy(x => x.getid()).Where(g => g.Count()>1).Select(y => y.Key).ToList().Count() == 0;
        void CreateUser(ProxyUser user);
        // @Pre: GetUser(id) != null;
        // @Pre: IsConnected() == true;
        // @Post: GetUsers() == self@Pre GetUsers() - 1;
        // @Post: GetUser(id) == null;
        void DeleteUser(int id);
        ProxyUser GetUser(int id);
        IList<ProxyUser> GetAllUsers();
        // @Pre: user.GetId() != null;
        // @Pre: IsConnected() == true;
        // @Post: GetUsers() == self@Pre GetUsers();
        // @Post: GetUsers().GroupBy(x => x.getid()).Where(g => g.Count()>1).Select(y => y.Key).ToList().Count() == 0;
        void UpdateUser(ProxyUser user);
        void CreateWorkgroup(Workgroup wg);
        Workgroup GetWorkgroup(int workgroupId);
        IList<Workgroup> GetAllWorkgroups();
        void DeleteWorkgroup(int workgroupId);
        void SyncAccount();
        ProxyUser CheckPassword(string userName, string password);
    }
}
