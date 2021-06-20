namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_13 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.KetQuas", "MaHocKy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KetQuas", "MaHocKy", c => c.String());
        }
    }
}
