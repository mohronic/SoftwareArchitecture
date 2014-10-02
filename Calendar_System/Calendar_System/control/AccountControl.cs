using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.model;
using Calendar_System.view;

namespace Calendar_System.control
{
    public class AccountControl
    {
        AbstractStorage _abstractStorage;
        public AccountControl(String message, AbstractStorage abstractStorage)
        {
            _abstractStorage = abstractStorage;
            if (message.Equals("newAccount"))
            {
                AccountFormCreateAccount();
            }
            if (message.Equals("modifyAccount"))
            {
                // Only to simulate account modification. Searching will be implemented.
                var user = _abstractStorage.GetUsers().First();
                AccountFormModifyAccount(user);
            }
        }

        public void AccountFormCreateAccount()
        {
            var accountForm = new AccountForm(this);
            accountForm.ShowDialog();
        }

        public void AccountFormModifyAccount(User user)
        {
            var accountForm = new AccountForm(this, user);
            accountForm.ShowDialog();
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
            _abstractStorage.CreateUser(user);
            Console.Out.WriteLine(_abstractStorage.GetUsers().Count);
        }
    }
}