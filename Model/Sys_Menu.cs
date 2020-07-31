namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sys_Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sys_Menu()
        {
            Sys_Jurisd = new HashSet<Sys_Jurisd>();
            Sys_Menu1 = new HashSet<Sys_Menu>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string MenuName { get; set; }

        [StringLength(50)]
        public string MenuUrl { get; set; }

        public int? MenuParId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sys_Jurisd> Sys_Jurisd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sys_Menu> Sys_Menu1 { get; set; }

        public virtual Sys_Menu Sys_Menu2 { get; set; }
    }
}
