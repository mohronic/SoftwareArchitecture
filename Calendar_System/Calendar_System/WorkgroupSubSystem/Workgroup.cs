using System;
using System.Collections.Generic;
using Calendar_System.AccountSubSystem;

namespace Calendar_System.WorkgroupSubSystem
{
    public class Workgroup
    {
        private string _workgroupName;
        private IList<ProxyUser> _userList;
        private int? _id;
        public string GetWorkgroupName()
        {
            return _workgroupName;
        }
        public IList<ProxyUser> GetUserList()
        {
            return _userList;
        }
        public int? GetId()
        {
            return _id;
        }
        public Workgroup()
        {

        }
        public Workgroup(String name, IList<ProxyUser> userList, int? id)
        {
            _workgroupName = name;
            _userList = userList;
            _id = id;
        }

        public void AddUser(ProxyUser user)
        {
            _userList.Add(user);
        }

        public void RemoveUser(ProxyUser user)
        {
            _userList.Remove(user);
        }
        public bool UpdateWorkGroup(string name, List<ProxyUser> userList)
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
