using System.Collections.Generic;
using System.Windows.Forms;
using Calendar_System.AccountSubSystem;

namespace Calendar_System.MainSystem
{
    public class AddPeopleForm : Form
    {
        private List<ProxyUser> AddedUsers { get; set; }

        public AddPeopleForm()
        {
            if (AddedUsers == null)
            {
                AddedUsers = new List<ProxyUser>();
            }
        }
        public List<ProxyUser> GetUserList()
        {
            return AddedUsers;
        }

        private void Setup() { }

        private void ButtonEventAddUser() { }

        public void AddUser(ProxyUser user)
        {
            if (!AddedUsers.Contains(user))
            {
                AddedUsers.Add(user);   
            }
        }

        public void DeleteUser(ProxyUser user)
        {
            if (AddedUsers.Contains(user))
            {
                AddedUsers.Remove(user);   
            }
        }

        public bool ContainsUser(ProxyUser user)
        {
            return AddedUsers.Contains(user);
        }
    }
}
