using System;
using System.Collections.Generic;
using Calendar_System.AccountSubSystem;

namespace Calendar_System.EntrySubSystem
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
