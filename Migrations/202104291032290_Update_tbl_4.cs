namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeTais", "IdSinhVien", c => c.Int());
            AddColumn("dbo.DeTais", "IdGvhdTheoky", c => c.Int());
            AddColumn("dbo.HoiDongDanhGiaKQs", "IdHocKy", c => c.Int());
            AddColumn("dbo.MonHocs", "DieuKienTienQuyet", c => c.Int(nullable: false));
            AddColumn("dbo.MonHocs", "IdHocKy", c => c.Int());
            DropColumn("dbo.MonHocs", "IdGiangVienHuongDanTheoKy");
            DropColumn("dbo.MonHocs", "IdSinhVien");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MonHocs", "IdSinhVien", c => c.Int());
            AddColumn("dbo.MonHocs", "IdGiangVienHuongDanTheoKy", c => c.Int());
            DropColumn("dbo.MonHocs", "IdHocKy");
            DropColumn("dbo.MonHocs", "DieuKienTienQuyet");
            DropColumn("dbo.HoiDongDanhGiaKQs", "IdHocKy");
            DropColumn("dbo.DeTais", "IdGvhdTheoky");
            DropColumn("dbo.DeTais", "IdSinhVien");
        }
    }
}
