namespace PharmacyAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Recipy
    {
        public int ID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        [Required]
        [StringLength(10)]
        public string RecipeImageURL { get; set; }

        [Required]
        [StringLength(100)]
        public string login { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
