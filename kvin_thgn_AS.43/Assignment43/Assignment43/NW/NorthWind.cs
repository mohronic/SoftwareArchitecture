using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment43.Entities;
using Assignment43.Report;
using Assignment43.Report.DTO;

namespace Assignment43.NW
{
    public class NorthWind
    {
         public List<Product> Products { get { return _repository.Products(); } }
        public List<Order> Orders { get { return _repository.Orders(); } }

        private readonly IRepository _repository;
        private ReportCreater _reportCreater;

        public event EventHandler<NewOrderEventArgs> NewOrderEvent;

        /// <summary>
        /// Creates a NorthWindClient using the given repository
        /// </summary>
        /// <param name="repository"></param>
        public NorthWind(IRepository repository)
        {
            _repository = repository;
            _reportCreater = new ReportCreater(repository);
        }

        /// <summary>
        /// Creates and add a new order from the given params and send it to the repository
        /// </summary>
        /// <param name="required"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="region"></param>
        /// <param name="postal"></param>
        /// <param name="country"></param>
        public Order AddOrder(DateTime? required, string name, string address, string city, string region, string postal, string country)
        {
            var o = new Order
            {
                OrderDate = DateTime.Now,
                RequiredDate = required,
                ShipName = name,
                ShipAddress = address,
                ShipCity = city,
                ShipRegion = region,
                ShipPostalCode = postal,
                ShipCountry = country
            };
            var order =_repository.CreateOrder(o);
            var e = new NewOrderEventArgs { Order = o };
            if (NewOrderEvent != null) NewOrderEvent(this, e);
            return order;
        }

        /// <summary>
        /// Returns a report of the top Orders by total price
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Report<List<OrdersByTotalPriceDto>, ReportError> TopOrdersByTotalPrice(int count)
        {
            return _reportCreater.TopOrdersByTotalPrice(count);
        }

        /// <summary>
        /// Returns a report of the top products by sales
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Report<List<ProductsBySaleDto>, ReportError> TopProductsBySale(int count)
        {
            return _reportCreater.TopProductsBySale(count);
        }

        /// <summary>
        /// Returns a report of the Employee and the employees orders
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Report<EmployeeSaleDto, ReportError> EmployeeSale(int id)
        {
            return _reportCreater.EmployeeSale(id);
        }
    }
}
