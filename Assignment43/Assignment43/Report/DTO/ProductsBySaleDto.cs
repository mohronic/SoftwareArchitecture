using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment43.Report.DTO
{
    /// <summary>
    /// DTO with the information of the ProductsBySale report.
    /// </summary>
    public class ProductsBySaleDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<UnitsSoldByMonthDto> UnitsSoldByMonth { get; set; }
    }
}
