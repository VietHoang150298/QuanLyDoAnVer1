namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_sinhvien : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SinhViens", "TinChiTichLuy", c => c.Int(nullable: false));
            AlterColumn("dbo.SinhViens", "DiemTichLuy", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SinhViens", "DiemTichLuy", c => c.String());
            AlterColumn("dbo.SinhViens", "TinChiTichLuy", c => c.String());
        }
    }
}
