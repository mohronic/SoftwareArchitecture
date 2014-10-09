using System.Collections.Generic;
using System.Windows.Forms;
using Calendar_System.AccountSubSystem;

namespace Calendar_System.MainSystem
{
    public class AddPeopleForm : Form
    {
        private List<User> AddedUsers { get; set; }

        public AddPeopleForm()
        {
            if (AddedUsers == null)
            {
                AddedUsers = new List<User>();
            }
        }
        public List<User> GetUserList()
        {
            return AddedUsers;
        }

        private void Setup() { }

        private void ButtonEventAddUser() { }

        public void AddUser(User user)
        {
            if (!AddedUsers.Contains(user))
            {
                AddedUsers.Add(user);   
            }
        }

        public void DeleteUser(User user)
        {
            if (AddedUsers.Contains(user))
            {
                AddedUsers.Remove(user);   
            }
        }

        public bool ContainsUser(User user)
        {
            return AddedUsers.Contains(user);
        }
    }
}
