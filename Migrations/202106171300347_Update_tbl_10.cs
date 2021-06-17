namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MonHocs", "IdLoaiMonHoc", c => c.Int(nullable: false));
            DropColumn("dbo.MonHocs", "LoaiMonHoc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MonHocs", "LoaiMonHoc", c => c.Int(nullable: false));
            DropColumn("dbo.MonHocs", "IdLoaiMonHoc");
        }
    }
}
