namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComImg")]
    public partial class ComImg
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string ImgName { get; set; }

        public int? ComId { get; set; }

        public virtual Com Com { get; set; }
    }
}
