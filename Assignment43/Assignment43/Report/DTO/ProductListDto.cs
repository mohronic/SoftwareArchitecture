using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment43.Report.DTO
{
    /// <summary>
    /// DTO cotaining information about how much of a product has been bought. Used in the OrderListDTO
    /// </summary>
    public class ProductListDto
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
