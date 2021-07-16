namespace Conneck.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCarEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Car", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Car", "Model", c => c.String(nullable: false));
        }
    }
}
