using System;
using System.Linq;
using Calendar_System.StorageSubSystem;
using System.Collections.Generic;

namespace Calendar_System.AccountSubSystem
{
    public class AccountControl
    {
        private readonly IAbstractStorage _abstractStorage;
        public AccountControl(String message, IAbstractStorage abstractStorage)
        {
            _abstractStorage = abstractStorage;
            if (message.Equals("newAccount"))
            {
                AccountFormCreateAccount();
            }
            if (message.Equals("modifyAccount"))
            {
                IList<ProxyUser> users = abstractStorage.GetAllUsersFromDb();
                var allUsersForm = new AllUsersForm(users);
                allUsersForm.ShowDialog();
                //AccountFormModifyAccount(user);
            }
        }

        public void AccountFormCreateAccount()
        {
            var accountForm = new AccountForm(this, new ProxyUser());
            accountForm.Show();
        }

        public void AccountFormModifyAccount(ProxyUser user)
        {
            var accountForm = new AccountForm(this, user);
            accountForm.Show();
        }

        public void DeleteAccount(ProxyUser user)
        {
            throw new NotImplementedException();
        }
        public void DeleteAccountFromDb(ProxyUser user)
        {
            _abstractStorage.DeleteUserFromDb(user);
        }

        public void SendAccountToDb(ProxyUser user)
        {
            _abstractStorage.SendUserToDb(user);
        }
    }
}