using System;
using System.Collections.Generic;
using System.Diagnostics;
using MvcCSharp.Models.Data;
using MvcCSharp.Models.ViewModels;
using System.Linq;
using MvcCSharp.Models.InputModels;
using WebGrease.Activities;

namespace MvcCSharp.Models.Repositories
{
    public class OrdersRepository: IOrdersRepository
    {
        private BooksPlusEntities context = new BooksPlusEntities();

        public List<CustomerOrder> GetCustomerOrders(int pageSize, int currentPage)
        {
            try
            {

            var recordsToSkip = (currentPage - 1) * pageSize;
            
            var orders = (from c in context.Customers
                join o in context.Orders 
                    on c.CustomerId equals o.CustomerId
                orderby c.CustomerId, o.OrderDate descending
                select new CustomerOrder
                {
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate
                }).Skip(recordsToSkip)
                .Take(pageSize)
                .ToList();

                return orders;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int GetOrderPageCount(int pageSize)
        {
            var orderCount = context.Orders.Count();
            int pages = orderCount / pageSize + 1;

            return pages;
        }

        public void UpdateCustomerName(CustomerName customerName)
        {
            //var customer1 = (from c in context.Customers
            //                where c.CustomerId == customerName.CustomerId
            //                select c).First();

            //var customer2 = context.Customers
            //                        .Where(c => c.CustomerId == customerName.CustomerId)
            //                        .Select(c => c)
            //                        .First();

            var customer = context.Customers.Find(customerName.CustomerId);
            if (customer != null)
            {
                customer.FirstName = customerName.FirstName;
                customer.LastName = customerName.LastName;

                context.SaveChanges();
            }
        }
    }
}