namespace QuatromCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            User_to_CellNumber = new HashSet<User_to_CellNumber>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? RegisterDate { get; set; }

        public int? CellId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_to_CellNumber> User_to_CellNumber { get; set; }
    }
}
