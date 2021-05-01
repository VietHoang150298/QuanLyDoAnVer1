namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GiangViens", "IdThongTinChung");
            DropColumn("dbo.GiangViens", "TenThongTinChung");
            DropColumn("dbo.SinhViens", "IdThongTinChung");
            DropColumn("dbo.SinhViens", "TenThongTinChung");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SinhViens", "TenThongTinChung", c => c.String());
            AddColumn("dbo.SinhViens", "IdThongTinChung", c => c.String());
            AddColumn("dbo.GiangViens", "TenThongTinChung", c => c.String());
            AddColumn("dbo.GiangViens", "IdThongTinChung", c => c.String());
        }
    }
}
