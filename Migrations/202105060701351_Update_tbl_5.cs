namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KetQuas", "MaPhanBien", c => c.String());
            AddColumn("dbo.PhanBiens", "MaGiangVien", c => c.String());
            AddColumn("dbo.PhanBiens", "MaSinhVien", c => c.String());
            DropColumn("dbo.PhanBiens", "IdGiangVien");
            DropColumn("dbo.PhanBiens", "KetQuaPhanBien");
            DropColumn("dbo.PhanBiens", "NhanXet");
            DropColumn("dbo.SinhViens", "IdLop");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SinhViens", "IdLop", c => c.String());
            AddColumn("dbo.PhanBiens", "NhanXet", c => c.String());
            AddColumn("dbo.PhanBiens", "KetQuaPhanBien", c => c.Int());
            AddColumn("dbo.PhanBiens", "IdGiangVien", c => c.Int());
            DropColumn("dbo.PhanBiens", "MaSinhVien");
            DropColumn("dbo.PhanBiens", "MaGiangVien");
            DropColumn("dbo.KetQuas", "MaPhanBien");
        }
    }
}
