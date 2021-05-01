namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DeTais", "KetQua", c => c.Single());
            AlterColumn("dbo.DeTais", "IdMonHoc", c => c.Int());
            AlterColumn("dbo.DeTais", "IdHoiDong", c => c.Int());
            AlterColumn("dbo.GiangVienHuongDanTheoKys", "IdGiangVien", c => c.Int());
            AlterColumn("dbo.GiangVienHuongDanTheoKys", "IdHocKy", c => c.Int());
            AlterColumn("dbo.GiangVienHuongDanTheoKys", "SoLuongSinhVienHuongDan", c => c.Int());
            AlterColumn("dbo.HoiDongDanhGiaKQs", "KetQuaCaNhan", c => c.Int());
            AlterColumn("dbo.HoiDongDanhGiaKQs", "IdGiangVien", c => c.Int());
            AlterColumn("dbo.HoiDongDanhGiaKQs", "IdPhanBien", c => c.Int());
            AlterColumn("dbo.MonHocs", "IdGiangVienHuongDanTheoKy", c => c.Int());
            AlterColumn("dbo.MonHocs", "IdSinhVien", c => c.Int());
            AlterColumn("dbo.PhanBiens", "IdGiangVien", c => c.Int());
            AlterColumn("dbo.PhanBiens", "ThoiKhoaBieu", c => c.DateTime());
            AlterColumn("dbo.PhanBiens", "KetQuaPhanBien", c => c.Int());
            AlterColumn("dbo.SinhViens", "TinChiTichLuy", c => c.Int());
            AlterColumn("dbo.SinhViens", "DiemTichLuy", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SinhViens", "DiemTichLuy", c => c.Single(nullable: false));
            AlterColumn("dbo.SinhViens", "TinChiTichLuy", c => c.Int(nullable: false));
            AlterColumn("dbo.PhanBiens", "KetQuaPhanBien", c => c.Int(nullable: false));
            AlterColumn("dbo.PhanBiens", "ThoiKhoaBieu", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PhanBiens", "IdGiangVien", c => c.Int(nullable: false));
            AlterColumn("dbo.MonHocs", "IdSinhVien", c => c.Int(nullable: false));
            AlterColumn("dbo.MonHocs", "IdGiangVienHuongDanTheoKy", c => c.Int(nullable: false));
            AlterColumn("dbo.HoiDongDanhGiaKQs", "IdPhanBien", c => c.Int(nullable: false));
            AlterColumn("dbo.HoiDongDanhGiaKQs", "IdGiangVien", c => c.Int(nullable: false));
            AlterColumn("dbo.HoiDongDanhGiaKQs", "KetQuaCaNhan", c => c.Int(nullable: false));
            AlterColumn("dbo.GiangVienHuongDanTheoKys", "SoLuongSinhVienHuongDan", c => c.Int(nullable: false));
            AlterColumn("dbo.GiangVienHuongDanTheoKys", "IdHocKy", c => c.Int(nullable: false));
            AlterColumn("dbo.GiangVienHuongDanTheoKys", "IdGiangVien", c => c.Int(nullable: false));
            AlterColumn("dbo.DeTais", "IdHoiDong", c => c.Int(nullable: false));
            AlterColumn("dbo.DeTais", "IdMonHoc", c => c.Int(nullable: false));
            AlterColumn("dbo.DeTais", "KetQua", c => c.Single(nullable: false));
        }
    }
}
