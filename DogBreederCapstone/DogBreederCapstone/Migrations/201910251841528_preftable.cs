namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class preftable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Preferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsMicro = c.Boolean(nullable: false),
                        IsMini = c.Boolean(nullable: false),
                        IsMedium = c.Boolean(nullable: false),
                        IsCaramel = c.Boolean(nullable: false),
                        IsRed = c.Boolean(nullable: false),
                        IsBlue = c.Boolean(nullable: false),
                        IsSilver = c.Boolean(nullable: false),
                        IsCafe = c.Boolean(nullable: false),
                        IsChocolate = c.Boolean(nullable: false),
                        IsParchment = c.Boolean(nullable: false),
                        PotentialOwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PotentialOwners", t => t.PotentialOwnerId, cascadeDelete: true)
                .Index(t => t.PotentialOwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Preferences", "PotentialOwnerId", "dbo.PotentialOwners");
            DropIndex("dbo.Preferences", new[] { "PotentialOwnerId" });
            DropTable("dbo.Preferences");
        }
    }
}
