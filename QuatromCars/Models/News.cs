namespace QuatromCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        [StringLength(500)]
        public string SubDescription { get; set; }

        [StringLength(800)]
        public string NewPhoto { get; set; }
    }
}
