namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoaiMonHocs",
                c => new
                    {
                        IdLoaiMonHoc = c.Int(nullable: false, identity: true),
                        TenLoaiMonHoc = c.String(),
                    })
                .PrimaryKey(t => t.IdLoaiMonHoc);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoaiMonHocs");
        }
    }
}
