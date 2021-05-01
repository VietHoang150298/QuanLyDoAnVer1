namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_giang_vien : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GiangViens", "MaBoMon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GiangViens", "MaBoMon");
        }
    }
}
