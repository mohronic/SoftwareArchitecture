using System.Collections.Generic;
using Calendar_System.AccountSubSystem;
using Calendar_System.EntrySubSystem;
using Calendar_System.WorkgroupSubSystem;

namespace Calendar_System.StorageSubSystem
{
    public interface IAbstractStorage
    {
        bool IsConnected();
        void SendUserToDb(ProxyUser user);
        ProxyUser GetUserFromDb(int userId);
        ProxyUser CheckPassword(string userName, string password);
        void SendEntryToDb(ProxyUser user, Entry entry);
        void SendWorkgroupToDb(Workgroup workgroup);
        void DeleteEntryFromDb(ProxyUser user, Entry entry);
        void DeleteUserFromDb(ProxyUser user);
        void DeleteWorkgroupFromDb(Workgroup workgroup);
        void SendUserEntriesToDb(List<Entry> entries, ProxyUser user);
        IList<ProxyUser> GetAllUsersFromDb();
        IList<Workgroup> GetAllWorkgroupsFromDb();
        void SyncAccount();
        void SetStorage(IStorage storage);
        Workgroup GetWorkgroup(int workgroupId);
    }
}
