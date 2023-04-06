using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TastApp.Models
{
    public class TodoViewModel
    {
        [Required]
        [Display(Name = "Task")]
        public string Task { get; set; }
        [Required]
        [Display(Name = "Assign To")]
        public int AssignedToId { get; set; }

    }
}