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
        // @Pre: entry.GetId() != null;
        // @Pre: IsConnected() == true;
        // @Post: GetEntriesForUser(entry.GetCreator()) == self@Pre GetEntriesForUser(entry.GetCreator());
        // @Post: GetEntriesForUser(entry.GetCreator()).GroupBy(x => x.getId()).Where(g => g.Count()>1).Select(y => y.Key).ToList().Count() == 0;
        void UpdateEntry(Entry entry);
        // @Pre: entry.GetId() == null;
        // @Pre: IsConnected() == true;
        // @Post: GetEntriesForUser(entry.GetCreator()) == self@Pre GetEntriesForUser(entry.GetCreator()) + 1;
        // @Post: GetEntriesForUser(entry.GetCreator()).GroupBy(x => x.getId()).Where(g => g.Count()>1).Select(y => y.Key).ToList().Count() == 0;
        void CreateEntry(Entry entry);
        void DeleteEntry(int id);
        // @Pre: user.GetId() == null;
        // @Pre: IsConnected() == true;
        // @Post: GetUsers() == self@Pre GetUsers() + 1;
        // @Post: GetUsers().GroupBy(x => x.getid()).Where(g => g.Count()>1).Select(y => y.Key).ToList().Count() == 0;
        void CreateUser(User user);
        // @Pre: GetUser(id) != null;
        // @Pre: IsConnected() == true;
        // @Post: GetUsers() == self@Pre GetUsers() - 1;
        // @Post: GetUser(id) == null;
        void DeleteUser(int id);
        User GetUser(int id);
        IList<User> GetAllUsers();
        // @Pre: user.GetId() != null;
        // @Pre: IsConnected() == true;
        // @Post: GetUsers() == self@Pre GetUsers();
        // @Post: GetUsers().GroupBy(x => x.getid()).Where(g => g.Count()>1).Select(y => y.Key).ToList().Count() == 0;
        void UpdateUser(User user);
        void CreateWorkgroup(Workgroup wg);
        IList<Workgroup> GetWorkgroups();
        void DeleteWorkgroup(Workgroup wg);
        void SyncAccount();
        User CheckPassword(string userName, string password);
    }
}
