namespace QuatromCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Brend
    {
        public int Id { get; set; }

        [StringLength(800)]
        public string BrendPhoto { get; set; }
    }
}
