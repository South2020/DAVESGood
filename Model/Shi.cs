namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shi")]
    public partial class Shi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shi()
        {
            QuXian = new HashSet<QuXian>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? ShengId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuXian> QuXian { get; set; }

        public virtual Sheng Sheng { get; set; }
    }
}
