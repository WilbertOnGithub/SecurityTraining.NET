using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SecurityTraining.Models
{
    public class AddOrderForSalesViewModel
    {
        [Required]
        [Display(Name = "Naam")]
        public string Name { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string CustomerId { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }
    }
}