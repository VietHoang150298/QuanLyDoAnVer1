namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GiangVienHdSinhVien", "MaHocKy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GiangVienHdSinhVien", "MaHocKy");
        }
    }
}
