namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KetQuas", "DiemSo", c => c.Int());
            AddColumn("dbo.KetQuas", "NhanXet", c => c.String(maxLength: 50));
            AddColumn("dbo.KetQuas", "MaPhanBien", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KetQuas", "MaPhanBien");
            DropColumn("dbo.KetQuas", "NhanXet");
            DropColumn("dbo.KetQuas", "DiemSo");
        }
    }
}
