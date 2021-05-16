namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_15 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PhanBiens", "MaDeTai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhanBiens", "MaDeTai", c => c.String());
        }
    }
}
