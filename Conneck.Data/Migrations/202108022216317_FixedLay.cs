namespace Conneck.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedLay : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Car", "Admin_AdminID", "dbo.Admin");
            DropIndex("dbo.Car", new[] { "Admin_AdminID" });
            AddColumn("dbo.Car", "Admin", c => c.Int(nullable: false));
            DropColumn("dbo.Car", "Admin_AdminID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Car", "Admin_AdminID", c => c.Int());
            DropColumn("dbo.Car", "Admin");
            CreateIndex("dbo.Car", "Admin_AdminID");
            AddForeignKey("dbo.Car", "Admin_AdminID", "dbo.Admin", "AdminID");
        }
    }
}
