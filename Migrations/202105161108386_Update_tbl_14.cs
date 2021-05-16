namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeTais", "SoLuongPhanBien", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeTais", "SoLuongPhanBien");
        }
    }
}
