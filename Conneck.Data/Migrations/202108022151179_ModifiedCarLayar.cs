namespace Conneck.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCarLayar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Car", "CarM", c => c.String(nullable: false));
            DropColumn("dbo.Car", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Car", "Model", c => c.String(nullable: false));
            DropColumn("dbo.Car", "CarM");
        }
    }
}
