namespace QuatromCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_To_Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(800)]
        public string Photo { get; set; }

        public int? ProductId { get; set; }

        public int? AvtoPartPhotoID { get; set; }

        public virtual AvtoParth AvtoParth { get; set; }

        public virtual Product Product { get; set; }
    }
}
