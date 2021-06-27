namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_22 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DeTais", "TenDeTai", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DeTais", "TenDeTai", c => c.String(maxLength: 50));
        }
    }
}
