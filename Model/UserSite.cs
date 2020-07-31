namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserSite")]
    public partial class UserSite
    {
        public int Id { get; set; }

        public int? QuXianId { get; set; }

        [StringLength(20)]
        public string SitePhone { get; set; }

        public int? UserId { get; set; }

        [StringLength(100)]
        public string SiteDetail { get; set; }

        public int? SitePre { get; set; }

        [StringLength(100)]
        public string SiteProName { get; set; }

        public virtual QuXian QuXian { get; set; }

        public virtual User User { get; set; }
    }
}
