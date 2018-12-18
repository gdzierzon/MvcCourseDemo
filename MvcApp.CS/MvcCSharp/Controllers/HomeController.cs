using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using MvcCSharp.Models;
using MvcCSharp.Models.Data;
using MvcCSharp.Models.InputModels;
using MvcCSharp.Models.Repositories;
using MvcCSharp.Models.ViewModels;

namespace MvcCSharp.Controllers
{
    public class HomeController : Controller
    {
        private IOrdersRepository Repository { get; }
        
        public HomeController(IOrdersRepository ordersRepository)
        {
            Repository = ordersRepository;
        }

        [HttpGet]
        public ActionResult Index(int? id)
        {
            int page = id ?? 1;
            if (page < 1) page = 1;

            var orders = GetModel(page);

            return View(orders);
        }

        [HttpPost]
        public ActionResult Index(CustomerName customer, int PageNumber)
        {
            Repository.UpdateCustomerName(customer);
            var orders = GetModel(PageNumber);
            return View(orders);
        }

        private OrderListViewModel GetModel(int pageNumber)
        {
            var orders = new OrderListViewModel()
            {
                PageNumber = pageNumber,
                PageSize = 10
            };
            
            orders.Orders = Repository.GetCustomerOrders(orders.PageSize, pageNumber);
            orders.TotalPages = Repository.GetOrderPageCount(orders.PageSize);

            return orders;
        }
        


    }
}