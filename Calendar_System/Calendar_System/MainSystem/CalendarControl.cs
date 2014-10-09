using System;
using Calendar_System.AccountSubSystem;
using Calendar_System.EntrySubSystem;
using Calendar_System.StorageSubSystem;
using Calendar_System.Utility;

namespace Calendar_System.MainSystem
{
    public class CalendarControl
    {
        IStorage _abstractStorage = new TestStorageImplementor();
        public User User { get; set; }
        public CalendarControl()
        {
            LoginForm loginForm = new LoginForm(this);
            loginForm.ShowDialog();
        }

        public void SuccesfullLogin()
        {
            ClientForm calendarClient = new ClientForm(this, _abstractStorage);
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
        public bool CheckLogin(User user, string password)
        {
            return true;
            //return _abstractStorage.CheckPassword(user, password);
        }

        public void CreateAdminControl()
        {
            AdminControl adminControl = new AdminControl();
        }
    }
}
