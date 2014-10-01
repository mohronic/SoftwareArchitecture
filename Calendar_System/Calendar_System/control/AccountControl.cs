using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.model;
using Calendar_System.view;

namespace Calendar_System.control
{
    class AccountControl
    {
        public void AccountFormCreateAccount()
        {
            var accountForm = new AccountForm();
            accountForm.ShowDialog();
        }

        public void AccountFormModifyAccount(User user)
        {
            var accountForm = new AccountForm(user);
            accountForm.ShowDialog();
        }

        public void DeleteAccount()
        {
            
        }
    }
}