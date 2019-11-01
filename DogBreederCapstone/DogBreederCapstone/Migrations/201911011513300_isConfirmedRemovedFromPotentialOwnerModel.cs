namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isConfirmedRemovedFromPotentialOwnerModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PotentialOwners", "IsApplicationConfirmed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PotentialOwners", "IsApplicationConfirmed", c => c.Boolean(nullable: false));
        }
    }
}
