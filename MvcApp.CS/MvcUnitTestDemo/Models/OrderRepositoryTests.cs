using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcCSharp.Models.Repositories;

namespace MvcUnitTestDemo.Models
{
    [TestClass]
    public class OrderRepositoryTests
    {
        [TestMethod]
        public void OrderPageCount_ShouldBe_CorrectForPageSize()
        {
            //arrange
            var repo = new OrdersRepository();
            var expectedPages = 396;

            //act
            var actualPages = repo.GetOrderPageCount(10);

            //assert
            Assert.AreEqual(expectedPages, actualPages);

        }
    }
}
