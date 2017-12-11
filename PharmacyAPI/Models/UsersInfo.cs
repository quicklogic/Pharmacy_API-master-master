namespace PharmacyAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsersInfo")]
    public partial class UsersInfo
    {
        [Key]
        [StringLength(100)]
        public string login { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string SecondName { get; set; }

        [StringLength(100)]
        public string Patronomyc { get; set; }

        [Required]
        [StringLength(11)]
        public string number { get; set; }

        [Required]
        [StringLength(100)]
        public string mail { get; set; }

        [Required]
        [StringLength(100)]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime BornDate { get; set; }

        public decimal OrdersPrice { get; set; }

        public virtual User User { get; set; }
    }
}
