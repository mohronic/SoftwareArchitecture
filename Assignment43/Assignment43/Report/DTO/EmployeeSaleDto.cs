using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment43.Report.DTO
{
    /// <summary>
    /// DTO used for the EmployeeSale report
    /// </summary>
    public class EmployeeSaleDto
    {
        public string EmployeeName { get; set; }
        public int? ReportsToId { get; set; }
        public List<OrderListDto> Orders { get; set; }
    }
}
