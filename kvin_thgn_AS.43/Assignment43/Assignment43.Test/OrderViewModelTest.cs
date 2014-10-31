using System;
using System.ComponentModel;
using System.Linq;
using Assignment43.NW;
using Assignment43.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment43.Test
{
    [TestClass]
    public class OrderViewModelTest
    {
        private OrderViewModel _ovm;
        private NorthWind _nw;
        private bool _isCalled;
        [TestInitialize]
        public void Init()
        {
            _nw = new NorthWind(new TestRepository());
            _ovm = new OrderViewModel(_nw);
            _ovm.PropertyChanged += IsCalled;
        }

        [TestMethod]
        public void TestIsOrdersSet()
        {
            Assert.AreEqual(_ovm.Orders.Count, 3);
        }

        [TestMethod]
        public void TestSetOrder()
        {
            _isCalled = false;
            _ovm.Order = _nw.Orders.First();
            Assert.IsTrue(_isCalled);
            Assert.AreEqual(_ovm.Order, _nw.Orders.First());
        }

        [TestMethod]
        public void TestSetCustomerName()
        {
            _isCalled = false;
            _ovm.CustomerName = "Jan";
            Assert.IsTrue(_isCalled);
            Assert.AreEqual(_ovm.CustomerName, "Jan");
        }

        [TestMethod]
        public void TestSetEmployeeName()
        {
            _isCalled = false;
            _ovm.EmployeeName = "Jan";
            Assert.IsTrue(_isCalled);
            Assert.AreEqual(_ovm.EmployeeName, "Jan");
        }

        [TestMethod]
        public void TestSetOrderDetails()
        {
            _isCalled = false;
            _ovm.OrderDetails = _nw.Orders.First().Order_Details.ToList();
            Assert.IsTrue(_isCalled);
            Assert.AreEqual(_ovm.OrderDetails.Count, 2);
        }

        [TestMethod]
        public void TestSetTotalPrice()
        {
            _isCalled = false;
            _ovm.TotalPrice = 100;
            Assert.IsTrue(_isCalled);
            Assert.AreEqual(_ovm.TotalPrice, 100);
        }

        private void IsCalled(object sender, PropertyChangedEventArgs e)
        {
            _isCalled = true;
        }
    }
}
