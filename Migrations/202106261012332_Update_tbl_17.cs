namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MonHocs", "SoLuongPhanBien", c => c.Int(nullable: false));
            AddColumn("dbo.MonHocs", "SoLuongHoiDong", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MonHocs", "SoLuongHoiDong");
            DropColumn("dbo.MonHocs", "SoLuongPhanBien");
        }
    }
}
