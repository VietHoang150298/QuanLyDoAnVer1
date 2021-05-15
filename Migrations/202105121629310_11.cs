namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeTais", "MaHoiDong", c => c.String());
            DropColumn("dbo.HoiDongDanhGiaKQs", "MaDeTai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HoiDongDanhGiaKQs", "MaDeTai", c => c.String());
            DropColumn("dbo.DeTais", "MaHoiDong");
        }
    }
}
