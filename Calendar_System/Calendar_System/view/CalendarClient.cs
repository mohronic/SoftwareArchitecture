using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.view
{
    class CalendarClient
    {
        private control.ClientControl _cControl;
        private ÁbstractCalendar _calendarView;

        public CalendarClient(control.ClientControl cControl)
        {
            // TODO: Complete member initialization
            _cControl = cControl;
            _calendarView = new CalendarWeekly();
            Setup();
        }

        private void Setup()
        {
            //TODO create menu
            //TODO add calendarView
        }
    }
}
