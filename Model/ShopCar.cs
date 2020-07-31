namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShopCar")]
    public partial class ShopCar
    {
        public int Id { get; set; }

        public int? ComId { get; set; }

        public int? UserId { get; set; }

        public int? CarNum { get; set; }

        public virtual Com Com { get; set; }

        public virtual User User { get; set; }
    }
}
