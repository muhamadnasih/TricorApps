using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class MonthlySalesReportDomainModel
    {
        public string? UserId { get; set; }
        public int SalesYear { get; set; }
        public int SalesMonth { get; set; }
        public decimal TotalSales { get; set; }


    }
}
