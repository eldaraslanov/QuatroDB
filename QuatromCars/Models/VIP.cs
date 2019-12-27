namespace QuatromCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIP")]
    public partial class VIP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VIP()
        {
            AvtoParths = new HashSet<AvtoParth>();
            Products = new HashSet<Product>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public double? Price { get; set; }

        public int? Amount { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime? StartDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AvtoParth> AvtoParths { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
