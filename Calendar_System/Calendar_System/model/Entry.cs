using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.model
{
    class Entry
    {
        private DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        private String Location { get; set; }
        public List<User> UserList { get; set; }
        public Entry(DateTime startTime, DateTime endTime, String location, List<User> userList)
        {
            StartTime = startTime;
            EndTime = endTime;
            Location = location;
            UserList = userList;
        }
    }
}
