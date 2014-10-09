using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.model.Adapter
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
