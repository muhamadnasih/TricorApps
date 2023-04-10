using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class SalesDomainModel
    {
        public int Id { get; set; }
        public string SalesItem { get; set; }
        public DateTime SalesDate { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime UpdateDate { get; set; }


    }
}
