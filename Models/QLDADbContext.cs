using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyDoAn.Models
{
    public partial class QLDADbContext : DbContext
    {
        public QLDADbContext()
            : base("name=QLDADbContext")
        {
        }
        public virtual DbSet<ChiTietHoiDong> ChiTietHoiDongs { get; set; }
        public virtual DbSet<DeTai> DeTais { get; set; }
        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<HocKy> HocKys { get; set; }
        public virtual DbSet<HoiDongDanhGiaKQ> HoiDongDanhGiaKQs { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<PhanBien> PhanBiens { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<GiangVienHdSinhVien> GiangVienHdSinhViens { get; set; }
        public virtual DbSet<PhanBienDeTai> PhanBienDeTais { get; set; }
        public virtual DbSet<KetQua> KetQuas { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<LoaiMonHoc> LoaiMonHocs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
