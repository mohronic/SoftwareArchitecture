using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Assignment43.Entities;
using Assignment43.NW;

namespace Assignment43.DB
{
    class RepositoryDb : IRepository
    {
        /// <summary>
        /// Returns a list of all the products in the database.
        /// </summary>
        /// <returns></returns>
        public List<Product> Products()
        {
            using (var db = new NorthWindDb())
            {
                return db.Products.ToList();
            }
        }

        /// <summary>
        /// Returns a list of all the categories in the database
        /// </summary>
        /// <returns></returns>
        public List<Category> Categories()
        {
            using (var db = new NorthWindDb())
            {
                return db.Categories.ToList();
            }
        }

        /// <summary>
        /// Returns a list of all the orders in the database
        /// </summary>
        /// <returns></returns>
        public List<Order> Orders()
        {
            using (var db = new NorthWindDb())
            {
                return db.Orders.Include(i => i.Customer).Include(i => i.Employee).Include(i => i.Order_Details.Select(j => j.Product)).ToList();
            }
        }

        /// <summary>
        /// Returns a list of all OrderDetails in the database
        /// </summary>
        /// <returns></returns>
        public List<Order_Detail> OrderDetails()
        {
            using (var db = new NorthWindDb())
            {
                return db.Order_Details.ToList();
            }
        }

        /// <summary>
        /// Returns a list of all Employees in the database
        /// </summary>
        /// <returns></returns>
        public List<Employee> Employees()
        {
            using (var db = new NorthWindDb())
            {
                return db.Employees.ToList();
            }
        }

        /// <summary>
        /// Returns a list of all Customers in the database
        /// </summary>
        /// <returns></returns>
        public List<Customer> Customers()
        {
            using (var db = new NorthWindDb())
            {
                return db.Customers.ToList();
            }
        }

        /// <summary>
        /// Saves an Order in the database
        /// </summary>
        /// <param name="order"></param>
        public Order CreateOrder(Order order)
        {
            using (var db = new NorthWindDb())
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return order;
            }
        }

        /// <summary>
        /// Remove the order with the given ID.
        /// </summary>
        /// <param name="id"></param>
        public void RemoveOrder(int id)
        {
            using (var db = new NorthWindDb())
            {
                var order = db.Orders.Find(id);
                var orderDetails = from od in db.Order_Details
                                   where od.OrderID == id
                                   select od;
                var odlist = orderDetails.ToList();

                var odl = db.Order_Details.Where(i => i.OrderID == id).ToList();

                db.Order_Details.RemoveRange(odl);
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }
    }
}
