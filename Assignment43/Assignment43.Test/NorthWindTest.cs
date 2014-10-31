using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment43.NW;

namespace Assignment43.Test
{
    [TestClass]
    public class NorthWindTest
    {
        private NorthWind _nw;
        [TestInitialize]
        public void Init()
        {
            _nw = new NorthWind(new TestRepository());
        }

        [TestMethod]
        public void GetAllTest()
        {
            Assert.AreEqual(_nw.Orders.Count, 3);
            Assert.AreEqual(_nw.Products.Count, 4);
        }

        [TestMethod]
        public void AddOrderTest()
        {
            _nw.AddOrder(new DateTime(), "test", "test", "test", "test", "test", "test");
            Assert.AreEqual(_nw.Orders.Count, 4);
            Assert.AreEqual(_nw.Orders[3].OrderID, 4);
            Assert.AreEqual(_nw.Orders[3].ShipName, "test");
        }

        [TestMethod]
        public void OrderReportTest()
        {
            var rep = _nw.TopOrdersByTotalPrice(1);
            Assert.IsNull(rep.Error);
            Assert.AreEqual(rep.Data.Count, 1);
            Assert.AreEqual(rep.Data.First().OrderId, 1);
            Assert.AreEqual(rep.Data.First().TotalPrice, 240);
            Assert.AreEqual(rep.Data.First().TotalPriceWithDiscount, 220);
        }

        [TestMethod]
        public void OrderReportTwoTest()
        {
            var rep = _nw.TopOrdersByTotalPrice(2);
            Assert.IsNull(rep.Error);
            Assert.AreEqual(rep.Data.Count, 2);
            Assert.AreEqual(rep.Data[0].OrderId, 1);
            Assert.AreEqual(rep.Data[1].OrderId, 3);
        }

        [TestMethod]
        public void OrderReportMoreThanMaxTest()
        {
            var rep = _nw.TopOrdersByTotalPrice(6);
            Assert.IsNull(rep.Error);
            Assert.AreEqual(rep.Data.Count, 3);
        }

        [TestMethod]
        public void ProductReportTest()
        {
            var rep = _nw.TopProductsBySale(1);
            Assert.IsNull(rep.Error);
            Assert.AreEqual(rep.Data.Count, 1);
            Assert.AreEqual(rep.Data.First().ProductId, 3);
            Assert.AreEqual(rep.Data.First().UnitsSoldByMonth.Count, 1);
            Assert.AreEqual(rep.Data.First().UnitsSoldByMonth.First().Month, 2);
            Assert.AreEqual(rep.Data.First().UnitsSoldByMonth.First().UnitsSold, 20);
        }

        [TestMethod]
        public void EmployeeReportTest()
        {
            var rep = _nw.EmployeeSale(1);
            Assert.IsNull(rep.Error);
            Assert.AreEqual(rep.Data.EmployeeName, "Anna Nielsen");
            Assert.AreEqual(rep.Data.Orders.Count, 1);
            Assert.AreEqual(rep.Data.Orders.First().OrderId, 2);
        }

        [TestMethod]
        public void EmployeeNotFoundTest()
        {
            var rep = _nw.EmployeeSale(9);
            Assert.IsNull(rep.Data);
            Assert.IsNotNull(rep.Error);
        }
    }
}
