using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment43.Report.DTO
{
    /// <summary>
    /// DTO used for the OrdersByTotalPrice report.
    /// </summary>
    public class OrdersByTotalPriceDto
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CustomerContactName { get; set; }
        public decimal TotalPriceWithDiscount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
