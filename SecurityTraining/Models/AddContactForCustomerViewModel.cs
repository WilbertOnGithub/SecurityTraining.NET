using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SecurityTraining.Models
{
    public class AddContactForCustomerViewModel
    {
        [Required]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        public string CustomerId { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }
    }
}