using System;
using System.Linq;
using Calendar_System.StorageSubSystem;

namespace Calendar_System.AccountSubSystem
{
    public class AccountControl
    {
        IAbstractStorage _abstractStorage;
        public AccountControl(String message, IAbstractStorage abstractStorage)
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

        public void SendAccountToDb(string firstName, string lastName, string email, string phone, bool admin)
        {
            var user = new User(firstName, lastName, email, phone, admin);
            _abstractStorage.CreateUser(user);
            Console.Out.WriteLine(_abstractStorage.GetUsers().Count);
        }
    }
}