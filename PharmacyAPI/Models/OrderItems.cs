using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmacyAPI.Models
{
    public class OrderItems
    { 

        public int ID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }
    }
}