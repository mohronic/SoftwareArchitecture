using System;
using System.Web.Mvc;
using Assignment44.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment44.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void TestDetailsWithOrderId()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            ViewResult result = controller.Details(1, 1) as ViewResult;

            // Assert
            Assert.AreEqual(1, result.ViewBag.OrderId);
            Assert.IsTrue(!result.ViewData.Model.Equals(null));
        }

        public void TestDetailsWithoutOrderId()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            ViewResult result = controller.Details(1, null) as ViewResult;

            // Assert
            Assert.AreEqual(null, result.ViewBag.OrderId);
            Assert.IsTrue(!result.ViewData.Model.Equals(null));

        }
    }
}
