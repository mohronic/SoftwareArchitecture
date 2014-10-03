using System;
using System.Collections.Generic;
using Calendar_System.control;
using Calendar_System.model;
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
            FileStorage abst = new FileStorage();
            EntryControl ec = new EntryControl("newEntry", abst);
            ec.SendEntryToDb(new Entry(DateTime.Now, DateTime.Now, "hello", new List<User>(), "New entry"));
            Assert.IsTrue(abst._entryList.Count > 0);

        }
    }
}
