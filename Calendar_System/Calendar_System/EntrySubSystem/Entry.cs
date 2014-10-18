using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Calendar_System.AccountSubSystem;

namespace Calendar_System.EntrySubSystem
{
    [Serializable()]
    public class Entry : IEntry, ISerializable
    {
        private string _entryName;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _location;
        private List<User> _userList;
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
        public Entry()
        {

        }
        public Entry(DateTime startDateTime, DateTime endDateTime, String location, List<User> userList, String entryName)
        {
            _entryName = entryName;
            _startDate = startDateTime.Date;
            _endDate = endDateTime.Date;
            _location = location;
            _userList = userList;
        }

        public Entry(SerializationInfo info, StreamingContext ctxt)
        {
            _entryName = (string)info.GetValue("EntryName", typeof(string));
            _startDate = (DateTime)info.GetValue("StartTime", typeof(DateTime));
            _endDate = (DateTime) info.GetValue("EndTime", typeof (DateTime));
            _location = (string)info.GetValue("Location", typeof(string));
            _userList = (List<User>)info.GetValue("UserList", typeof(List<User>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EntryName", _entryName);
            info.AddValue("StartTime", _startDate);
            info.AddValue("EndTime", _endDate);
            info.AddValue("Location", _location);
            info.AddValue("UserList", _userList);
        }
        public bool UpdateEntry(DateTime startDateTime, DateTime endDateTime, String location, List<User> userList, string entryName)
        {
            if(string.IsNullOrWhiteSpace(entryName))
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
