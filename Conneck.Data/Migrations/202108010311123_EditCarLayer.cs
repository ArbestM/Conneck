namespace Conneck.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCarLayer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarCategory", "AdminC", c => c.Int(nullable: false));
            AlterColumn("dbo.CarCategory", "AdminM", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CarCategory", "AdminM", c => c.String(nullable: false));
            AlterColumn("dbo.CarCategory", "AdminC", c => c.String(nullable: false));
        }
    }
}
