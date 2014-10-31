using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment43.Report.DTO
{
    /// <summary>
    /// DTO used in the ProductsBySaleDTO, containing information about the amount of sales in a month
    /// </summary>
    public class UnitsSoldByMonthDto
    {
        public int UnitsSold { get; set; }
        public int Count { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
