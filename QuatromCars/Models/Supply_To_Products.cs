namespace QuatromCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supply_To_Products
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? CarSupplyId { get; set; }

        public int? ProductId { get; set; }

        public virtual CarSupply CarSupply { get; set; }

        public virtual Product Product { get; set; }
    }
}
