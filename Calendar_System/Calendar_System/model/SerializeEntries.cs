using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.model
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
