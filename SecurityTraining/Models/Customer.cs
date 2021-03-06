﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SecurityTraining.Models
{
    [Table("Customer")]
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<Order> Orders { get; set; }

        [ForeignKey("SalesPerson")]
        public string SalesPersonId { get; set; }

        public virtual ApplicationUser SalesPerson { get; set; }

        public virtual IList<ApplicationUser> Contacts { get; set; }
    }
}