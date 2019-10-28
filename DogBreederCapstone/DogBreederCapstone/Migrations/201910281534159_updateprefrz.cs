namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateprefrz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Preferences", "IsLavender", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Preferences", "IsLavender");
        }
    }
}
