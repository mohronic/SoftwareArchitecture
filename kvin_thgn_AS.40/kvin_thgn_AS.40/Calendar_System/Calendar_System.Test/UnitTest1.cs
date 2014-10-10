using System;
using System.Collections.Generic;
using Calendar_System.AccountSubSystem;
using Calendar_System.EntrySubSystem;
using Calendar_System.StorageSubSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendar_System.Test
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test for create entry, just close the window when it runs, since it isn't needed.
        /// </summary>
        [TestMethod]
        public void CreateEntryTest()
        {
            TestStorageImplementor abst = new TestStorageImplementor();
            EntryControl ec = new EntryControl("newEntry", abst);
            ec.SendEntryToDb(DateTime.Now, DateTime.Now, "hello", new List<User>(), "New entry");
            Assert.IsTrue(abst.GetEntriesForUser().Count > 0);

        }
    }
}
