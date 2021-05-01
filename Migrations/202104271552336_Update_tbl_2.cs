namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HoiDongDanhGiaKQs", "ThoiKhoaBieu", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HoiDongDanhGiaKQs", "ThoiKhoaBieu", c => c.DateTime(nullable: false));
        }
    }
}
