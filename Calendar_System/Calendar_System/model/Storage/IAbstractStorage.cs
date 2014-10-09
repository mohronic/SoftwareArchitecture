using System.Collections.Generic;

namespace Calendar_System.model.Storage
{
    interface IAbstractStorage
    {
        bool IsConnected();
        void CreateUser(User user);
        bool CheckPassword(User user, string password);
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
        void SetStorage(IStorage storage);
    }
}
