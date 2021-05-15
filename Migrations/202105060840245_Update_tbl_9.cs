namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MonHocs", "DieuKienTienQuyet", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MonHocs", "DieuKienTienQuyet", c => c.Boolean(nullable: false));
        }
    }
}
