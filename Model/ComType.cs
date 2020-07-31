namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComType")]
    public partial class ComType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComType()
        {
            Com = new HashSet<Com>();
            ComType1 = new HashSet<ComType>();
            SlideShow = new HashSet<SlideShow>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string ComTypeName { get; set; }

        [StringLength(50)]
        public string ComTypeUrl { get; set; }

        public int? ComTypeParId { get; set; }

        [StringLength(50)]
        public string ComTypeImg { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Com> Com { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComType> ComType1 { get; set; }

        public virtual ComType ComType2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SlideShow> SlideShow { get; set; }
    }
}
