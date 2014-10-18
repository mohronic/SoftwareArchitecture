using System;
using System.Collections.Generic;
using System.Linq;
using Calendar_System.AccountSubSystem;

namespace Calendar_System.EntrySubSystem
{
    class RecurringEntry : IEntry
    {
        private string _entryName;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _location;
        private List<User> _userList;
        private List<Entry> _entryList;
        public string GetEntryName()
        {
            return _entryName;
        }
        public DateTime GetStartDate()
        {
            return _startDate;
        }
        public DateTime GetEndDate()
        {
            return _endDate;
        }
        public string GetLocation()
        {
            return _location;
        }
        public List<User> GetUserList()
        {
            return _userList;
        }
        public void AddEntry(Entry entry)
        {
            _entryList.Add(entry);
        }
        public void RemoveEntry(Entry entry)
        {
            _entryList.Remove(entry);
        }
        public Entry GetEntryAt(int index)
        {
            return _entryList.ElementAt(index);
        }
        public bool UpdateEntry(DateTime startDateTime, DateTime endDateTime, String location, List<User> userList, String entryName)
        {
            if (string.IsNullOrWhiteSpace(entryName))
            {
                return false;
            }
            // If some check fails return false;
            _entryName = entryName;
            _startDate = startDateTime.Date;
            _endDate = endDateTime.Date;
            _location = location;
            _userList = userList;
            return true;
        }
    }
}
