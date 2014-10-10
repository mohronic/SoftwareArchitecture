using System;
using System.Collections.Generic;
using Calendar_System.AccountSubSystem;

namespace Calendar_System.WorkgroupSubSystem
{
    public class Workgroup
    {
        public String Name { get; set; }
        public List<User> UserList { get; set; }

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
