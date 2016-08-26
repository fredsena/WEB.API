using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Data.Repository
{
    public interface IRepository
    {
        bool SaveAll();

        // Orders
        //IQueryable<Order> FindOrdersWithOrderDetails(string searchString);
        //IQueryable<Order> GetAllOrders();
        //IQueryable<Order> GetAllOrdersWithOrderDetails();
        //Order GetOrder(int id);
        //Order_Detail GetOrderDetail(int id);

        //// Order_Detail
        //IQueryable<Order_Detail> GetOrderDetailForOrder(int orderId);

        ////Customers
        //IQueryable<Customer> GetAllCustomers();
        //IQueryable<Customer> GetAllCustomerWithOrders();
        //Customer GetCustomer(string id);

        //IEnumerable<Product> GetProductsForOrder(int orderId);
    }
}
