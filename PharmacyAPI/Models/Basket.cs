namespace PharmacyAPI.Models
{
using System;
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
using System.Web;


    public class Basket
    {
        public int ID { get; set; }


        [Required]
        public int ProductID { get; set; }


        [Required]
        [StringLength(100)]
        public string login { get; set; }


        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}