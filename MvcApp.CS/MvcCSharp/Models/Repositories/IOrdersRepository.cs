using System.Collections.Generic;
using MvcCSharp.Models.InputModels;
using MvcCSharp.Models.ViewModels;

namespace MvcCSharp.Models.Repositories
{
    public interface IOrdersRepository
    {
        List<CustomerOrder> GetCustomerOrders(int pageSize, int currentPage);
        int GetOrderPageCount(int pageSize);
        void UpdateCustomerName(CustomerName customerName);
    }
}