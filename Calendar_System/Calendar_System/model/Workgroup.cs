using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.model
{
    class Workgroup
    {
        private String Name { get; set; }
        private List<User> UserList { get; set; }

        public Workgroup(String name, List<User> userList)
        {
            Name = name;
            UserList = userList;
        }

        public void AddUser(User user)
        {
            UserList.Add(user);
        }

        public void RemoveUser(User user)
        {
            UserList.Remove(user);
        }
    }
}
