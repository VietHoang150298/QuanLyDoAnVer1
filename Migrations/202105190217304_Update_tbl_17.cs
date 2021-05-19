namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_17 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KetQuas", "DiemSo", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KetQuas", "DiemSo", c => c.Int());
        }
    }
}
