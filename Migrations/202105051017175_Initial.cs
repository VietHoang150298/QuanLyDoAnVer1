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
                        IdDeTai = c.Int(nullable: false, identity: true),
                        MaDeTai = c.String(),
                        TenDeTai = c.String(),
                        KetQua = c.Single(),
                        NhanXet = c.String(),
                        IdMonHoc = c.Int(),
                        IdHoiDong = c.Int(),
                        LinkFileBaoCaoCuoiCung = c.String(),
                        IdSinhVien = c.Int(),
                        IdGvhdTheoky = c.Int(),
                    })
                .PrimaryKey(t => t.IdDeTai);
            
            CreateTable(
                "dbo.GiangVienHuongDanTheoKys",
                c => new
                    {
                        IdGVHD = c.Int(nullable: false, identity: true),
                        IdGiangVien = c.Int(),
                        IdHocKy = c.Int(),
                        SoLuongSinhVienHuongDan = c.Int(),
                    })
                .PrimaryKey(t => t.IdGVHD);
            
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
                        GhiChu = c.String(),
                        DonViCongTac = c.String(),
                        DienThoai = c.String(),
                        MaBoMon = c.String(),
                    })
                .PrimaryKey(t => t.IdGiangVien);
            
            CreateTable(
                "dbo.HocKys",
                c => new
                    {
                        IdHocKy = c.Int(nullable: false, identity: true),
                        MaHocKy = c.String(),
                        TenHocKy = c.String(maxLength: 50),
                        NamBatDau = c.DateTime(nullable: false),
                        NamKetThuc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdHocKy);
            
            CreateTable(
                "dbo.HoiDongDanhGiaKQs",
                c => new
                    {
                        IdHoiDongDGKQ = c.Int(nullable: false, identity: true),
                        MaHoiDong = c.String(),
                        TenHoiDong = c.String(),
                        ThoiKhoaBieu = c.DateTime(),
                        KetQuaCaNhan = c.Int(),
                        NhanXet = c.String(),
                        IdGiangVien = c.Int(),
                        IdPhanBien = c.Int(),
                        IdHocKy = c.Int(),
                    })
                .PrimaryKey(t => t.IdHoiDongDGKQ);
            
            CreateTable(
                "dbo.MonHocs",
                c => new
                    {
                        IdMonHoc = c.Int(nullable: false, identity: true),
                        MaMonHoc = c.String(),
                        TenMonHoc = c.String(),
                        DieuKienTienQuyet = c.Int(nullable: false),
                        IdHocKy = c.Int(),
                    })
                .PrimaryKey(t => t.IdMonHoc);
            
            CreateTable(
                "dbo.PhanBiens",
                c => new
                    {
                        IdPhanBien = c.Int(nullable: false, identity: true),
                        MaPhanBien = c.String(),
                        IdGiangVien = c.Int(),
                        ThoiKhoaBieu = c.DateTime(),
                        KetQuaPhanBien = c.Int(),
                        NhanXet = c.String(),
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
                        IdLop = c.String(),
                        MaLop = c.String(),
                        DienThoai = c.String(),
                        TinChiTichLuy = c.Int(),
                        DiemTichLuy = c.Single(),
                    })
                .PrimaryKey(t => t.IdSinhVien);
            
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
