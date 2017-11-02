using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SecurityTraining.Models
{
    [Table("Order")]
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public string Name { get; set; }

        public Decimal TotalAmount()
        {
            return Products.Sum(product => product.Price * product.Number);
        }
        
        public virtual IList<Product> Products { get; set; }

        public virtual Customer Customer { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
    }
}