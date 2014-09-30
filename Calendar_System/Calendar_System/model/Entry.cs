using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.model
{
    class Entry
    {
        private DateTime StartTime { get; set; }
        private DateTime EndTime { get; set; }
        private String Location { get; set; }

        public Entry(DateTime startTime, DateTime endTime, String location)
        {
            StartTime = startTime;
            EndTime = endTime;
            Location = location;
        }
    }
}
