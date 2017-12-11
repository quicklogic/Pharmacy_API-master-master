namespace PharmacyAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PharmacyAPI.Models;

    public partial class Pharmacy : DbContext
    {
        public Pharmacy()
            : base("name=Pharmacy")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Availability> Availabilities { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Recipy> Recipies { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersInfo> UsersInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Availability>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Availability1)
                .HasForeignKey(e => e.AvailabilityID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category1)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeliveryMethod>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.DeliveryMethod)
                .HasForeignKey(e => e.Delivery)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.Discount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Recipies)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Orders)
                .Map(m => m.ToTable("ProductOrders").MapLeftKey("OrderID").MapRightKey("ProductID"));

            modelBuilder.Entity<PaymentMethod>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.PaymentMethod)
                .HasForeignKey(e => e.Payment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producer>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Producer1)
                .HasForeignKey(e => e.ProducerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
               .Property(e => e.ImageURI)
               .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Total)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Recipies)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Baskets)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
               .HasMany(e => e.OrderItems)
               .WithRequired(e => e.Product)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
               .HasMany(e => e.OrderItems)
               .WithRequired(e => e.Order)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Recipy>()
                .Property(e => e.RecipeImageURL)
                .IsFixedLength();

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Status1)
                .HasForeignKey(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Type1)
                .HasForeignKey(e => e.TypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Recipies)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Baskets)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.UsersInfo)
                .WithRequired(e => e.User);

            modelBuilder.Entity<UsersInfo>()
                .Property(e => e.OrdersPrice)
                .HasPrecision(18, 0);
        }
    }
}
