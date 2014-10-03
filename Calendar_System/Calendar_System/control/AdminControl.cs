using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.model;
using Calendar_System.view;

namespace Calendar_System.control
{
    public class AdminControl
    {
        IStorage _abstractStorage = new FileStorage();
        public AdminControl()
        {
            AdminClient adminClient = new AdminClient(this, _abstractStorage);
            adminClient.ShowDialog();
        }
        public void CreateAccountControl(String message)
        {
            AccountControl ac = new AccountControl(message, _abstractStorage);
        }
    }
}
