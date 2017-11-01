﻿using System.ComponentModel.DataAnnotations;

namespace SecurityTraining.Models
{
    public class AddOrderViewModel
    {
        [Required]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Klant")]
        public Customer Customer { get; set; }
    }
}