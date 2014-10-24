using System;
using System.Collections.Generic;
using Calendar_System.AccountSubSystem;

namespace Calendar_System.EntrySubSystem
{
    interface IEntry
    {
        string GetEntryName();
        DateTime GetStartDate();
        DateTime GetEndDate();
        string GetLocation();
        IList<ProxyUser> GetUserList();
        ProxyUser GetCreator();
        int? GetId();
        bool UpdateEntry(DateTime startDateTime, DateTime endDateTime, String location, List<ProxyUser> userList, String entryName);
    }
}
