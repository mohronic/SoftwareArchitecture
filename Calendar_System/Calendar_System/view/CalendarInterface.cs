using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.model;
using Calendar_System.Utility;

namespace Calendar_System.view
{
    abstract class ÁbstractCalendar : Observer
    {
        private List<Entry> _entryList;
    }
}
