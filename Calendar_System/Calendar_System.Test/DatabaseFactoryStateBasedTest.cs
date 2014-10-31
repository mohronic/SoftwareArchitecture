using System;
using Calendar_System.EntrySubSystem;
using Calendar_System.StorageSubSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendar_System.Test
{
    [TestClass]
    public class DatabaseFactoryStateBasedTest
    {
        private DatabaseFactory _databaseFactory;
        [TestInitialize]
        public void SetUpTests()
        {
            _databaseFactory = new DatabaseFactory();
        }
        [TestMethod]
        public void SetTestStorageTest()
        {
            _databaseFactory.SetTestStorage();
            var database = _databaseFactory.GetDatabase().GetStorage();
            Assert.AreEqual(database.GetType(), new TestStorageImplementor().GetType());
        }
        [TestMethod]
        public void SetOfflineStorageTest()
        {
            _databaseFactory.SetOfflineStorage();
            var database = _databaseFactory.GetDatabase().GetStorage();
            Assert.AreEqual(database.GetType(), new FileStorageImplementor().GetType());
        }
        [TestMethod]
        public void SetOnlineStorageTest()
        {
            _databaseFactory.SetOnlineStorage();
            var database = _databaseFactory.GetDatabase().GetStorage();
            Assert.AreEqual(database.GetType(), new DatabaseStorageImplementor().GetType());
        }
    }
}
