namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prefchange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PotentialOwners", "PreferenceId", "dbo.Preferences");
            DropIndex("dbo.PotentialOwners", new[] { "PreferenceId" });
            DropColumn("dbo.PotentialOwners", "PreferenceId");
            DropTable("dbo.Preferences");
        }
        
        public override void Down()
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
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PotentialOwners", "PreferenceId", c => c.Int());
            CreateIndex("dbo.PotentialOwners", "PreferenceId");
            AddForeignKey("dbo.PotentialOwners", "PreferenceId", "dbo.Preferences", "Id");
        }
    }
}
