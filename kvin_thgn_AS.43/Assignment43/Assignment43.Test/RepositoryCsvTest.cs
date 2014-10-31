using System;
using System.Linq;
using Assignment43.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment43.CSV;

namespace Assignment43.Test
{
    [TestClass]
    public class RepositoryCsvTest
    {
        private RepositoryCsv _rep;

        [TestInitialize]
        public void Init()
        {
            _rep = new RepositoryCsv();
        }

        [TestMethod]
        public void TestProducts()
        {
            var products = _rep.Products();
            Assert.AreEqual(products.Count, 77);
            Assert.IsTrue(products.First().Order_Details.Count > 0);
        }

        [TestMethod]
        public void TestOrders()
        {
            var orders = _rep.Orders();
            Assert.AreEqual(orders.Count, 830);
            Assert.IsTrue(orders.First().Order_Details.Count > 0);
            Assert.IsTrue(orders.First().Customer != null);
        }

        [TestMethod]
        public void TestCategories()
        {
            var categories = _rep.Categories();
            Assert.AreEqual(categories.Count, 8);
            Assert.IsTrue(categories.First().Products.Count > 0);
        }

        [TestMethod]
        public void TestEmployees()
        {
            var employees = _rep.Employees();
            Assert.AreEqual(employees.Count, 9);
            Assert.IsTrue(employees.First().Orders.Count > 0);
        }

        [TestMethod]
        public void TestCreateOrder()
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                RequiredDate = new DateTime(2016, 8, 21),
                ShipName = "test",
                ShipAddress = "test",
                ShipCity = "test",
                ShipRegion = "test",
                ShipPostalCode = "test",
                ShipCountry = "test"
            };
            var countBefore = _rep.Orders().Count;
            var maxIdBefore = _rep.Orders().OrderByDescending(i => i.OrderID).First().OrderID;
            _rep.CreateOrder(order);
            Assert.AreEqual(countBefore + 1, _rep.Orders().Count);
            Assert.AreEqual(maxIdBefore + 1, _rep.Orders().OrderByDescending(i => i.OrderID).First().OrderID);
        }
    }
}
