namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhanBienDeTais", "ThoiKhoaBieu", c => c.DateTime());
            DropColumn("dbo.PhanBiens", "ThoiKhoaBieu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhanBiens", "ThoiKhoaBieu", c => c.DateTime());
            DropColumn("dbo.PhanBienDeTais", "ThoiKhoaBieu");
        }
    }
}
