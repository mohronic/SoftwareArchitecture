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
        int GetCreatorId();
        int? GetId();
        bool UpdateEntry(DateTime startDateTime, DateTime endDateTime, String location, IList<ProxyUser> userList, String entryName);
    }
}
