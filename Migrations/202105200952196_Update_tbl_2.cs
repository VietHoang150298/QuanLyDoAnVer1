namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhanBiens", "TenGiangVien", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhanBiens", "TenGiangVien");
        }
    }
}
