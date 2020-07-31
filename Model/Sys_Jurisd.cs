namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sys_Jurisd
    {
        public int? AdminId { get; set; }

        public int? MenuId { get; set; }

        public int Id { get; set; }

        public virtual Sys_Admin Sys_Admin { get; set; }

        public virtual Sys_Menu Sys_Menu { get; set; }
    }
}
