namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SlideShow")]
    public partial class SlideShow
    {
        public int Id { get; set; }

        public int? TypeId { get; set; }

        [StringLength(100)]
        public string Img { get; set; }

        public virtual ComType ComType { get; set; }
    }
}
