namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhanBienDeTais", "MaMonHoc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhanBienDeTais", "MaMonHoc");
        }
    }
}
