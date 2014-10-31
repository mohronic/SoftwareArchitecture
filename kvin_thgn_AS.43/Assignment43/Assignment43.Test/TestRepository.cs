using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment43.Entities;
using Assignment43.NW;
using Assignment43.Report;
using Assignment43.Report.DTO;

namespace Assignment43.Test
{
    public class TestRepository : IRepository
    {
        private List<Product> _products;
        private List<Category> _categories;
        private List<Order> _orders;
        private List<Customer> _customers;
        private List<Employee> _employees;
        private List<Order_Detail> _orderDetails;

        public TestRepository()
        {
            Init();
        }

        public void Init()
        {
            _customers = new List<Customer>();
            _customers.Add(new Customer()
            {
                CustomerID = "1",
                ContactName = "Jens"
            });
            _customers.Add(new Customer()
            {
                CustomerID = "2",
                ContactName = "Troels"
            });

            _categories = new List<Category>();
            _categories.Add(new Category()
            {
                CategoryID = 1,
                CategoryName = "Hardware",
                Description = "for computers"
            });
            _categories.Add(new Category()
            {
                CategoryID = 2,
                CategoryName = "Traning Equipment",
                Description = "for physical training"
            });

            _products = new List<Product>();
            _products.Add(new Product()
            {
                ProductID = 3,
                ProductName = "SSD",
                QuantityPerUnit = "1 per box",
                Category = _categories[0],
                CategoryID = 1,
                UnitPrice = 10.0m,
                UnitsInStock = 10,
                UnitsOnOrder = 23,
                ReorderLevel = 14,
                Discontinued = false
            });
            _products.Add(new Product()
            {
                ProductID = 1,
                ProductName = "HDD",
                QuantityPerUnit = "1 per box",
                Category = _categories[0],
                CategoryID = 1,
                UnitPrice = 4.0m,
                UnitsInStock = 15,
                UnitsOnOrder = 10,
                ReorderLevel = 9,
                Discontinued = false
            });
            _products.Add(new Product()
            {
                ProductID = 4,
                ProductName = "Dumbbell",
                QuantityPerUnit = "2 per box",
                Category = _categories[1],
                CategoryID = 2,
                UnitPrice = 8.0m,
                UnitsInStock = 2,
                UnitsOnOrder = 4,
                ReorderLevel = 3,
                Discontinued = true
            });
            _products.Add(new Product()
            {
                ProductID = 2,
                ProductName = "Kettlebell",
                QuantityPerUnit = "1 per box",
                Category = _categories[1],
                CategoryID = 2,
                UnitPrice = 6.0m,
                UnitsInStock = 10,
                UnitsOnOrder = 11,
                ReorderLevel = 7,
                Discontinued = false
            });

            _orders = new List<Order>();
            _orders.Add(new Order()
            {
                OrderID = 1,
                OrderDate = new DateTime(2013, 2, 10),
                RequiredDate = new DateTime(2012, 2, 15),
                ShippedDate = new DateTime(2012, 2, 13),
                Freight = null,
                ShipName = "",
                ShipAddress = "",
                ShipCity = "",
                ShipCountry = "",
                ShipPostalCode = "",
                ShipRegion = "",
                ShipVia = null,
                CustomerID = "1",
                EmployeeID = 2
            });
            _orders.Add(new Order()
            {
                OrderID = 2,
                OrderDate = new DateTime(2013, 2, 10),
                RequiredDate = new DateTime(2012, 2, 15),
                ShippedDate = new DateTime(2012, 2, 13),
                Freight = null,
                ShipName = "",
                ShipAddress = "",
                ShipCity = "",
                ShipCountry = "",
                ShipPostalCode = "",
                ShipRegion = "",
                ShipVia = null,
                CustomerID = "2",
                EmployeeID = 1
            });
            _orders.Add(new Order()
            {
                OrderID = 3,
                OrderDate = new DateTime(2013, 2, 10),
                RequiredDate = new DateTime(2012, 2, 15),
                ShippedDate = new DateTime(2012, 2, 13),
                Freight = null,
                ShipName = "",
                ShipAddress = "",
                ShipCity = "",
                ShipCountry = "",
                ShipPostalCode = "",
                ShipRegion = "",
                ShipVia = null,
                CustomerID = "1",
                EmployeeID = 2
            });

            _orders[0].Customer = _customers[0];
            _orders[1].Customer = _customers[1];
            _orders[2].Customer = _customers[0];

            _orderDetails = new List<Order_Detail>(new[]
            {
                new Order_Detail()
                {
                    Discount = 0f,
                    Order = _orders.Find(o => o.OrderID == 1),
                    OrderID = 1,
                    Product = _products.Find(p => p.ProductID == 1),
                    ProductID = 1,
                    Quantity = 10,
                    UnitPrice = 4.0m //total price: 40
                },
                new Order_Detail()
                {
                    Discount = 0.1f,
                    Order = _orders.Find(o => o.OrderID == 1),
                    OrderID = 1,
                    Product = _products.Find(p => p.ProductID == 3),
                    ProductID = 3,
                    Quantity = 20,
                    UnitPrice = 10.0m //total price: 180
                },
                new Order_Detail()
                {
                    Discount = 0.0f,
                    Order = _orders.Find(o => o.OrderID == 2),
                    OrderID = 2,
                    Product = _products.Find(p => p.ProductID == 4),
                    ProductID = 4,
                    Quantity = 4,
                    UnitPrice = 8.0m //total price: 32
                },
                new Order_Detail()
                {
                    Discount = 0.2f,
                    Order = _orders.Find(o => o.OrderID == 3),
                    OrderID = 3,
                    Product = _products.Find(p => p.ProductID == 2),
                    ProductID = 2,
                    Quantity = 10,
                    UnitPrice = 6.0m //total price: 48
                },
            });
            _products[0].Order_Details.Add(_orderDetails[1]);
            _products[1].Order_Details.Add(_orderDetails[0]);
            _products[2].Order_Details.Add(_orderDetails[2]);
            _products[3].Order_Details.Add(_orderDetails[3]);
            _orders[0].Order_Details.Add(_orderDetails[0]);
            _orders[0].Order_Details.Add(_orderDetails[1]);
            _orders[1].Order_Details.Add(_orderDetails[2]);
            _orders[2].Order_Details.Add(_orderDetails[3]);

            _employees = new List<Employee>(new[]
            {
                new Employee()
                {
                    EmployeeID = 1,
                    FirstName = "Anna",
                    LastName = "Nielsen",
                    Orders = _orders.FindAll(o => o.OrderID%2 == 0)
                },
                new Employee()
                {
                    EmployeeID = 2,
                    FirstName = "Søren",
                    LastName = "Dahl",
                    Orders = _orders.FindAll(o => o.OrderID%2 == 1)
                }
            });

        }


        public void Dispose()
        {
            //Nothing
        }

        public List<Product> Products()
        {
            return _products;
        }

        public List<Category> Categories()
        {
            return _categories;
        }

        public List<Order> Orders()
        {
            return _orders;
        }

        public List<Order_Detail> OrderDetails()
        {
            return _orderDetails;
        }

        public List<Employee> Employees()
        {
            return _employees;
        }

        public List<Customer> Customers()
        {
            return _customers;
        }

        public Order CreateOrder(Order order)
        {
            int maxId;
            if (_orders.Count() != 0)
            {
                maxId = _orders.OrderByDescending(i => i.OrderID).FirstOrDefault().OrderID;
            }
            else
            {
                maxId = 0;
            }
            order.OrderID = maxId + 1;
            _orders.Add(order);
            return order;
        }

        public Report<List<OrdersByTotalPriceDto>, ReportError> TopOrdersByTotalPrice(int count)
        {
            var report = new Report<List<OrdersByTotalPriceDto>, ReportError>();
            try
            {
                var list = new List<OrdersByTotalPriceDto>();

                var topOrders =
                    _orders
                        .OrderByDescending(i => i.Order_Details.Sum(j => j.Quantity * j.UnitPrice))
                        .Take(count);
                foreach (var o in topOrders)
                {
                    var obt = new OrdersByTotalPriceDto
                    {
                        OrderId = o.OrderID,
                        OrderDate = o.OrderDate,
                        CustomerContactName = o.Customer.ContactName,
                        TotalPriceWithDiscount =
                            o.Order_Details.Sum(i => i.Quantity * (i.UnitPrice * (decimal)(1 - i.Discount))),
                        TotalPrice = o.Order_Details.Sum(i => i.Quantity * i.UnitPrice)
                    };
                    list.Add(obt);
                }
                report.Data = list;
                return report;
            }
            catch (Exception e)
            {
                report.Error = new ReportError() { Error = e.Message };
                return report;
            }
        }

        public Report<List<ProductsBySaleDto>, ReportError> TopProductsBySale(int count)
        {
            var report = new Report<List<ProductsBySaleDto>, ReportError>();
            try
            {
                var list = new List<ProductsBySaleDto>();

                var topProduct =
                    _products.OrderByDescending(i => i.Order_Details.Sum(j => j.Quantity)).Take(count);

                foreach (var p in topProduct)
                {
                    var pbs = new ProductsBySaleDto
                    {
                        ProductId = p.ProductID,
                        ProductName = p.ProductName,
                        UnitsSoldByMonth = new List<UnitsSoldByMonthDto>()
                    };

                    var upm = from od in p.Order_Details
                              group od by new { od.Order.OrderDate.Value.Year, od.Order.OrderDate.Value.Month };
                    upm = upm.OrderBy(i => i.Key.Year).ThenBy(i => i.Key.Month);

                    foreach (var g in upm)
                    {
                        var uspm = new UnitsSoldByMonthDto
                        {
                            Count = g.Count(),
                            Month = g.Key.Month,
                            Year = g.Key.Year,
                            UnitsSold = g.Sum(i => i.Quantity)
                        };
                        pbs.UnitsSoldByMonth.Add(uspm);
                    }

                    list.Add(pbs);
                }

                report.Data = list;
                return report;
            }
            catch (Exception e)
            {
                report.Error = new ReportError() { Error = e.Message };
                return report;
            }
        }

        public Report<EmployeeSaleDto, ReportError> EmployeeSale(int id)
        {
            var report = new Report<EmployeeSaleDto, ReportError>();
            try
            {
                var e = _employees.Single(i => i.EmployeeID == id);
                var esDto = new EmployeeSaleDto
                {
                    EmployeeName = e.FirstName + " " + e.LastName,
                    ReportsToId = e.ReportsTo,
                    Orders = new List<OrderListDto>()
                };
                foreach (var o in e.Orders)
                {
                    var olDto = new OrderListDto
                    {
                        OrderId = o.OrderID,
                        OrderDate = o.OrderDate,
                        TotalPrice = o.Order_Details.Sum(i => i.Quantity * i.UnitPrice),
                        Products = new List<ProductListDto>()
                    };
                    foreach (var od in o.Order_Details)
                    {
                        var plDto = new ProductListDto
                        {
                            ProductName = _products.Single(i => i.ProductID == od.ProductID).ProductName,
                            Quantity = od.Quantity,
                            UnitPrice = od.UnitPrice
                        };
                        olDto.Products.Add(plDto);
                    }
                    esDto.Orders.Add(olDto);
                }

                report.Data = esDto;
                return report;
            }
            catch (Exception e)
            {
                report.Error = new ReportError() { Error = e.Message };
                return report;
            }
        }
    }
}