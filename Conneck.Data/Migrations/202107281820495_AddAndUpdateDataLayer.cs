namespace Conneck.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAndUpdateDataLayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Car", "Make", c => c.String(nullable: false));
            AddColumn("dbo.Car", "LicensePlate", c => c.String(nullable: false));
            AddColumn("dbo.Car", "Mileage", c => c.Int(nullable: false));
            AddColumn("dbo.Car", "Rate", c => c.Int(nullable: false));
            AddColumn("dbo.Car", "Year", c => c.Int(nullable: false));
            DropColumn("dbo.Car", "CarName");
            DropColumn("dbo.Car", "Description");
            DropColumn("dbo.Car", "Brand");
            DropColumn("dbo.Car", "PlateNumber");
            DropColumn("dbo.Car", "FBY");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Car", "FBY", c => c.Int(nullable: false));
            AddColumn("dbo.Car", "PlateNumber", c => c.String(nullable: false));
            AddColumn("dbo.Car", "Brand", c => c.String(nullable: false));
            AddColumn("dbo.Car", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Car", "CarName", c => c.String(nullable: false));
            DropColumn("dbo.Car", "Year");
            DropColumn("dbo.Car", "Rate");
            DropColumn("dbo.Car", "Mileage");
            DropColumn("dbo.Car", "LicensePlate");
            DropColumn("dbo.Car", "Make");
        }
    }
}
