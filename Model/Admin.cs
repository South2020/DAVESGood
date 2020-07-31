namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [StringLength(50)]
        public string AdminAcc { get; set; }

        public int Id { get; set; }

        [StringLength(50)]
        public string AdminPwd { get; set; }

        public int? AdminQx { get; set; }
    }
}
