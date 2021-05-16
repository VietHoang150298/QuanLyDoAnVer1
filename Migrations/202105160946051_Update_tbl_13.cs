namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhanBienDeTais", "MaDeTai", c => c.String());
            DropColumn("dbo.PhanBienDeTais", "MaSinhVien");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhanBienDeTais", "MaSinhVien", c => c.String());
            DropColumn("dbo.PhanBienDeTais", "MaDeTai");
        }
    }
}
