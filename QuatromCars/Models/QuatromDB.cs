namespace QuatromCars.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuatromDB : DbContext
    {
        public QuatromDB()
            : base("name=QuatromDB")
        {
        }

        public virtual DbSet<AvtoParth> AvtoParths { get; set; }
        public virtual DbSet<Avtotechizat> Avtotechizats { get; set; }
        public virtual DbSet<Brend> Brends { get; set; }
        public virtual DbSet<CarsGalery> CarsGaleries { get; set; }
        public virtual DbSet<CarSupply> CarSupplies { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CellNumber> CellNumbers { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<FuelType> FuelTypes { get; set; }
        public virtual DbSet<Marka> Markas { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<MotorsCapacity> MotorsCapacities { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<PriceType> PriceTypes { get; set; }
        public virtual DbSet<Produc_to_AvtoTechizat> Produc_to_AvtoTechizat { get; set; }
        public virtual DbSet<Product_To_Image> Product_To_Image { get; set; }
        public virtual DbSet<ProductColor> ProductColors { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SliderTop> SliderTops { get; set; }
        public virtual DbSet<Supply_To_Products> Supply_To_Products { get; set; }
        public virtual DbSet<Transmission> Transmissions { get; set; }
        public virtual DbSet<User_to_CellNumber> User_to_CellNumber { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VIP> VIPs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvtoParth>()
                .HasMany(e => e.Product_To_Image)
                .WithOptional(e => e.AvtoParth)
                .HasForeignKey(e => e.AvtoPartPhotoID);

            modelBuilder.Entity<Avtotechizat>()
                .HasMany(e => e.Produc_to_AvtoTechizat)
                .WithOptional(e => e.Avtotechizat1)
                .HasForeignKey(e => e.AvtoTechizat);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.AvtoParths)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.ParthCategoryID);

            modelBuilder.Entity<FuelType>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.FuelType)
                .HasForeignKey(e => e.FuelId);

            modelBuilder.Entity<MotorsCapacity>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.MotorsCapacity)
                .HasForeignKey(e => e.MotorCapacityId);

            modelBuilder.Entity<ProductColor>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductColor)
                .HasForeignKey(e => e.ColorId);

            modelBuilder.Entity<Transmission>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Transmission)
                .HasForeignKey(e => e.ProductTypeID);
        }
    }
}
