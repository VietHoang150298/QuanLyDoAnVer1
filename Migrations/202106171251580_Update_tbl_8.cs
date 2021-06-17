namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MonHocs", "LoaiMonHoc", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MonHocs", "LoaiMonHoc");
        }
    }
}
