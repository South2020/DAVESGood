namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Com")]
    public partial class Com
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Com()
        {
            ComImg1 = new HashSet<ComImg>();
            Comment = new HashSet<Comment>();
            Orders = new HashSet<Orders>();
            ShopCar = new HashSet<ShopCar>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string ComName { get; set; }

        public double? ComMoney { get; set; }

        [StringLength(50)]
        public string ComBz { get; set; }

        [StringLength(50)]
        public string ComWeight { get; set; }

        public int? ComTypeId { get; set; }

        public int? ComInventNum { get; set; }

        public int? ComStatic { get; set; }

        [StringLength(50)]
        public string ComImg { get; set; }

        public int? ComUnitId { get; set; }

        public virtual ComType ComType { get; set; }

        public virtual ComUnit ComUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComImg> ComImg1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopCar> ShopCar { get; set; }
    }
}
