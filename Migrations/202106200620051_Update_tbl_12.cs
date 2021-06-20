namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HoiDongDanhGiaKQs", "MaHocKy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HoiDongDanhGiaKQs", "MaHocKy", c => c.String());
        }
    }
}
