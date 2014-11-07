using System;
using Calendar_System.StorageSubSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendar_System.Test
{
    [TestClass]
    public class DatabaseFactoryTest
    {
        private DatabaseFactory _databaseFactory;
        [TestInitialize]
        public void SetUpTests()
        {
            _databaseFactory = new DatabaseFactory();
        }
        [TestMethod]
        public void IsConnectedTest()
        {
            _databaseFactory.SetTestStorage();
            var abstracStorage = _databaseFactory.GetDatabase();
            var connected = abstracStorage.IsConnected();
            Assert.AreEqual(connected, true);
        }
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void IsConnectedToOnlineStorageTest()
        {
            _databaseFactory.SetOnlineStorage();
            var abstracStorage = _databaseFactory.GetDatabase();
            var connected = abstracStorage.IsConnected();
            Assert.AreEqual(connected, true);
        }
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void IsConnectedToOfflineStorageTest()
        {
            _databaseFactory.SetOfflineStorage();
            var abstracStorage = _databaseFactory.GetDatabase();
            var connected = abstracStorage.IsConnected();
            Assert.AreEqual(connected, true);
        }
        [TestMethod]
        public void SetTestStorageImplementorTest()
        {
            _databaseFactory.SetTestStorage();
            var database = _databaseFactory.GetDatabase().GetStorage();
            Assert.AreEqual(database.GetType(), new TestStorageImplementor().GetType());
        }
        [TestMethod]
        public void SetFileStorageImplementorTest()
        {
            _databaseFactory.SetOfflineStorage();
            var database = _databaseFactory.GetDatabase().GetStorage();
            Assert.AreEqual(database.GetType(), new FileStorageImplementor().GetType());
        }
        [TestMethod]
        public void SetOnlineStorageImplementorTest()
        {
            _databaseFactory.SetOnlineStorage();
            var database = _databaseFactory.GetDatabase().GetStorage();
            Assert.AreEqual(database.GetType(), new DatabaseStorageImplementor().GetType());
        }
    }
}
