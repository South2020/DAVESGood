namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DAVES : DbContext
    {
        public DAVES()
            : base("name=DAVES")
        {
        }

        public virtual DbSet<Com> Com { get; set; }
        public virtual DbSet<ComImg> ComImg { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<ComType> ComType { get; set; }
        public virtual DbSet<ComUnit> ComUnit { get; set; }
        public virtual DbSet<DOCFS> DOCFS { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<QuXian> QuXian { get; set; }
        public virtual DbSet<Sheng> Sheng { get; set; }
        public virtual DbSet<Shi> Shi { get; set; }
        public virtual DbSet<ShopCar> ShopCar { get; set; }
        public virtual DbSet<SlideShow> SlideShow { get; set; }
        public virtual DbSet<Sys_Admin> Sys_Admin { get; set; }
        public virtual DbSet<Sys_BackLoginRecord> Sys_BackLoginRecord { get; set; }
        public virtual DbSet<Sys_Jurisd> Sys_Jurisd { get; set; }
        public virtual DbSet<Sys_Menu> Sys_Menu { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserSite> UserSite { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComType>()
                .HasMany(e => e.ComType1)
                .WithOptional(e => e.ComType2)
                .HasForeignKey(e => e.ComTypeParId);

            modelBuilder.Entity<ComType>()
                .HasMany(e => e.SlideShow)
                .WithOptional(e => e.ComType)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<Sys_Admin>()
                .HasMany(e => e.Sys_BackLoginRecord)
                .WithOptional(e => e.Sys_Admin)
                .HasForeignKey(e => e.BLRAdminId);

            modelBuilder.Entity<Sys_Admin>()
                .HasMany(e => e.Sys_Jurisd)
                .WithOptional(e => e.Sys_Admin)
                .HasForeignKey(e => e.AdminId);

            modelBuilder.Entity<Sys_Menu>()
                .HasMany(e => e.Sys_Jurisd)
                .WithOptional(e => e.Sys_Menu)
                .HasForeignKey(e => e.MenuId);

            modelBuilder.Entity<Sys_Menu>()
                .HasMany(e => e.Sys_Menu1)
                .WithOptional(e => e.Sys_Menu2)
                .HasForeignKey(e => e.MenuParId);
        }
    }
}
