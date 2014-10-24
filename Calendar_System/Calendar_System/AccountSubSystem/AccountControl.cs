using System;
using System.Linq;
using Calendar_System.StorageSubSystem;
using System.Collections.Generic;

namespace Calendar_System.AccountSubSystem
{
    public class AccountControl
    {
        private IAbstractStorage _abstractStorage;
        public AccountControl(String message, IAbstractStorage abstractStorage)
        {
            _abstractStorage = abstractStorage;
            if (message.Equals("newAccount"))
            {
                AccountFormCreateAccount();
            }
            if (message.Equals("modifyAccount"))
            {
                IList<User> users = abstractStorage.GetUsers();
                var allUsersForm = new AllUsersForm(users);
                allUsersForm.ShowDialog();
                //AccountFormModifyAccount(user);
            }
        }

        public void AccountFormCreateAccount()
        {
            var accountForm = new AccountForm(this, new User());
            accountForm.Show();
        }

        public void AccountFormModifyAccount(User user)
        {
            var accountForm = new AccountForm(this, user);
            accountForm.Show();
        }

        public void DeleteAccount(User user)
        {
            throw new NotImplementedException();
        }
        public void DeleteAccountFromDb(User user)
        {
            _abstractStorage.DeleteUser(user);
        }

        public void SendAccountToDb(User user)
        {
            _abstractStorage.UserToDb(user);
        }
    }
}