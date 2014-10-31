using System;
using System.Linq;
using Calendar_System.StorageSubSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendar_System.Test
{
    [TestClass]
    public class CreateWorkgroupWhiteboxTest
    {
        private AbstractStorage _abstractStorage;
        [TestInitialize]
        public void SetUpTests()
        {
            var storage = new TestStorageImplementor();
            storage.SetConnection(false);
            _abstractStorage = new AbstractStorage(storage);

        }
        [TestMethod]
        [ExpectedException(typeof(NoConnectionException))]
        public void WhiteBoxTest()
        {
            _abstractStorage.GetWorkgroup(2);
        }
        [TestMethod]
        [ExpectedException(typeof(NotInDatabaseException))]
        public void WhiteBoxTest2()
        {
            var storage = new TestStorageImplementor();
            storage.SetConnection(true);
            _abstractStorage.SetStorage(storage);
            _abstractStorage.GetWorkgroup(1000);
        }
        [TestMethod]
        public void WhiteBoxTest3()
        {
            var storage = new TestStorageImplementor();
            storage.SetConnection(true);
            _abstractStorage.SetStorage(storage);
            var workgroup = _abstractStorage.GetAllWorkgroupsFromDb().First();
            var workgroupId = workgroup.GetId();

            Assert.AreEqual(workgroup, _abstractStorage.GetWorkgroup((int)workgroupId));
        }
    }
}