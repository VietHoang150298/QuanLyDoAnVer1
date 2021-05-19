namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KeyQuas",
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KeyQuas");
        }
    }
}
