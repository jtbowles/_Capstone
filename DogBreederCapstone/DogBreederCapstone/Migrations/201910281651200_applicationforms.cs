namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicationforms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FamilyName = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.Int(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Referral = c.String(nullable: false),
                        Use = c.String(nullable: false),
                        Live = c.String(nullable: false),
                        Training = c.String(nullable: false),
                        PreviousDogs = c.Boolean(nullable: false),
                        PreviousDogsLive = c.String(),
                        OutOfTownPlan = c.String(nullable: false),
                        Children = c.Boolean(nullable: false),
                        Fence = c.String(nullable: false),
                        Reasoning = c.String(nullable: false),
                        Allergies = c.String(nullable: false),
                        LeftAlone = c.String(nullable: false),
                        PotentialOwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PotentialOwners", t => t.PotentialOwnerId)
                .Index(t => t.PotentialOwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationForms", "PotentialOwnerId", "dbo.PotentialOwners");
            DropIndex("dbo.ApplicationForms", new[] { "PotentialOwnerId" });
            DropTable("dbo.ApplicationForms");
        }
    }
}
