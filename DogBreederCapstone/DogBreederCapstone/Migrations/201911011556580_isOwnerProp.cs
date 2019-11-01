namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isOwnerProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PotentialOwners", "IsOwner", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PotentialOwners", "IsOwner");
        }
    }
}
