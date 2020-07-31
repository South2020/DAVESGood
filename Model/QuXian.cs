namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuXian")]
    public partial class QuXian
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuXian()
        {
            UserSite = new HashSet<UserSite>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? ShiId { get; set; }

        public virtual Shi Shi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSite> UserSite { get; set; }
    }
}
