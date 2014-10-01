using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.model
{
    class Entry
    {
        public String EntryName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public String Location { get; set; }
        public List<User> UserList { get; set; }
        public Entry(DateTime startTime, DateTime endTime, String location, List<User> userList, String entryName)
        {
            EntryName = entryName;
            StartTime = startTime;
            EndTime = endTime;
            Location = location;
            UserList = userList;
        }
    }
}
