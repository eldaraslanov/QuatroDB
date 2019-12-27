namespace QuatromCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SliderTop")]
    public partial class SliderTop
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string Header { get; set; }

        [StringLength(60)]
        public string Descriptions { get; set; }

        [StringLength(100)]
        public string SubDescriptions { get; set; }

        [StringLength(700)]
        public string SliderPhoto { get; set; }
    }
}
