namespace QuatromCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Avtotechizat")]
    public partial class Avtotechizat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Avtotechizat()
        {
            Produc_to_AvtoTechizat = new HashSet<Produc_to_AvtoTechizat>();
        }

        public int id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produc_to_AvtoTechizat> Produc_to_AvtoTechizat { get; set; }
    }
}
