namespace QuatromCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_to_CellNumber
    {
        public int Id { get; set; }

        public int? CellnumberId { get; set; }

        public int? UserId { get; set; }

        public virtual CellNumber CellNumber { get; set; }

        public virtual User User { get; set; }
    }
}
