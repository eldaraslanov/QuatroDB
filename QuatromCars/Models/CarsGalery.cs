namespace QuatromCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarsGalery")]
    public partial class CarsGalery
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Header { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(800)]
        public string Photo { get; set; }
    }
}
