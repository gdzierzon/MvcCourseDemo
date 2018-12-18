using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcCSharp.Controllers;
using MvcCSharp.Models.Repositories;
using MvcCSharp.Models.ViewModels;

namespace MvcUnitTestDemo.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        [TestMethod]
        public void Index()
        {

            // Arrange
            Mock<IOrdersRepository> repoMock = new Mock<IOrdersRepository>();
            HomeController controller = new HomeController(repoMock.Object);

            // Act
            ViewResult result = controller.Index(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(OrderListViewModel),result.Model.GetType());
        }

        [TestMethod]
        public void OrderListCount_ShouldBeEqualTo_DefaultPageSize()
        {
            // Arrange
            List<CustomerOrder> expetedOrders = new List<CustomerOrder>(10)
            {
                new CustomerOrder(),
                new CustomerOrder(),
                new CustomerOrder(),
                new CustomerOrder(),
                new CustomerOrder(),
                new CustomerOrder(),
                new CustomerOrder(),
                new CustomerOrder(),
                new CustomerOrder(),
                new CustomerOrder()
            };
            Mock<IOrdersRepository> repoMock = new Mock<IOrdersRepository>();
            repoMock.Setup(r => r.GetCustomerOrders(10, 1)).Returns(expetedOrders);
            repoMock.Setup(r => r.GetOrderPageCount(10)).Returns(20);

            HomeController controller = new HomeController(repoMock.Object);

            // Act
            ViewResult result = controller.Index(1) as ViewResult;
            var orderModel = ((OrderListViewModel) result.Model);
            var orders = orderModel.Orders;

            // Assert
            Assert.AreEqual(10, orders.Count,"Default page size is not calculating properly");
            Assert.AreEqual(20, orderModel.TotalPages);
        }
    }
}
