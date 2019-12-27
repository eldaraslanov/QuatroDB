namespace QuatromCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AvtoParth")]
    public partial class AvtoParth
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AvtoParth()
        {
            Product_To_Image = new HashSet<Product_To_Image>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? ParthCategoryID { get; set; }

        [StringLength(800)]
        public string Photo { get; set; }

        public double? Price { get; set; }

        public int? PriceTypeId { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool? NewOrOld { get; set; }

        public int? VipID { get; set; }

        public int? CityID { get; set; }

        public DateTime? PublishDatte { get; set; }

        public virtual Category Category { get; set; }

        public virtual City City { get; set; }

        public virtual PriceType PriceType { get; set; }

        public virtual VIP VIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_To_Image> Product_To_Image { get; set; }
    }
}
