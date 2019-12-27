namespace QuatromCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Produc_to_AvtoTechizat
    {
        public int id { get; set; }

        public int? productId { get; set; }

        public int? AvtoTechizat { get; set; }

        public virtual Avtotechizat Avtotechizat1 { get; set; }

        public virtual Product Product { get; set; }
    }
}
