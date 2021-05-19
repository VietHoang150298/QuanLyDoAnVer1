namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_18 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.KetQuas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.KetQuas",
                c => new
                    {
                        IdKetQua = c.Int(nullable: false, identity: true),
                        DiemSo = c.Single(),
                        NhanXet = c.String(maxLength: 50),
                        MaHoiDong = c.String(maxLength: 50),
                        MaGiangVien = c.String(maxLength: 50),
                        MaDeTai = c.String(maxLength: 50),
                        IsPhanBien = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdKetQua);
            
        }
    }
}
