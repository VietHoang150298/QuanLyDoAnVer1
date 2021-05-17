namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChiTietHoiDongs", "MaGiangVien", c => c.String(maxLength: 50));
            DropColumn("dbo.ChiTietHoiDongs", "MaGiangVien1");
            DropColumn("dbo.ChiTietHoiDongs", "MaGiangVien2");
            DropColumn("dbo.ChiTietHoiDongs", "MaGiangVien3");
            DropColumn("dbo.ChiTietHoiDongs", "MaGiangVien4");
            DropColumn("dbo.ChiTietHoiDongs", "MaGiangVien5");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChiTietHoiDongs", "MaGiangVien5", c => c.String(maxLength: 50));
            AddColumn("dbo.ChiTietHoiDongs", "MaGiangVien4", c => c.String(maxLength: 50));
            AddColumn("dbo.ChiTietHoiDongs", "MaGiangVien3", c => c.String(maxLength: 50));
            AddColumn("dbo.ChiTietHoiDongs", "MaGiangVien2", c => c.String(maxLength: 50));
            AddColumn("dbo.ChiTietHoiDongs", "MaGiangVien1", c => c.String(maxLength: 50));
            DropColumn("dbo.ChiTietHoiDongs", "MaGiangVien");
        }
    }
}
