namespace QuatromCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CellNumber")]
    public partial class CellNumber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CellNumber()
        {
            User_to_CellNumber = new HashSet<User_to_CellNumber>();
        }

        public int Id { get; set; }

        [StringLength(3)]
        public string PhoneType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_to_CellNumber> User_to_CellNumber { get; set; }
    }
}
