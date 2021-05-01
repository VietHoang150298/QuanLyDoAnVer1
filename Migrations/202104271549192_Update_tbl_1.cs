namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HocKys", "NamBatDau", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HocKys", "NamKetThuc", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HoiDongDanhGiaKQs", "ThoiKhoaBieu", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HoiDongDanhGiaKQs", "ThoiKhoaBieu", c => c.String());
            AlterColumn("dbo.HocKys", "NamKetThuc", c => c.String());
            AlterColumn("dbo.HocKys", "NamBatDau", c => c.String());
        }
    }
}
