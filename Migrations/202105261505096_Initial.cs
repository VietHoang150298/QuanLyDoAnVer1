namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietHoiDongs",
                c => new
                    {
                        IdChiTietHoiDong = c.Int(nullable: false, identity: true),
                        MaHoiDong = c.String(maxLength: 50),
                        MaGiangVien = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IdChiTietHoiDong);
            
            CreateTable(
                "dbo.DeTais",
                c => new
                    {
                        IdDeTai = c.Int(nullable: false, identity: true),
                        MaDeTai = c.String(),
                        TenDeTai = c.String(),
                        LinkFileBaoCaoCuoiCung = c.String(),
                        MaMonHoc = c.String(),
                        MaSinhVien = c.String(),
                        MaGiangVien = c.String(),
                        MaHoiDong = c.String(),
                        SoLuongPhanBien = c.Int(),
                    })
                .PrimaryKey(t => t.IdDeTai);
            
            CreateTable(
                "dbo.GiangVienHdSinhViens",
                c => new
                    {
                        IdGiangVienHdSinhVien = c.Int(nullable: false, identity: true),
                        MaGiangVien = c.String(),
                        TenGiangVien = c.String(),
                        MaSinhVien = c.String(),
                        TenSinhVien = c.String(),
                        MaHocKy = c.String(),
                    })
                .PrimaryKey(t => t.IdGiangVienHdSinhVien);
            
            CreateTable(
                "dbo.GiangViens",
                c => new
                    {
                        IdGiangVien = c.Int(nullable: false, identity: true),
                        MaGiangVien = c.String(),
                        HoDem = c.String(),
                        Ten = c.String(),
                        HoTen = c.String(),
                        HomThu = c.String(),
                        DonViCongTac = c.String(),
                        DienThoai = c.String(),
                        MaBoMon = c.String(),
                        MaHocKy = c.String(),
                    })
                .PrimaryKey(t => t.IdGiangVien);
            
            CreateTable(
                "dbo.HocKys",
                c => new
                    {
                        IdHocKy = c.Int(nullable: false, identity: true),
                        MaHocKy = c.String(),
                        TenHocKy = c.String(maxLength: 50),
                        NamBatDau = c.DateTime(),
                        NamKetThuc = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdHocKy);
            
            CreateTable(
                "dbo.HoiDongDanhGiaKQs",
                c => new
                    {
                        IdHoiDongDGKQ = c.Int(nullable: false, identity: true),
                        MaHoiDong = c.String(),
                        ThoiKhoaBieu = c.DateTime(),
                        SoLuongThanhVien = c.Int(nullable: false),
                        DemSoLuongThanhVien = c.Int(nullable: false),
                        MaHocKy = c.String(),
                    })
                .PrimaryKey(t => t.IdHoiDongDGKQ);
            
            CreateTable(
                "dbo.KetQuas",
                c => new
                    {
                        IdKetQua = c.Int(nullable: false, identity: true),
                        MaHoiDong = c.String(),
                        MaGiangVien = c.String(),
                        MaDeTai = c.String(),
                        DiemSo = c.Single(nullable: false),
                        NhanXet = c.String(),
                        IsPhanBien = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdKetQua);
            
            CreateTable(
                "dbo.MonHocs",
                c => new
                    {
                        IdMonHoc = c.Int(nullable: false, identity: true),
                        MaMonHoc = c.String(),
                        TenMonHoc = c.String(),
                        DieuKienTienQuyet = c.Boolean(),
                        MaHocKy = c.String(),
                    })
                .PrimaryKey(t => t.IdMonHoc);
            
            CreateTable(
                "dbo.PhanBienDeTais",
                c => new
                    {
                        IdPhanBienDeTai = c.Int(nullable: false, identity: true),
                        MaHocKy = c.String(),
                        MaGiangVien = c.String(),
                        MaDeTai = c.String(),
                        ThoiKhoaBieu = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdPhanBienDeTai);
            
            CreateTable(
                "dbo.PhanBiens",
                c => new
                    {
                        IdPhanBien = c.Int(nullable: false, identity: true),
                        MaGiangVien = c.String(),
                    })
                .PrimaryKey(t => t.IdPhanBien);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        IdSinhVien = c.Int(nullable: false, identity: true),
                        MaSinhVien = c.String(),
                        HoDem = c.String(),
                        Ten = c.String(),
                        HoTen = c.String(),
                        HomThu = c.String(),
                        MaLop = c.String(),
                        DienThoai = c.String(),
                        TinChiTichLuy = c.Int(),
                        DiemTichLuy = c.Single(),
                        MaHocKy = c.String(),
                    })
                .PrimaryKey(t => t.IdSinhVien);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SinhViens");
            DropTable("dbo.PhanBiens");
            DropTable("dbo.PhanBienDeTais");
            DropTable("dbo.MonHocs");
            DropTable("dbo.KetQuas");
            DropTable("dbo.HoiDongDanhGiaKQs");
            DropTable("dbo.HocKys");
            DropTable("dbo.GiangViens");
            DropTable("dbo.GiangVienHdSinhViens");
            DropTable("dbo.DeTais");
            DropTable("dbo.ChiTietHoiDongs");
        }
    }
}
