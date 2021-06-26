namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_20 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SinhViens", "MaSinhVien", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SinhViens", "MaSinhVien", c => c.String());
        }
    }
}
