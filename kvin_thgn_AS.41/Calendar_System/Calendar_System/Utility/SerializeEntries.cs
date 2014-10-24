using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Calendar_System.EntrySubSystem;

namespace Calendar_System.Utility
{
    [Serializable()]
    public class SerializeEntries : ISerializable
    {
        public List<Entry> Entries { get; set; }

        public SerializeEntries()
        {
            
        }
        public SerializeEntries(SerializationInfo info, StreamingContext ctxt)
        {
            Entries = (List<Entry>)info.GetValue("Entries", typeof(List<Entry>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Entries", Entries);
        }
    }
}
