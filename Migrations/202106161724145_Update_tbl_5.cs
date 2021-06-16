namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HocKys", "MaHocKy", c => c.String(nullable: false));
            AlterColumn("dbo.HocKys", "TenHocKy", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HocKys", "TenHocKy", c => c.String(maxLength: 50));
            AlterColumn("dbo.HocKys", "MaHocKy", c => c.String());
        }
    }
}
