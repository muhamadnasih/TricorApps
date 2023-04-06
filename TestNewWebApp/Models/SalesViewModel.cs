using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TestNewWebApp.Models
{
    public class SalesViewModel
    {
        [Display(Name = "Sales Item")]
        [Required(ErrorMessage = "Please insert sales item.")]
        public string SalesItem { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "You need to give us your first name.")]
        public DateTime SalesDate { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "please insrt amount of sales.")]
        public decimal Amount { get; set; }

      


    }
}
