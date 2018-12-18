using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCSharp.Models.ViewModels
{
    public class OrderListViewModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public List<CustomerOrder> Orders { get; set; }
    }
}