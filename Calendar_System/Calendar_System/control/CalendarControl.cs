using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.model;
using Calendar_System.view;

namespace Calendar_System.control
{
    public class CalendarControl
    {
        IStorage _abstractStorage = new FileStorage();
        public CalendarControl()
        {
            LoginForm loginForm = new LoginForm(this);
            loginForm.ShowDialog();
        }

        public void SuccesfullLogin()
        {
            CalendarClient calendarClient = new CalendarClient(this, _abstractStorage);
            calendarClient.ShowDialog();
        }
        public void CreateEntryControl(String message)
        {
            EntryControl ec = new EntryControl(message, _abstractStorage);
        }

        public void CreateSyncControl()
        {
            SyncControl sc = new SyncControl(_abstractStorage);
        }
        public bool CheckLogin(string userName, string password)
        {
            return _abstractStorage.CheckPassword(userName, password);
        }
    }
}
