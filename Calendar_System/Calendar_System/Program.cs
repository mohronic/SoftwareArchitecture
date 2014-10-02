using Calendar_System.control;
using Calendar_System.view;

namespace Calendar_System
{
    class Program
    {
        // If you want to run as user in current implementation
        static void Main2()
        {
            CalendarControl cControl = new CalendarControl();
        }
        // If you want to run as admin in current implementation
        static void Main()
        {
            AdminControl ac = new AdminControl();
        }
    }
}
