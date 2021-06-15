namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KetQuas", "MaMonHoc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KetQuas", "MaMonHoc");
        }
    }
}
