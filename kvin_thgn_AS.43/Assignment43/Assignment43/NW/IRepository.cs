using System.Collections.Generic;
using Assignment43.Entities;

namespace Assignment43.NW
{
    public interface IRepository
    {
        List<Product> Products();
        List<Category> Categories();
        List<Order> Orders();
        List<Employee> Employees();
        Order CreateOrder(Order order);
    }
}
