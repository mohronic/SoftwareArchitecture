using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Calendar_System.AccountSubSystem;

namespace Calendar_System.EntrySubSystem
{
    [Serializable]
    public class Entry : IEntry, ISerializable
    {
        private string _entryName;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _location;
        private IList<ProxyUser> _userList;
        // If _id has been set, it should always be 0 or larger. If not set, it should be null.
        // @Invariant: 0 <= _id || _id == null;
        private int? _id;
        private int _creatorId;

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

        public IList<ProxyUser> GetUserList()
        {
            return _userList;
        }

        public int? GetId()
        {
            return _id;
        }

        public int GetCreatorId()
        {
            return _creatorId;
        }

        public Entry()
        {

        }

        public Entry(DateTime startDateTime, DateTime endDateTime, String location, IList<ProxyUser> userList,
            String entryName, int? id, int creatorId)
        {
            _entryName = entryName;
            _startDate = startDateTime.Date;
            _endDate = endDateTime.Date;
            _location = location;
            _userList = userList;
            _id = id;
            _creatorId = creatorId;
        }

        public Entry(SerializationInfo info, StreamingContext ctxt)
        {
            _entryName = (string) info.GetValue("EntryName", typeof (string));
            _startDate = (DateTime) info.GetValue("StartTime", typeof (DateTime));
            _endDate = (DateTime) info.GetValue("EndTime", typeof (DateTime));
            _location = (string) info.GetValue("Location", typeof (string));
            _userList = (List<ProxyUser>) info.GetValue("UserList", typeof (List<ProxyUser>));
            _id = (int) info.GetValue("Id", typeof (int));
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("EntryName", _entryName);
            info.AddValue("StartTime", _startDate);
            info.AddValue("EndTime", _endDate);
            info.AddValue("Location", _location);
            info.AddValue("UserList", _userList);
            info.AddValue("Id", _id);
        }

        public bool UpdateEntry(DateTime startDateTime, DateTime endDateTime, String location, List<ProxyUser> userList, string entryName)
        {
            if (string.IsNullOrWhiteSpace(entryName))
            {
                return false;
            }
            if (startDateTime < DateTime.Now || startDateTime > DateTime.MaxValue)
            {
                // Errorframe: Start time to early 
                return false;
            }
            if (endDateTime > DateTime.MaxValue || endDateTime < startDateTime)
            {
                //Errorframe: End time too late
                return false;
            }
            _entryName = entryName;
            _startDate = startDateTime.Date;
            _endDate = endDateTime.Date;
            _location = location;
            _userList = userList;
            return true;
        }
    }
}