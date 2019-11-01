namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class watchedLitter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PotentialOwners", "WatchedLitterId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PotentialOwners", "WatchedLitterId");
        }
    }
}
