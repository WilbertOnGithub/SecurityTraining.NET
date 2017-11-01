using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityTraining.Models
{
    [Table("Order")]
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IList<Product> Products { get; set; }

        public virtual Customer Customer { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
    }
}