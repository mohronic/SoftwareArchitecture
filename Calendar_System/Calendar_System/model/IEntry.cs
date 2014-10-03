using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.model
{
    interface IEntry
    {
        String EntryName { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        String Location { get; set; }
        List<User> UserList { get; set; }
    }
}
