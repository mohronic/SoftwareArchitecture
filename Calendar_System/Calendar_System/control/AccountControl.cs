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
        public void CreateAccount()
        {
            var accountForm = new AccountForm();
        }

        public void ModifyAccount(User user)
        {
            var accountForm = new AccountForm(user);
        }

        public void DeleteAccount()
        {
            
        }
    }
}
