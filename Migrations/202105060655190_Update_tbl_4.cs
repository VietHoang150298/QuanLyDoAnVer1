namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_4 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.GiangVienHuongDanTheoKys");
        }
        
        public override void Down()
        {
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
            
        }
    }
}
