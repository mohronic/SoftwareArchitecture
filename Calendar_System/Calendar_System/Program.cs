using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calendar_System.control;
using Calendar_System.view;

namespace Calendar_System
{
    class Program
    {
        static void Main(string[] args)
        {
            CalendarControl cControl = new CalendarControl();
            CalendarClient cClient = new CalendarClient(cControl);
            cClient.ShowDialog();
            AdminClient a = new AdminClient();
            a.ShowDialog();
        }
    }
}
