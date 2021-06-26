namespace QuanLyDoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tbl_19 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaiKhoans",
                c => new
                    {
                        IdTaiKhoan = c.Int(nullable: false, identity: true),
                        TenTaiKhoan = c.String(maxLength: 50),
                        Email = c.String(),
                        MatKhau = c.String(),
                        IdVaiTro = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IdTaiKhoan);
            
            CreateTable(
                "dbo.VaiTros",
                c => new
                    {
                        IdVaiTro = c.String(nullable: false, maxLength: 20),
                        TenVaiTro = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IdVaiTro);
            
            DropTable("dbo.Accounts");
            DropTable("dbo.Roles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 20),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        Email = c.String(),
                        Password = c.String(),
                        RoleId = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.AccountId);
            
            DropTable("dbo.VaiTros");
            DropTable("dbo.TaiKhoans");
        }
    }
}
