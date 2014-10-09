using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Calendar_System.AccountSubSystem;

namespace Calendar_System.EntrySubSystem
{
    [Serializable()]
    public class Entry : IEntry, ISerializable
    {
        public String EntryName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Location { get; set; }
        public List<User> UserList { get; set; }
        public Entry(DateTime startDateTime, DateTime endDateTime, String location, List<User> userList, String entryName)
        {
            EntryName = entryName;
            StartDate = startDateTime.Date;
            EndDate = endDateTime.Date;
            Location = location;
            UserList = userList;
        }

        public Entry(SerializationInfo info, StreamingContext ctxt)
        {
            EntryName = (string)info.GetValue("EntryName", typeof(string));
            StartDate = (DateTime)info.GetValue("StartTime", typeof(DateTime));
            EndDate = (DateTime) info.GetValue("EndTime", typeof (DateTime));
            Location = (string)info.GetValue("Location", typeof(string));
            UserList = (List<User>)info.GetValue("UserList", typeof(List<User>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EntryName", EntryName);
            info.AddValue("StartTime", StartDate);
            info.AddValue("EndTime", EndDate);
            info.AddValue("Location", Location);
            info.AddValue("UserList", UserList);
        }
    }
}
