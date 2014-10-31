using System;
using Assignment43.Entities;

namespace Assignment43.NW
{
    /// <summary>
    /// A event containing a Order, this is used when a new Order is created through the northwind client
    /// </summary>
    public class NewOrderEventArgs : EventArgs
    {
        public Order Order { get; set; }
    }
}
