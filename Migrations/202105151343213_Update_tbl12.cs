namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhanBiens", "MaDeTai", c => c.String());
            DropColumn("dbo.PhanBiens", "MaSinhVien");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhanBiens", "MaSinhVien", c => c.String());
            DropColumn("dbo.PhanBiens", "MaDeTai");
        }
    }
}
