using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.control;
using Calendar_System.view;

namespace Calendar_System
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientControl cControl = new ClientControl();
            CalendarClient cClient = new CalendarClient(cControl);
        }
    }
}
