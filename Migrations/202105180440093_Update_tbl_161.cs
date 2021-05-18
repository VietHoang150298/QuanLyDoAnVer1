namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_161 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoiDongDanhGiaKQs", "DemSoLuongThanhVien", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HoiDongDanhGiaKQs", "DemSoLuongThanhVien");
        }
    }
}
