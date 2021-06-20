namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoiDongDanhGiaKQs", "MaMonHoc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HoiDongDanhGiaKQs", "MaMonHoc");
        }
    }
}
