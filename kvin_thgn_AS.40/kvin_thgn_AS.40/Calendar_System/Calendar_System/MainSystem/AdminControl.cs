using System;
using Calendar_System.MainSystem;
using Calendar_System.StorageSubSystem;
using Calendar_System.WorkgroupSubSystem;

namespace Calendar_System.AccountSubSystem
{
    public class AdminControl
    {
        IAbstractStorage _abstractStorage;
        public AdminControl(IAbstractStorage abstractStorage)
        {
            _abstractStorage = abstractStorage;
            AdminForm adminClient = new AdminForm(this);
            adminClient.ShowDialog();
        }
        public void CreateAccountControl(string message)
        {
            AccountControl ac = new AccountControl(message, _abstractStorage);
        }

        public void CreateWorkgroupControl(string message)
        {
            WorkgroupControl wc = new WorkgroupControl(message, _abstractStorage);
        }
    }
}
