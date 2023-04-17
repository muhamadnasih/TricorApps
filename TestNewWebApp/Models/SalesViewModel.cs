using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TestNewWebApp.Models
{
    public class SalesViewModel
    {
        public int SalesId { get; set; }
        [Display(Name = "Sales Item")]
        [Required(ErrorMessage = "Please insert sales item.")]
        public string SalesItem { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Please insert SalesDate.")]
        public DateTime SalesDate { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Please insert amount of sales.")]
        public decimal Amount { get; set; }

      


    }
}
