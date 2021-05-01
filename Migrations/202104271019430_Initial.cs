namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeTais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaDeTai = c.String(),
                        TenDeTai = c.String(),
                        KetQua = c.Single(nullable: false),
                        NhanXet = c.String(),
                        IdMonHoc = c.Int(nullable: false),
                        IdHoiDong = c.Int(nullable: false),
                        LinkFileBaoCaoCuoiCung = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GiangVienHuongDanTheoKys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdGiangVien = c.Int(nullable: false),
                        IdHocKy = c.Int(nullable: false),
                        SoLuongSinhVienHuongDan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GiangViens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaGiangVien = c.String(),
                        HoDem = c.String(),
                        Ten = c.String(),
                        HoTen = c.String(),
                        HomThu = c.String(),
                        IdThongTinChung = c.String(),
                        TenThongTinChung = c.String(),
                        GhiChu = c.String(),
                        DonViCongTac = c.String(),
                        DienThoai = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HocKys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaHocKy = c.String(),
                        TenHocKy = c.String(maxLength: 50),
                        NamBatDau = c.String(),
                        NamKetThuc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HoiDongDanhGiaKQs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaHoiDong = c.String(),
                        TenHoiDong = c.String(),
                        ThoiKhoaBieu = c.String(),
                        KetQuaCaNhan = c.Int(nullable: false),
                        NhanXet = c.String(),
                        IdGiangVien = c.Int(nullable: false),
                        IdPhanBien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MonHocs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaMonHoc = c.String(),
                        TenMonHoc = c.String(),
                        IdGiangVienHuongDanTheoKy = c.Int(nullable: false),
                        IdSinhVien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhanBiens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaPhanBien = c.String(),
                        IdGiangVien = c.Int(nullable: false),
                        ThoiKhoaBieu = c.DateTime(nullable: false),
                        KetQuaPhanBien = c.Int(nullable: false),
                        NhanXet = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaSinhVien = c.String(),
                        HoDem = c.String(),
                        Ten = c.String(),
                        HoTen = c.String(),
                        HomThu = c.String(),
                        IdLop = c.String(),
                        MaLop = c.String(),
                        DienThoai = c.String(),
                        TinChiTichLuy = c.String(),
                        DiemTichLuy = c.String(),
                        IdThongTinChung = c.String(),
                        TenThongTinChung = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SinhViens");
            DropTable("dbo.PhanBiens");
            DropTable("dbo.MonHocs");
            DropTable("dbo.HoiDongDanhGiaKQs");
            DropTable("dbo.HocKys");
            DropTable("dbo.GiangViens");
            DropTable("dbo.GiangVienHuongDanTheoKys");
            DropTable("dbo.DeTais");
        }
    }
}
