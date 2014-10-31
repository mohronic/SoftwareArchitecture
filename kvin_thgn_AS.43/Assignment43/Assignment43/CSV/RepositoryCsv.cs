using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assignment43.Entities;
using Assignment43.NW;

namespace Assignment43.CSV
{
    /// <summary>
    /// Repository for the CSV file.
    /// </summary>
    public class RepositoryCsv : IRepository
    {
        private List<Category> _categories;
        private List<Product> _products;
        private List<Order> _orders;
        private List<Order_Detail> _orderDetails;
        private List<Employee> _employees;
        private List<Customer> _customers;

        /// <summary>
        /// Creates the repository, containing the data from the CSV file.
        /// </summary>
        public RepositoryCsv()
        {
            _categories = new List<Category>();
            _products = new List<Product>();
            _orders = new List<Order>();
            _orderDetails = new List<Order_Detail>();
            _employees = new List<Employee>();
            _customers = new List<Customer>();
            Load();
        }

        //Loads the data from the CSV file.
        private void Load()
        {
            loadCustomers();
            loadEmployees();
            loadCategories();
            loadProducts();
            loadOrders();
            loadOrderDetails();
        }

        private void loadCustomers()
        {
            var reader = new StreamReader("./NorthwindCSV/customers.csv");
            reader.ReadLine();
            //CustomerID;CompanyName;ContactName;ContactTitle;Address;City;Region;PostalCode;Country;Phone;Fax
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                var customer = new Customer()
                {
                    CustomerID = values[0].Trim(),
                    CompanyName = values[1],
                    ContactName = values[2],
                    ContactTitle = values[3],
                    Address = values[4],
                    City = values[5],
                    Region = values[6],
                    PostalCode = values[7],
                    Country = values[8],
                    Phone = values[9],
                    Fax = values[10]
                };
                _customers.Add(customer);
            }
        }

        private void loadEmployees()
        {
            var reader = new StreamReader("./NorthwindCSV/employees.csv");
            reader.ReadLine();
            //EmployeeID;LastName;FirstName;Title;TitleOfCourtesy;BirthDate;HireDate;Address;City;Region;PostalCode;Country;HomePhone;Extension;Notes;ReportsTo
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                DateTime? nullDate = null;
                int? nullInt = null;
                var employee = new Employee()
                {
                    EmployeeID = int.Parse(values[0]),
                    LastName = values[1],
                    FirstName = values[2],
                    Title = values[3],
                    TitleOfCourtesy = values[4],
                    BirthDate = (string.IsNullOrWhiteSpace(values[5])) ? Convert.ToDateTime(values[5]) : nullDate,
                    HireDate = (string.IsNullOrWhiteSpace(values[6])) ? Convert.ToDateTime(values[6]) : nullDate,
                    Address = values[7],
                    City = values[8],
                    Region = values[9],
                    PostalCode = values[10],
                    Country = values[11],
                    HomePhone = values[12],
                    Extension = values[13],
                    Notes = values[14],
                    ReportsTo = (!string.IsNullOrWhiteSpace(values[15]) && values[15] != "NULL") ? int.Parse(values[15]) : nullInt
                };
                _employees.Add(employee);
            }
            foreach (var e in _employees)
            {
                var employer = (e.ReportsTo != null) ? _employees.Single(i => i.EmployeeID == e.ReportsTo) : null;
                e.Employee1 = employer;
                if (employer != null) employer.Employees1.Add(e);
            }
        }

        private void loadCategories()
        {
            var reader = new StreamReader("./NorthwindCSV/categories.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                int id = int.Parse(values[0]);
                _categories.Add(new Category()
                {
                    CategoryID = id,
                    CategoryName = values[1],
                    Description = values[2]
                });
            }
            reader.Dispose();
        }

        private void loadProducts()
        {
            var reader = new StreamReader("./NorthwindCSV/products.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                var id = int.Parse(values[0]);
                var supplierId = int.Parse(values[2]);
                var categoryId = int.Parse(values[3]);
                Category category = _categories.Single(i => i.CategoryID == categoryId);
                var unitPrice = decimal.Parse(values[5]);
                var unitStock = short.Parse(values[6]);
                var unitOrder = short.Parse(values[7]);
                var reorderLvl = short.Parse(values[8]);
                var discontinued = int.Parse(values[9]);
                var disc = Convert.ToBoolean(discontinued);
                var product = new Product()
                {
                    ProductID = id,
                    ProductName = values[1],
                    SupplierID = supplierId,
                    CategoryID = categoryId,
                    QuantityPerUnit = values[4],
                    UnitPrice = unitPrice,
                    UnitsInStock = unitStock,
                    UnitsOnOrder = unitOrder,
                    ReorderLevel = reorderLvl,
                    Discontinued = disc
                };
                product.Category = category;
                category.Products.Add(product);
                _products.Add(product);
            }
            reader.Dispose();
        }

        private void loadOrders()
        {
            var reader = new StreamReader("./NorthwindCSV/orders.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                int id = int.Parse(values[0]);
                int employeeId = int.Parse(values[2]);
                var orderDate = (values[3] != "") ? Convert.ToDateTime(values[3]) : new DateTime?();
                var requiredDate = (values[4] != "") ? Convert.ToDateTime(values[4]) : new DateTime?();
                var shippedDate = (values[5] != "") ? Convert.ToDateTime(values[5]) : new DateTime?();
                var shipVia = int.Parse(values[6]);
                decimal freight = decimal.Parse(values[7]);
                var order = new Order()
                {
                    OrderID = id,
                    CustomerID = values[1],
                    EmployeeID = employeeId,
                    OrderDate = orderDate,
                    RequiredDate = requiredDate,
                    ShippedDate = shippedDate,
                    ShipVia = shipVia,
                    Freight = freight,
                    ShipName = values[8],
                    ShipAddress = values[9],
                    ShipCity = values[10],
                    ShipRegion = values[11],
                    ShipPostalCode = values[12],
                    ShipCountry = values[13]
                };
                _employees.Single(i => i.EmployeeID == employeeId).Orders.Add(order);
                _customers.Single(i => i.CustomerID.Equals(values[1])).Orders.Add(order);
                order.Customer = _customers.Single(i => i.CustomerID.Equals(values[1]));
                order.Employee = _employees.Single(i => i.EmployeeID == employeeId);
                _orders.Add(order);
            }
            reader.Dispose();
        }

        private void loadOrderDetails()
        {
            var reader = new StreamReader("./NorthwindCSV/order_details.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                int orderId = int.Parse(values[0]);
                int productId = int.Parse(values[1]);
                var orderDetail = new Order_Detail()
                {
                    OrderID = orderId,
                    ProductID = productId,
                    UnitPrice = decimal.Parse(values[2]),
                    Quantity = short.Parse(values[3]),
                    Discount = float.Parse(values[4])
                };
                _orders.Single(i => i.OrderID == orderId).Order_Details.Add(orderDetail);
                _products.Single(i => i.ProductID == productId).Order_Details.Add(orderDetail);
                orderDetail.Order = _orders.Single(i => i.OrderID == orderId);
                orderDetail.Product = _products.Single(i => i.ProductID == productId);
                _orderDetails.Add(orderDetail);
            }
            reader.Dispose();

        }

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        public List<Product> Products()
        {
            return _products;
        }

        /// <summary>
        /// Returns all categories
        /// </summary>
        /// <returns></returns>
        public List<Category> Categories()
        {
            return _categories;
        }

        /// <summary>
        /// Returns all orders
        /// </summary>
        /// <returns></returns>
        public List<Order> Orders()
        {
            return _orders;
        }

        /// <summary>
        /// Returns all employees
        /// </summary>
        /// <returns></returns>
        public List<Employee> Employees()
        {
            return _employees;
        }

        /// <summary>
        /// Saves an order in the repository, but not to the file
        /// </summary>
        /// <param name="order"></param>
        public Order CreateOrder(Order order)
        {
            int maxId;
            maxId = _orders.Count() != 0 ? _orders.OrderByDescending(i => i.OrderID).FirstOrDefault().OrderID : 0;
            order.OrderID = maxId + 1;
            _orders.Add(order);
            return order;
        }
    }
}
