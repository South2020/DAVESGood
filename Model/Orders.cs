namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        public int Id { get; set; }

        public int? ComId { get; set; }

        public int? OrderId { get; set; }

        public double? Money { get; set; }

        public double? ZWeight { get; set; }

        public int? Num { get; set; }

        public double? Weight { get; set; }

        public virtual Com Com { get; set; }

        public virtual Order Order { get; set; }
    }
}
