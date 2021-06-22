namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhanBiens", "MaMonHoc", c => c.String());
            DropColumn("dbo.PhanBienDeTais", "MaMonHoc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhanBienDeTais", "MaMonHoc", c => c.String());
            DropColumn("dbo.PhanBiens", "MaMonHoc");
        }
    }
}
