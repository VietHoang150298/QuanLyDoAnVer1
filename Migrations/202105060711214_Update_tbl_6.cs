namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChiTietHoiDongs", "MaGiangVien", c => c.String(maxLength: 50));
            AlterColumn("dbo.ChiTietHoiDongs", "MaHoiDong", c => c.String(maxLength: 50));
            AlterColumn("dbo.KetQuas", "MaHoiDong", c => c.String(maxLength: 50));
            AlterColumn("dbo.KetQuas", "MaGiangVien", c => c.String(maxLength: 50));
            AlterColumn("dbo.KetQuas", "MaDeTai", c => c.String(maxLength: 50));
            AlterColumn("dbo.MonHocs", "DieuKienTienQuyet", c => c.Boolean(nullable: false));
            DropColumn("dbo.GiangViens", "GhiChu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KetQuas", "MaPhanBien", c => c.String());
            AddColumn("dbo.GiangViens", "GhiChu", c => c.String());
            AddColumn("dbo.ChiTietHoiDongs", "SoLuongThanhVien", c => c.Int(nullable: false));
            AlterColumn("dbo.MonHocs", "DieuKienTienQuyet", c => c.Int(nullable: false));
            AlterColumn("dbo.KetQuas", "MaDeTai", c => c.String());
            AlterColumn("dbo.KetQuas", "MaGiangVien", c => c.String());
            AlterColumn("dbo.KetQuas", "MaHoiDong", c => c.String());
            AlterColumn("dbo.ChiTietHoiDongs", "MaHoiDong", c => c.String());
            AlterColumn("dbo.ChiTietHoiDongs", "MaGiangVien", c => c.String());
        }
    }
}
