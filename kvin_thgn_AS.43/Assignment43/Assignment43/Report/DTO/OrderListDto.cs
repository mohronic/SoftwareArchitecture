using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment43.Report.DTO
{
    /// <summary>
    /// DTO containing information about an order, used in the EmployeeSaleDTO
    /// </summary>
    public class OrderListDto
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ProductListDto> Products { get; set; }
    }
}
