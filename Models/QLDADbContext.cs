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

        public virtual DbSet<DeTai> DeTais { get; set; }
        public virtual DbSet<GiangVienHuongDanTheoKy> GiangVienHuongDanTheoKys { get; set; }
        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<HocKy> HocKys { get; set; }
        public virtual DbSet<HoiDongDanhGiaKQ> HoiDongDanhGiaKQs { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<PhanBien> PhanBiens { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
