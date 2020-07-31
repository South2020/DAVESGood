namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sys_Admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sys_Admin()
        {
            DOCFS = new HashSet<DOCFS>();
            Sys_BackLoginRecord = new HashSet<Sys_BackLoginRecord>();
            Sys_Jurisd = new HashSet<Sys_Jurisd>();
        }

        [StringLength(50)]
        public string AdminAcc { get; set; }

        public int Id { get; set; }

        [StringLength(50)]
        public string AdminPwd { get; set; }

        [StringLength(50)]
        public string AdminName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCFS> DOCFS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sys_BackLoginRecord> Sys_BackLoginRecord { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sys_Jurisd> Sys_Jurisd { get; set; }
    }
}
