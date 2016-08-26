using Sms.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Data.Repository
{

    public class Repository : IRepository
    {
        private dbSMSContext _context;
        public Repository(dbSMSContext context)
        {
            _context = context;
        }

        public IQueryable<SmsTransaction> GetAllCustomers()
        {
            return _context.SmsTransactions;
        }

        //public IQueryable<Customer> GetAllCustomerWithOrders()
        //{
        //    return _context.Customers.Include("Orders");
        //}

        //public Customer GetCustomer(string id)
        //{
        //    return _context.Customers.Include("Orders").Where(c => c.CustomerID == id).FirstOrDefault();
        //}

        //public IQueryable<Order> GetAllOrders()
        //{
        //    return _context.Orders;
        //}

        //public IQueryable<Order> GetAllOrdersWithOrderDetails()
        //{
        //    return _context.Orders.Include("Order_Details");
        //}

        //public Order GetOrder(int id)
        //{
        //    return _context.Orders.Include("Order_Details").Where(o => o.OrderID == id).FirstOrDefault();
        //}

        //public Order_Detail GetOrderDetail(int id)
        //{
        //    return _context.Order_Details.Include("Order").Where(od => od.OrderID == id).FirstOrDefault();
        //}

        //public IQueryable<Order_Detail> GetOrderDetailForOrder(int orderId)
        //{
        //    return _context.Order_Details.Include("Order").Where(o => o.OrderID == orderId);
        //}


        //public IEnumerable<Product> GetProductsForOrder(int orderId)
        //{
        //    //return _context.Products.Where(p => p.Order_Details = orderId);

        //    return (from o in _context.Order_Details
        //            join p in _context.Products on o.ProductID equals p.ProductID
        //            where o.OrderID == orderId
        //            select new { ProductName = p.ProductName, CategoryID = p.CategoryID, ProductID = p.ProductID }).ToList()
        //                  .Select(x => new Product { ProductName = x.ProductName, CategoryID = x.CategoryID, ProductID = x.ProductID });


        //}

        public bool SaveAll()
        {
            throw new NotImplementedException();
        }
    }
}
