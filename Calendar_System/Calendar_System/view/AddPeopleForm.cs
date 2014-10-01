using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calendar_System.model;

namespace Calendar_System.view
{
    class AddPeopleForm : Form
    {
        private List<User> _addedUsers;

        public AddPeopleForm(List<User> userList)
        {
            _addedUsers = userList;
        }
        public List<User> GetUserList()
        {
            return _addedUsers;
        }

        private void Setup() { }

        private void ButtonEventAddUser() { }

        public void AddUser(User user)
        {
            if (!_addedUsers.Contains(user))
            {
                _addedUsers.Add(user);   
            }
        }

        public void DeleteUser(User user)
        {
            if (_addedUsers.Contains(user))
            {
                _addedUsers.Remove(user);   
            }
        }

        public bool ContainsUser(User user)
        {
            return _addedUsers.Contains(user);
        }
    }
}
