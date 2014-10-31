using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment43.NW;
using Assignment43.Report.DTO;

namespace Assignment43.Report
{
    class ReportCreater
    {
        private readonly IRepository _rep;
        public ReportCreater(IRepository rep)
        {
            _rep = rep;
        }

        /// <summary>
        /// Creates an report of the top count orders by total price.
        /// If it fails a ReportError will instead be returned.
        /// The returned value is hidden in a Report object.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Report<List<OrdersByTotalPriceDto>, ReportError> TopOrdersByTotalPrice(int count)
        {
            var report = new Report<List<OrdersByTotalPriceDto>, ReportError>();
            try
            {
                var list = new List<OrdersByTotalPriceDto>();

                var topOrders =
                    _rep.Orders().OrderByDescending(i => i.Order_Details.Sum(j => j.Quantity * j.UnitPrice)).Take(count);
                foreach (var o in topOrders)
                {
                    var obt = new OrdersByTotalPriceDto
                    {
                        OrderId = o.OrderID,
                        OrderDate = o.OrderDate,
                        CustomerContactName = o.Customer.ContactName,
                        TotalPriceWithDiscount = o.Order_Details.Sum(i => i.Quantity * i.UnitPrice * (decimal)(1 - i.Discount)),
                        TotalPrice = o.Order_Details.Sum(i => i.Quantity * i.UnitPrice)
                    };
                    list.Add(obt);
                }
                report.Data = list;
                return report;
            }
            catch (Exception e)
            {
                report.Error = new ReportError() { Error = e.Message + e.StackTrace };
                return report;
            }
        }

        /// <summary>
        /// Creates an report of the top count products by sales.
        /// If it fails a ReportError will instead be returned.
        /// The returned value is hidden in a Report object.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Report<List<ProductsBySaleDto>, ReportError> TopProductsBySale(int count)
        {
            var report = new Report<List<ProductsBySaleDto>, ReportError>();
            try
            {
                var list = new List<ProductsBySaleDto>();

                var topProduct = _rep.Products().OrderByDescending(i => i.Order_Details.Sum(j => j.Quantity)).Take(count);

                foreach (var p in topProduct)
                {
                    var pbs = new ProductsBySaleDto
                    {
                        ProductId = p.ProductID,
                        ProductName = p.ProductName,
                        UnitsSoldByMonth = new List<UnitsSoldByMonthDto>()
                    };

                    var upm = from od in p.Order_Details group od by new { od.Order.OrderDate.Value.Year, od.Order.OrderDate.Value.Month };
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
                report.Error = new ReportError { Error = e.Message + e.StackTrace };
                return report;
            }
        }

        /// <summary>
        /// Creates an report of employee with the given id, about which orders
        /// he has placed.
        /// If it fails a ReportError will instead be returned.
        /// The returned value is hidden in a Report object.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Report<EmployeeSaleDto, ReportError> EmployeeSale(int id)
        {
            var report = new Report<EmployeeSaleDto, ReportError>();
            try
            {
                var e = _rep.Employees().Single(i => i.EmployeeID == id);
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
                            ProductName = _rep.Products().Single(i => i.ProductID == od.ProductID).ProductName,
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
                report.Error = new ReportError { Error = e.Message + e.StackTrace };
                return report;
            }
        }
    }
}
