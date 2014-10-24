using System;
using System.Collections.Generic;
using System.Linq;
using Calendar_System.AccountSubSystem;

namespace Calendar_System.EntrySubSystem
{
    public class RecurringEntry : IEntry
    {
        private string _entryName;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _location;
        private int? _id;
        private int _creatorId;
        private IList<ProxyUser> _userList;
        private IList<Entry> _entryList;

        public RecurringEntry()
        {

        }
        public RecurringEntry(string entryName, DateTime startDate, DateTime endDate, string location, int id, int creatorId, IList<ProxyUser>userList, IList<Entry> entryList)
        {
            _entryName = entryName;
            _startDate = startDate;
            _endDate = endDate;
            _location = location;
            _id = id;
            _creatorId = creatorId;
            _userList = userList;
            _entryList = entryList;
        }
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
        public int? GetId()
        {
            return _id;
        }
        public int GetCreatorId()
        {
            return _creatorId;
        }
        public IList<ProxyUser> GetUserList()
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
        public bool UpdateEntry(DateTime startDateTime, DateTime endDateTime, String location, List<ProxyUser> userList, String entryName)
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
