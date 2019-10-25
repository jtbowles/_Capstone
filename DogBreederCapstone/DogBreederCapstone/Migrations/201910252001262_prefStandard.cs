namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prefStandard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Preferences", "IsStandard", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Preferences", "IsStandard");
        }
    }
}
