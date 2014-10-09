using System;
using Calendar_System.StorageSubSystem;

namespace Calendar_System.AccountSubSystem
{
    public class AdminControl
    {
        IStorage _abstractStorage = new TestStorageImplementor();
        public AdminControl()
        {
            AdminForm adminClient = new AdminForm(this, _abstractStorage);
            adminClient.ShowDialog();
        }
        public void CreateAccountControl(String message)
        {
            AccountControl ac = new AccountControl(message, _abstractStorage);
        }
    }
}
