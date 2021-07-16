namespace Conneck.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVINPropertyTOString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Car", "CarType", c => c.Int(nullable: false));
            AlterColumn("dbo.Car", "VIN", c => c.String(nullable: false));
            DropColumn("dbo.Car", "VehiculeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Car", "VehiculeType", c => c.Int(nullable: false));
            AlterColumn("dbo.Car", "VIN", c => c.Int(nullable: false));
            DropColumn("dbo.Car", "CarType");
        }
    }
}
