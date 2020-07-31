namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        [StringLength(500)]
        public string CommentCont { get; set; }

        public int? CommentLev { get; set; }

        public DateTime? CommentTime { get; set; }

        public int? ComId { get; set; }

        public virtual Com Com { get; set; }

        public virtual User User { get; set; }
    }
}
