namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GiangVienHdSinhVien",
                c => new
                    {
                        IdGiangVienHdSinhVien = c.Int(nullable: false, identity: true),
                        MaGiangVien = c.String(),
                        TenGiangVien = c.String(),
                        MaSinhVien = c.String(),
                        TenSinhVien = c.String(),
                    })
                .PrimaryKey(t => t.IdGiangVienHdSinhVien);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GiangVienHdSinhVien");
        }
    }
}
