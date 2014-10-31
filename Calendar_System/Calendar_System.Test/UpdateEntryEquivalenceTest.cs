using System;
using Calendar_System.EntrySubSystem;
using Calendar_System.StorageSubSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendar_System.Test
{
    [TestClass]
    public class UpdateEntryEquivalenceTest
    {
        private AbstractStorage _abstractStorage;
        private Entry _entry;
        [TestInitialize]
        public void SetUpTests()
        {
            _abstractStorage = new AbstractStorage(new TestStorageImplementor());
            _entry = new Entry();

        }
        [TestMethod]
        public void InvalidStartDateTest()
        {
            var startDate = new DateTime(2013, 12, 12);
            var complete = _entry.UpdateEntry(startDate, startDate, "Here", null, "The appointment");
            Assert.AreEqual(complete, false);
        }
        [TestMethod]
        public void InvalidEndDateTest()
        {
            var endDate = new DateTime(2013, 12, 12);
            var complete = _entry.UpdateEntry(endDate, endDate, "Here", null, "The appointment");
            Assert.AreEqual(complete, false);
        }

        [TestMethod]
        public void InvalidNameTest()
        {
            var startDate = new DateTime(2014, 12, 12);
            var endDate = new DateTime(2015, 12, 12);
            var complete = _entry.UpdateEntry(startDate, endDate, "Here", null, null);
            Assert.AreEqual(complete, false);
        }
        [TestMethod]
        public void AcceptedUpdateTest()
        {
            var startDate = new DateTime(2014, 12, 12);
            var endDate = new DateTime(2015, 12, 12);
            var complete = _entry.UpdateEntry(startDate, endDate, "Here", null, "The appointment");
            Assert.AreEqual(complete, true);
        }
    }
}