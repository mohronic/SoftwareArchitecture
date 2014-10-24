using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Calendar_System.AccountSubSystem;
using Calendar_System.EntrySubSystem;
using Calendar_System.StorageSubSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendar_System.Test
{
    [TestClass]
    public class TestStorageImplementationTest
    {
        private ProxyUser _user;
        private Entry _entry;
        private List<Entry> _entryList; 
        private AbstractStorage _abstractStorage;

        [TestInitialize]
        public void SetUpTests()
        {
            _abstractStorage = new AbstractStorage(new TestStorageImplementor());
        }
        /// <summary>
        /// Test for create entry, just close the window when it runs, since it isn't needed.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotInDatabaseException))]
        public void DeleteNewUserTest()
        {
            _user = new ProxyUser("Karl", "Karlsen", "karl@karl.com", "32435465", "12345", true, 2, new List<Entry>());
            _abstractStorage.DeleteUserFromDb(_user);           
        }
        [TestMethod]
        public void DeleteExistingUserTest()
        {
            _user = _abstractStorage.GetAllUsersFromDb().First();
            int preCount = _abstractStorage.GetAllUsersFromDb().Count;
            Assert.AreNotEqual(_user.GetId(), null);
            _user = _abstractStorage.GetAllUsersFromDb().First();
            _abstractStorage.DeleteUserFromDb(_user);
            int postCount = _abstractStorage.GetAllUsersFromDb().Count;
            Assert.AreEqual(preCount -1, postCount);
        }
        [TestMethod]
        public void CreateNewUserTest()
        {
            int preCount = _abstractStorage.GetAllUsersFromDb().Count;
            _user = new ProxyUser();
            _abstractStorage.CreateUser(_user);
            int postCount = _abstractStorage.GetAllUsersFromDb().Count;
            Assert.AreEqual(preCount + 1, postCount);
        }
        [TestMethod]
        [ExpectedException(typeof(AlreadyInDatabaseException))]
        public void CreateExistingUserTest()
        {
            _user = _abstractStorage.GetAllUsersFromDb().First();
            _abstractStorage.CreateUser(_user);
        }

        [TestMethod]
        public void CreateNewEntryTest()
        {
            _user = _abstractStorage.GetAllUsersFromDb().First();
            _entryList = _user.GetEntryList();
            int preCount = _entryList.Count;
            _entry = new Entry();
            _abstractStorage.SendEntryToDb(_user, _entry);
            int postCount = _abstractStorage.GetAllUsersFromDb().First().GetEntryList().Count;
            Assert.AreEqual(preCount + 1, postCount);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyInDatabaseException))]
        public void CreateExistingEntryTest()
        {
            _user = _abstractStorage.GetAllUsersFromDb().First();
            _entry = _user.GetEntryList().First();
            _abstractStorage.SendEntryToDb(_user, _entry);
        }
        [TestMethod]
        [ExpectedException(typeof(NotInDatabaseException))]
        public void DeleteNewEntryTest()
        {
            _user = _abstractStorage.GetAllUsersFromDb().First();
            _entry = new Entry(new DateTime(2000, 12, 31), new DateTime(2000, 12, 31), "Here", new List<ProxyUser>(),
                "This name", 2, (int)_user.GetId());
            _abstractStorage.DeleteEntryFromDb(_user, _entry);
        }
        [TestMethod]
        public void DeleteExistingEntryTest()
        {
            _user = _abstractStorage.GetAllUsersFromDb().First();
            _entry = _user.GetEntryList().First();
            int preCount = _user.GetEntryList().Count;
            Assert.AreNotEqual(_entry.GetId(), null);
            _abstractStorage.DeleteEntryFromDb(_user, _entry);
            int postCount = _abstractStorage.GetAllUsersFromDb().First().GetEntryList().Count;
            Assert.AreEqual(preCount - 1, postCount);
        }
    }
}
