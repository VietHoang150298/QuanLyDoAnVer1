namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhanBienDeTais",
                c => new
                    {
                        IdPhanBienDeTai = c.Int(nullable: false, identity: true),
                        MaHocKy = c.String(),
                        MaGiangVien = c.String(),
                        MaSinhVien = c.String(),
                    })
                .PrimaryKey(t => t.IdPhanBienDeTai);
            
            AddColumn("dbo.KetQuas", "IsPhanBien", c => c.Boolean());
            DropColumn("dbo.KetQuas", "MaPhanBien");
            DropColumn("dbo.PhanBiens", "MaPhanBien");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhanBiens", "MaPhanBien", c => c.String());
            AddColumn("dbo.KetQuas", "MaPhanBien", c => c.String(maxLength: 50));
            DropColumn("dbo.KetQuas", "IsPhanBien");
            DropTable("dbo.PhanBienDeTais");
        }
    }
}
