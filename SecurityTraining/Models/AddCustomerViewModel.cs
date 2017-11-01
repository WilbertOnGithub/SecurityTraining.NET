using System.ComponentModel.DataAnnotations;

namespace SecurityTraining.Models
{
    public class AddCustomerViewModel
    {
        [Required]
        [Display(Name = "Naam")]
        public string Name { get; set; }
    }
}