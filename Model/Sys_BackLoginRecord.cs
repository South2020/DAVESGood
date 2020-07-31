namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sys_BackLoginRecord
    {
        public int Id { get; set; }

        public int? BLRAdminId { get; set; }

        public DateTime? BLRTime { get; set; }

        public virtual Sys_Admin Sys_Admin { get; set; }
    }
}
