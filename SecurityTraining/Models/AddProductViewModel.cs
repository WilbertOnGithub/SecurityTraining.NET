using System.ComponentModel.DataAnnotations;

namespace SecurityTraining.Models
{
    public class AddProductViewModel
    {
        [Required]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        public Order Order { get; set; }
    }
}