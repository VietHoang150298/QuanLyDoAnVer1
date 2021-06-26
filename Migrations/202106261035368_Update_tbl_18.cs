namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MonHocs", "SoLuongPhanBienToiDa", c => c.Int());
            AddColumn("dbo.MonHocs", "ThanhLapHoiDong", c => c.Boolean());
            DropColumn("dbo.MonHocs", "SoLuongPhanBien");
            DropColumn("dbo.MonHocs", "SoLuongHoiDong");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MonHocs", "SoLuongHoiDong", c => c.Int(nullable: false));
            AddColumn("dbo.MonHocs", "SoLuongPhanBien", c => c.Int(nullable: false));
            DropColumn("dbo.MonHocs", "ThanhLapHoiDong");
            DropColumn("dbo.MonHocs", "SoLuongPhanBienToiDa");
        }
    }
}
