using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.model
{
    [Serializable()]
    public class Entry : IEntry, ISerializable
    {
        public String EntryName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public String Location { get; set; }
        public List<User> UserList { get; set; }
        public Entry(DateTime startTime, DateTime endTime, String location, List<User> userList, String entryName)
        {
            EntryName = entryName;
            StartTime = startTime;
            EndTime = endTime;
            Location = location;
            UserList = userList;
        }

        public Entry(SerializationInfo info, StreamingContext ctxt)
        {
            EntryName = (string)info.GetValue("EntryName", typeof(string));
            StartTime = (DateTime)info.GetValue("StartTime", typeof(DateTime));
            EndTime = (DateTime) info.GetValue("EndTime", typeof (DateTime));
            Location = (string)info.GetValue("Location", typeof(string));
            UserList = (List<User>)info.GetValue("UserList", typeof(List<User>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EntryName", EntryName);
            info.AddValue("StartTime", StartTime);
            info.AddValue("EndTime", EndTime);
            info.AddValue("Location", Location);
            info.AddValue("UserList", UserList);
        }
    }
}
