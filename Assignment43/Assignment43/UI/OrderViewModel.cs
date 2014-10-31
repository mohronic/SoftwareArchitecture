using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Assignment43.Annotations;
using Assignment43.DB;
using Assignment43.Entities;
using Assignment43.NW;

namespace Assignment43.UI
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        private NorthWind _nw;
        private IList<Order> _orders;
        private Order _order;
        private IList<Order_Detail> _orderDetails;
        private string _employeeName;
        private string _customerName;
        private decimal _totalPrice;

        public OrderViewModel(NorthWind nw)
        {
            _nw = nw;
            _orders = _nw.Orders;
        }

        /// <summary>
        /// Setter and getter for the total price of the selected order.
        /// </summary>
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                if (!value.Equals(_totalPrice))
                {
                    _totalPrice = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Setter and getter for employee name of the selected order.
        /// </summary>
        public string EmployeeName
        {
            get { return _employeeName; }
            set
            {
                if (!value.Equals(_employeeName))
                {
                    _employeeName = value;
                    OnPropertyChanged();
                }
            }
            
        }

        /// <summary>
        /// Setter and getter for the customer name of the seleted order.
        /// </summary>
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (!value.Equals(_customerName))
                {
                    _customerName = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Setter and getter for the order details of the selected order.
        /// </summary>
        public IList<Order_Detail> OrderDetails
        {
            get { return _orderDetails; }
            set
            {
                if (!value.Equals(_orderDetails))
                {
                    _orderDetails = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Setter and getter for the list of all orders.
        /// </summary>
        public IList<Order> Orders
        {
            get { return _orders; }
            set
            {
                if (!value.Equals(_orders))
                {
                    _orders = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Setter and getter for the selected order.
        /// </summary>
        public Order Order
        {
            get { return _order; }
            set
            {
                if (!value.Equals(_order))
                {
                    _order = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Event used to notify views when a value is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
