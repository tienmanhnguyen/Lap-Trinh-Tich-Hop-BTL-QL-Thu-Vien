namespace DemoWebService.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BanDoc> BanDocs { get; set; }
        public virtual DbSet<ChiTietMuon> ChiTietMuons { get; set; }
        public virtual DbSet<ChuDe> ChuDes { get; set; }
        public virtual DbSet<CuonSach> CuonSaches { get; set; }
        public virtual DbSet<DauSach> DauSaches { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<PhieuMuon> PhieuMuons { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength();

            modelBuilder.Entity<BanDoc>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength();

            modelBuilder.Entity<BanDoc>()
                .HasMany(e => e.PhieuMuons)
                .WithOptional(e => e.BanDoc)
                .HasForeignKey(e => e.Id_BanDoc);

            modelBuilder.Entity<ChuDe>()
                .HasMany(e => e.DauSaches)
                .WithMany(e => e.ChuDes)
                .Map(m => m.ToTable("ChuDe_DauSach").MapLeftKey("Id_ChuDe").MapRightKey("Id_DauSach"));

            modelBuilder.Entity<CuonSach>()
                .Property(e => e.SoDanhNhan)
                .IsFixedLength();

            modelBuilder.Entity<CuonSach>()
                .HasMany(e => e.ChiTietMuons)
                .WithRequired(e => e.CuonSach)
                .HasForeignKey(e => e.Id_CuonSach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DauSach>()
                .Property(e => e.ISBN)
                .IsFixedLength();

            modelBuilder.Entity<DauSach>()
                .Property(e => e.NamXuatBan)
                .IsFixedLength();

            modelBuilder.Entity<DauSach>()
                .Property(e => e.KichThuoc)
                .IsFixedLength();

            modelBuilder.Entity<DauSach>()
                .Property(e => e.NgonNgu)
                .IsFixedLength();

            modelBuilder.Entity<DauSach>()
                .HasMany(e => e.CuonSaches)
                .WithOptional(e => e.DauSach)
                .HasForeignKey(e => e.Id_DauSach);

            modelBuilder.Entity<DauSach>()
                .HasMany(e => e.TacGias)
                .WithMany(e => e.DauSaches)
                .Map(m => m.ToTable("TacGia_DauSach").MapLeftKey("Id_DauSach").MapRightKey("Id_TacGia"));

            modelBuilder.Entity<NhaXuatBan>()
                .HasMany(e => e.DauSaches)
                .WithOptional(e => e.NhaXuatBan)
                .HasForeignKey(e => e.Id_NhaXuatBan);

            modelBuilder.Entity<PhieuMuon>()
                .HasMany(e => e.ChiTietMuons)
                .WithRequired(e => e.PhieuMuon)
                .HasForeignKey(e => e.Id_PhieuMuon)
                .WillCascadeOnDelete(false);
        }
    }
}
