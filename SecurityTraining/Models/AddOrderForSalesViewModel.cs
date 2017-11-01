using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecurityTraining.Models
{
    public class AddOrderForSalesViewModel
    {
        [Required]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Klant")]
        public Customer Customer { get; set; }

        public IList<Customer> Customers { get; set; }
    }
}