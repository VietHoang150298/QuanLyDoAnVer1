namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietHoiDongs",
                c => new
                    {
                        IdChiTietHoiDong = c.Int(nullable: false, identity: true),
                        SoLuongThanhVien = c.Int(nullable: false),
                        MaGiangVien = c.String(),
                        MaHoiDong = c.String(),
                    })
                .PrimaryKey(t => t.IdChiTietHoiDong);
            
            CreateTable(
                "dbo.KetQuas",
                c => new
                    {
                        IdKetQua = c.Int(nullable: false, identity: true),
                        MaHoiDong = c.String(),
                        MaGiangVien = c.String(),
                        MaDeTai = c.String(),
                    })
                .PrimaryKey(t => t.IdKetQua);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KetQuas");
            DropTable("dbo.ChiTietHoiDongs");
        }
    }
}
