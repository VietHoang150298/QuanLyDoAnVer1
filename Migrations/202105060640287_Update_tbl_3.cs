namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoiDongDanhGiaKQs", "MaHocKy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HoiDongDanhGiaKQs", "MaHocKy");
        }
    }
}
