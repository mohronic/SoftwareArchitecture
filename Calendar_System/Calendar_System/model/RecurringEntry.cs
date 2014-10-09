using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.model
{
    class RecurringEntry : IEntry
    {
        public string EntryName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public List<User> UserList { get; set; }
        public List<Entry> EntryList { get; set; }
        public void AddEntry(Entry entry)
        {
            EntryList.Add(entry);
        }
        public void RemoveEntry(Entry entry)
        {
            EntryList.Remove(entry);
        }
        public Entry GetEntryAt(int index)
        {
            return EntryList.ElementAt(index);
        }
    }
}
