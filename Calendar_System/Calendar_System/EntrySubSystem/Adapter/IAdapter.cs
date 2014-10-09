using System.Collections.Generic;

namespace Calendar_System.EntrySubSystem.Adapter
{
    interface IAdapter
    {
        void CreateEntry(Entry entry);
        Entry GetEntry();
        void ModifyEntry(Entry entry);
        List<Entry> GetEntries();
        void SendEntries(List<Entry> entries);
        void Authorize(string user, string password);
    }
}
