﻿using System.Collections.Generic;
using Calendar_System.EntrySubSystem;
using Calendar_System.Utility;

namespace Calendar_System.MainSystem
{
    abstract class ÁbstractCalendar : Observer
    {
        private List<Entry> _entryList;
    }
}
