using System;
using System.Windows.Forms;

namespace Calendar_System.view
{
    class CalendarClient : Form
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
            Console.Out.WriteLine("Hello");
            //TODO create menu
            //TODO add calendarView
        }
        //Changes the view from weekView to monthView and vice versa.
        private void ChangeView()
        {
            if (_calendarView.GetType() == typeof(CalendarWeekly))
            {
                _calendarView = new CalendarMonthly();
            }
            else
            {
                _calendarView = new CalendarWeekly();
            }
        }
    }
}
