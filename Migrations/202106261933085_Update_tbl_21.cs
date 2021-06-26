namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DeTais", "MaDeTai", c => c.String(maxLength: 50));
            AlterColumn("dbo.DeTais", "TenDeTai", c => c.String(maxLength: 50));
            AlterColumn("dbo.DeTais", "MaMonHoc", c => c.String(maxLength: 50));
            AlterColumn("dbo.DeTais", "MaSinhVien", c => c.String(maxLength: 50));
            AlterColumn("dbo.DeTais", "MaGiangVien", c => c.String(maxLength: 50));
            AlterColumn("dbo.DeTais", "MaHoiDong", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiangVienHdSinhViens", "MaGiangVien", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiangVienHdSinhViens", "TenGiangVien", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiangVienHdSinhViens", "MaSinhVien", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiangVienHdSinhViens", "TenSinhVien", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiangVienHdSinhViens", "MaHocKy", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiangViens", "MaGiangVien", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiangViens", "HoDem", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiangViens", "Ten", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiangViens", "HoTen", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiangViens", "HomThu", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiangViens", "DonViCongTac", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiangViens", "DienThoai", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiangViens", "MaBoMon", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiangViens", "MaHocKy", c => c.String(maxLength: 50));
            AlterColumn("dbo.HoiDongDanhGiaKQs", "MaHoiDong", c => c.String(maxLength: 50));
            AlterColumn("dbo.HoiDongDanhGiaKQs", "MaMonHoc", c => c.String(maxLength: 50));
            AlterColumn("dbo.KetQuas", "MaHoiDong", c => c.String(maxLength: 50));
            AlterColumn("dbo.KetQuas", "MaGiangVien", c => c.String(maxLength: 50));
            AlterColumn("dbo.KetQuas", "MaDeTai", c => c.String(maxLength: 50));
            AlterColumn("dbo.KetQuas", "MaMonHoc", c => c.String(maxLength: 50));
            AlterColumn("dbo.LoaiMonHocs", "TenLoaiMonHoc", c => c.String(maxLength: 50));
            AlterColumn("dbo.MonHocs", "MaMonHoc", c => c.String(maxLength: 50));
            AlterColumn("dbo.MonHocs", "TenMonHoc", c => c.String(maxLength: 50));
            AlterColumn("dbo.MonHocs", "DieuKienTienQuyet", c => c.String(maxLength: 50));
            AlterColumn("dbo.MonHocs", "MaHocKy", c => c.String(maxLength: 50));
            AlterColumn("dbo.PhanBienDeTais", "MaGiangVien", c => c.String(maxLength: 50));
            AlterColumn("dbo.PhanBienDeTais", "MaDeTai", c => c.String(maxLength: 50));
            AlterColumn("dbo.PhanBienDeTais", "MaMonHoc", c => c.String(maxLength: 50));
            AlterColumn("dbo.PhanBiens", "MaGiangVien", c => c.String(maxLength: 50));
            AlterColumn("dbo.PhanBiens", "MaMonHoc", c => c.String(maxLength: 50));
            AlterColumn("dbo.SinhViens", "HoDem", c => c.String(maxLength: 50));
            AlterColumn("dbo.SinhViens", "Ten", c => c.String(maxLength: 50));
            AlterColumn("dbo.SinhViens", "HoTen", c => c.String(maxLength: 50));
            AlterColumn("dbo.SinhViens", "HomThu", c => c.String(maxLength: 50));
            AlterColumn("dbo.SinhViens", "MaLop", c => c.String(maxLength: 50));
            AlterColumn("dbo.SinhViens", "DienThoai", c => c.String(maxLength: 50));
            AlterColumn("dbo.SinhViens", "MaHocKy", c => c.String(maxLength: 50));
            AlterColumn("dbo.TaiKhoans", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.TaiKhoans", "MatKhau", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaiKhoans", "MatKhau", c => c.String());
            AlterColumn("dbo.TaiKhoans", "Email", c => c.String());
            AlterColumn("dbo.SinhViens", "MaHocKy", c => c.String());
            AlterColumn("dbo.SinhViens", "DienThoai", c => c.String());
            AlterColumn("dbo.SinhViens", "MaLop", c => c.String());
            AlterColumn("dbo.SinhViens", "HomThu", c => c.String());
            AlterColumn("dbo.SinhViens", "HoTen", c => c.String());
            AlterColumn("dbo.SinhViens", "Ten", c => c.String());
            AlterColumn("dbo.SinhViens", "HoDem", c => c.String());
            AlterColumn("dbo.PhanBiens", "MaMonHoc", c => c.String());
            AlterColumn("dbo.PhanBiens", "MaGiangVien", c => c.String());
            AlterColumn("dbo.PhanBienDeTais", "MaMonHoc", c => c.String());
            AlterColumn("dbo.PhanBienDeTais", "MaDeTai", c => c.String());
            AlterColumn("dbo.PhanBienDeTais", "MaGiangVien", c => c.String());
            AlterColumn("dbo.MonHocs", "MaHocKy", c => c.String());
            AlterColumn("dbo.MonHocs", "DieuKienTienQuyet", c => c.String());
            AlterColumn("dbo.MonHocs", "TenMonHoc", c => c.String());
            AlterColumn("dbo.MonHocs", "MaMonHoc", c => c.String());
            AlterColumn("dbo.LoaiMonHocs", "TenLoaiMonHoc", c => c.String());
            AlterColumn("dbo.KetQuas", "MaMonHoc", c => c.String());
            AlterColumn("dbo.KetQuas", "MaDeTai", c => c.String());
            AlterColumn("dbo.KetQuas", "MaGiangVien", c => c.String());
            AlterColumn("dbo.KetQuas", "MaHoiDong", c => c.String());
            AlterColumn("dbo.HoiDongDanhGiaKQs", "MaMonHoc", c => c.String());
            AlterColumn("dbo.HoiDongDanhGiaKQs", "MaHoiDong", c => c.String());
            AlterColumn("dbo.GiangViens", "MaHocKy", c => c.String());
            AlterColumn("dbo.GiangViens", "MaBoMon", c => c.String());
            AlterColumn("dbo.GiangViens", "DienThoai", c => c.String());
            AlterColumn("dbo.GiangViens", "DonViCongTac", c => c.String());
            AlterColumn("dbo.GiangViens", "HomThu", c => c.String());
            AlterColumn("dbo.GiangViens", "HoTen", c => c.String());
            AlterColumn("dbo.GiangViens", "Ten", c => c.String());
            AlterColumn("dbo.GiangViens", "HoDem", c => c.String());
            AlterColumn("dbo.GiangViens", "MaGiangVien", c => c.String());
            AlterColumn("dbo.GiangVienHdSinhViens", "MaHocKy", c => c.String());
            AlterColumn("dbo.GiangVienHdSinhViens", "TenSinhVien", c => c.String());
            AlterColumn("dbo.GiangVienHdSinhViens", "MaSinhVien", c => c.String());
            AlterColumn("dbo.GiangVienHdSinhViens", "TenGiangVien", c => c.String());
            AlterColumn("dbo.GiangVienHdSinhViens", "MaGiangVien", c => c.String());
            AlterColumn("dbo.DeTais", "MaHoiDong", c => c.String());
            AlterColumn("dbo.DeTais", "MaGiangVien", c => c.String());
            AlterColumn("dbo.DeTais", "MaSinhVien", c => c.String());
            AlterColumn("dbo.DeTais", "MaMonHoc", c => c.String());
            AlterColumn("dbo.DeTais", "TenDeTai", c => c.String());
            AlterColumn("dbo.DeTais", "MaDeTai", c => c.String());
        }
    }
}
