namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PhanBiens", "TenGiangVien");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhanBiens", "TenGiangVien", c => c.String());
        }
    }
}
