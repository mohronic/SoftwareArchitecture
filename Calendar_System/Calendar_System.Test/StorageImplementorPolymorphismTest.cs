using System;
using Calendar_System.StorageSubSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendar_System.Test
{
    [TestClass]
    public class StorageImplementorPolymorphismTest
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
        public void IsConnectedOnline()
        {
            _databaseFactory.SetOnlineStorage();
            var abstracStorage = _databaseFactory.GetDatabase();
            var connected = abstracStorage.IsConnected();
            Assert.AreEqual(connected, true);
        }
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void IsConnectedOffline()
        {
            _databaseFactory.SetOfflineStorage();
            var abstracStorage = _databaseFactory.GetDatabase();
            var connected = abstracStorage.IsConnected();
            Assert.AreEqual(connected, true);
        }
    }
}
