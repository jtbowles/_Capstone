namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boolsForReservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PotentialOwners", "IsApplicationConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Dogs", "PotentialOwnerId", c => c.Int());
            AddColumn("dbo.Dogs", "isReserved", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Dogs", "PotentialOwnerId");
            AddForeignKey("dbo.Dogs", "PotentialOwnerId", "dbo.PotentialOwners", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dogs", "PotentialOwnerId", "dbo.PotentialOwners");
            DropIndex("dbo.Dogs", new[] { "PotentialOwnerId" });
            DropColumn("dbo.Dogs", "isReserved");
            DropColumn("dbo.Dogs", "PotentialOwnerId");
            DropColumn("dbo.PotentialOwners", "IsApplicationConfirmed");
        }
    }
}
