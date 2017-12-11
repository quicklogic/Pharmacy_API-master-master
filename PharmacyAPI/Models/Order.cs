namespace PharmacyAPI
{
    using PharmacyAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Recipies = new HashSet<Recipy>();
            Products = new HashSet<Product>();
            OrderItems = new HashSet<OrderItems>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Login { get; set; }

        public int Status { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalPrice { get; set; }

        public int Delivery { get; set; }

        public int Payment { get; set; }

        [StringLength(500)]
        public string Commentary { get; set; }

        public virtual DeliveryMethod DeliveryMethod { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual Status Status1 { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recipy> Recipies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
