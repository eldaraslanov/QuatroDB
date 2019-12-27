namespace QuatromCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Produc_to_AvtoTechizat = new HashSet<Produc_to_AvtoTechizat>();
            Product_To_Image = new HashSet<Product_To_Image>();
            Supply_To_Products = new HashSet<Supply_To_Products>();
        }

        public int id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(800)]
        public string Photo { get; set; }

        public int? PriceTypeId { get; set; }

        public double? Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool? NewOrOld { get; set; }

        public bool? Published { get; set; }

        public bool? IsActive { get; set; }

        public int? VIPid { get; set; }

        public int? CategoryID { get; set; }

        public int? CityID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProductionDate { get; set; }

        public DateTime? PrublishDate { get; set; }

        public int? ProductTypeID { get; set; }

        public int? ModelId { get; set; }

        public int? PinNumber { get; set; }

        public bool? IsCredit { get; set; }

        public bool? isBarter { get; set; }

        public int? MotorCapacityId { get; set; }

        public int? HorsePower { get; set; }

        public int? FuelId { get; set; }

        public int? ColorId { get; set; }

        public virtual Category Category { get; set; }

        public virtual City City { get; set; }

        public virtual FuelType FuelType { get; set; }

        public virtual Model Model { get; set; }

        public virtual MotorsCapacity MotorsCapacity { get; set; }

        public virtual PriceType PriceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produc_to_AvtoTechizat> Produc_to_AvtoTechizat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_To_Image> Product_To_Image { get; set; }

        public virtual ProductColor ProductColor { get; set; }

        public virtual Transmission Transmission { get; set; }

        public virtual VIP VIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supply_To_Products> Supply_To_Products { get; set; }
    }
}
