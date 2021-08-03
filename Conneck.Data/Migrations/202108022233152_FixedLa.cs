namespace Conneck.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedLa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Car", "CategoryID", "dbo.CarCategory");
            DropIndex("dbo.Car", new[] { "CategoryID" });
            AlterColumn("dbo.Car", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Car", "CategoryID");
            AddForeignKey("dbo.Car", "CategoryID", "dbo.CarCategory", "CategoryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Car", "CategoryID", "dbo.CarCategory");
            DropIndex("dbo.Car", new[] { "CategoryID" });
            AlterColumn("dbo.Car", "CategoryID", c => c.Int());
            CreateIndex("dbo.Car", "CategoryID");
            AddForeignKey("dbo.Car", "CategoryID", "dbo.CarCategory", "CategoryID");
        }
    }
}
