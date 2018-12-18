using System;
using System.Security.AccessControl;

namespace MvcCSharp.Models.ViewModels
{
    public class CustomerOrder
    {
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}