namespace Conneck.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.Int(nullable: false),
                        Zip = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.CarCategory",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        AdminC = c.String(nullable: false),
                        AdminM = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        OwerId = c.Guid(nullable: false),
                        CarType = c.Int(nullable: false),
                        CarName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Brand = c.String(nullable: false),
                        Color = c.String(nullable: false),
                        VIN = c.String(nullable: false),
                        PlateNumber = c.String(nullable: false),
                        FBY = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                        StoreID = c.Int(nullable: false),
                        CategoryID = c.Int(),
                        Admin_AdminID = c.Int(),
                    })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.Admin", t => t.Admin_AdminID)
                .ForeignKey("dbo.CarCategory", t => t.CategoryID)
                .ForeignKey("dbo.Store", t => t.StoreID, cascadeDelete: true)
                .Index(t => t.StoreID)
                .Index(t => t.CategoryID)
                .Index(t => t.Admin_AdminID);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        StoreName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Unit = c.String(),
                        City = c.String(nullable: false),
                        State = c.Int(nullable: false),
                        Zip = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                        AdminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoreID)
                .ForeignKey("dbo.Admin", t => t.AdminID, cascadeDelete: true)
                .Index(t => t.AdminID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Car", "StoreID", "dbo.Store");
            DropForeignKey("dbo.Store", "AdminID", "dbo.Admin");
            DropForeignKey("dbo.Car", "CategoryID", "dbo.CarCategory");
            DropForeignKey("dbo.Car", "Admin_AdminID", "dbo.Admin");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Store", new[] { "AdminID" });
            DropIndex("dbo.Car", new[] { "Admin_AdminID" });
            DropIndex("dbo.Car", new[] { "CategoryID" });
            DropIndex("dbo.Car", new[] { "StoreID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Store");
            DropTable("dbo.Car");
            DropTable("dbo.CarCategory");
            DropTable("dbo.Admin");
        }
    }
}
