using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Calendar_System.AccountSubSystem;
using Calendar_System.EntrySubSystem;
using Calendar_System.StorageSubSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendar_System.Test
{
    /// <summary>
    /// This test is a equivalence test of the Entry class. It currently tests the UpdateEntry method. We start with a test,
    /// which returns true, and then we substitute one parametre at a time and test it with an input from the parametres different
    /// equivalence classes.
    /// </summary>
    [TestClass]
    public class EntryTest
    {
        private AbstractStorage _abstractStorage;
        private Entry _entry;
        private ProxyUser _user;
        private IList<ProxyUser> _userList;
        [TestInitialize]
        public void SetUpTests()
        {
            _abstractStorage = new AbstractStorage(new TestStorageImplementor());
            _userList = _abstractStorage.GetAllUsersFromDb();
            _user = _userList.First();
            _entry = new Entry((int)_user.GetId());
        }
        [TestMethod]
        public void AcceptedUpdateTest()
        {
            var startDate = DateTime.Now + new TimeSpan(1, 1, 1, 1);
            var endDate = DateTime.Now + new TimeSpan(2, 2, 2, 2);
            var complete = _entry.UpdateEntry(startDate, endDate, "Here", _userList, "The appointment");
            Assert.AreEqual(complete, true);
        }
        [TestMethod]
        public void InvalidStartDateTest()
        {
            var startDate = DateTime.Now - new TimeSpan(1, 1, 1, 1);
            var complete = _entry.UpdateEntry(startDate, startDate, "Here", _userList, "The appointment");
            Assert.AreEqual(complete, false);
        }
        [TestMethod]
        public void InvalidEndDateTest()
        {
            var endDate = DateTime.Now - new TimeSpan(1, 1, 1, 1);
            var complete = _entry.UpdateEntry(endDate, endDate, "Here", _userList, "The appointment");
            Assert.AreEqual(complete, false);
        }
        [TestMethod]
        public void LocationNullTest()
        {
            var startDate = DateTime.Now + new TimeSpan(1, 1, 1, 1);
            var endDate = DateTime.Now + new TimeSpan(2, 2, 2, 2);
            var complete = _entry.UpdateEntry(startDate, endDate, null, _userList, "The appointment");
            Assert.AreEqual(complete, true);
        }
        [TestMethod]
        public void LocationWhiteSpaceTest()
        {
            var startDate = DateTime.Now + new TimeSpan(1, 1, 1, 1);
            var endDate = DateTime.Now + new TimeSpan(2, 2, 2, 2);
            var complete = _entry.UpdateEntry(startDate, endDate, "", _userList, "The appointment");
            Assert.AreEqual(complete, true);
        }
        [TestMethod]
        public void UserListNullTest()
        {
            var startDate = DateTime.Now + new TimeSpan(1, 1, 1, 1);
            var endDate = DateTime.Now + new TimeSpan(2, 2, 2, 2);
            var complete = _entry.UpdateEntry(startDate, endDate, "Here", null, "The appointment");
            Assert.AreEqual(complete, true);
        }
        [TestMethod]
        public void UserListEmptyTest()
        {
            _userList = new List<ProxyUser>();
            var startDate = DateTime.Now + new TimeSpan(1, 1, 1, 1);
            var endDate = DateTime.Now + new TimeSpan(2, 2, 2, 2);
            var complete = _entry.UpdateEntry(startDate, endDate, "Here", _userList, "The appointment");
            Assert.AreEqual(complete, true);
        }
        [TestMethod]
        public void EntryNameWhiteSpaceTest()
        {
            var startDate = DateTime.Now + new TimeSpan(1, 1, 1, 1);
            var endDate = DateTime.Now + new TimeSpan(2, 2, 2, 2);
            var complete = _entry.UpdateEntry(startDate, endDate, "Here", _userList, "");
            Assert.AreEqual(complete, false);
        }
        [TestMethod]
        public void EntryNameNullTest()
        {
            var startDate = DateTime.Now + new TimeSpan(1, 1, 1, 1);
            var endDate = DateTime.Now + new TimeSpan(2, 2, 2, 2);
            var complete = _entry.UpdateEntry(startDate, endDate, "Here", _userList, null);
            Assert.AreEqual(complete, false);
        }
    }
}