namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhanBienDeTais", "MaMonHoc", c => c.String());
            DropColumn("dbo.PhanBienDeTais", "MaHocKy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhanBienDeTais", "MaHocKy", c => c.String());
            DropColumn("dbo.PhanBienDeTais", "MaMonHoc");
        }
    }
}
