using System;
using System.Collections.Generic;
using Calendar_System.AccountSubSystem;

namespace Calendar_System.WorkgroupSubSystem
{
    public class Workgroup
    {
        private string _workgroupName;
        private List<User> _userList;
        public string GetWorkgroupName()
        {
            return _workgroupName;
        }
        public List<User> GetUserList()
        {
            return _userList;
        }
        public Workgroup()
        {

        }
        public Workgroup(String name, List<User> userList)
        {
            _workgroupName = name;
            _userList = userList;
        }

        public void AddUser(User user)
        {
            _userList.Add(user);
        }

        public void RemoveUser(User user)
        {
            _userList.Remove(user);
        }
        public bool UpdateWorkGroup(string name, List<User> userList)
        { 
            if(string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            _workgroupName = name;
            _userList = userList;
            return true;
        }
    }
}
