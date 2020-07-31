namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DOCFS
    {
        public int Id { get; set; }

        public string Coms { get; set; }

        public int? Sys_AdminId { get; set; }

        public DateTime? DOCFStime { get; set; }

        public virtual Sys_Admin Sys_Admin { get; set; }
    }
}
