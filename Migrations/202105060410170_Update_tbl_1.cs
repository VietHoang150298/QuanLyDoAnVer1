namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeTais", "MaMonHoc", c => c.String());
            AddColumn("dbo.DeTais", "MaSinhVien", c => c.String());
            AddColumn("dbo.DeTais", "MaGiangVien", c => c.String());
            AddColumn("dbo.GiangViens", "MaHocKy", c => c.String());
            AddColumn("dbo.HoiDongDanhGiaKQs", "SoLuongThanhVien", c => c.Int(nullable: false));
            AddColumn("dbo.HoiDongDanhGiaKQs", "MaDeTai", c => c.String());
            AddColumn("dbo.MonHocs", "MaHocKy", c => c.String());
            AddColumn("dbo.SinhViens", "MaHocKy", c => c.String());
            AlterColumn("dbo.HocKys", "NamBatDau", c => c.DateTime());
            AlterColumn("dbo.HocKys", "NamKetThuc", c => c.DateTime());
            DropColumn("dbo.DeTais", "KetQua");
            DropColumn("dbo.DeTais", "NhanXet");
            DropColumn("dbo.DeTais", "IdMonHoc");
            DropColumn("dbo.DeTais", "IdHoiDong");
            DropColumn("dbo.DeTais", "IdSinhVien");
            DropColumn("dbo.DeTais", "IdGvhdTheoky");
            DropColumn("dbo.HoiDongDanhGiaKQs", "TenHoiDong");
            DropColumn("dbo.HoiDongDanhGiaKQs", "KetQuaCaNhan");
            DropColumn("dbo.HoiDongDanhGiaKQs", "NhanXet");
            DropColumn("dbo.HoiDongDanhGiaKQs", "IdGiangVien");
            DropColumn("dbo.HoiDongDanhGiaKQs", "IdPhanBien");
            DropColumn("dbo.HoiDongDanhGiaKQs", "IdHocKy");
            DropColumn("dbo.MonHocs", "IdHocKy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MonHocs", "IdHocKy", c => c.Int());
            AddColumn("dbo.HoiDongDanhGiaKQs", "IdHocKy", c => c.Int());
            AddColumn("dbo.HoiDongDanhGiaKQs", "IdPhanBien", c => c.Int());
            AddColumn("dbo.HoiDongDanhGiaKQs", "IdGiangVien", c => c.Int());
            AddColumn("dbo.HoiDongDanhGiaKQs", "NhanXet", c => c.String());
            AddColumn("dbo.HoiDongDanhGiaKQs", "KetQuaCaNhan", c => c.Int());
            AddColumn("dbo.HoiDongDanhGiaKQs", "TenHoiDong", c => c.String());
            AddColumn("dbo.DeTais", "IdGvhdTheoky", c => c.Int());
            AddColumn("dbo.DeTais", "IdSinhVien", c => c.Int());
            AddColumn("dbo.DeTais", "IdHoiDong", c => c.Int());
            AddColumn("dbo.DeTais", "IdMonHoc", c => c.Int());
            AddColumn("dbo.DeTais", "NhanXet", c => c.String());
            AddColumn("dbo.DeTais", "KetQua", c => c.Single());
            AlterColumn("dbo.HocKys", "NamKetThuc", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HocKys", "NamBatDau", c => c.DateTime(nullable: false));
            DropColumn("dbo.SinhViens", "MaHocKy");
            DropColumn("dbo.MonHocs", "MaHocKy");
            DropColumn("dbo.HoiDongDanhGiaKQs", "MaDeTai");
            DropColumn("dbo.HoiDongDanhGiaKQs", "SoLuongThanhVien");
            DropColumn("dbo.GiangViens", "MaHocKy");
            DropColumn("dbo.DeTais", "MaGiangVien");
            DropColumn("dbo.DeTais", "MaSinhVien");
            DropColumn("dbo.DeTais", "MaMonHoc");
        }
    }
}
