namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Preferences", "PotentialOwnerId", "dbo.PotentialOwners");
            DropIndex("dbo.Preferences", new[] { "PotentialOwnerId" });
            AddColumn("dbo.PotentialOwners", "PreferenceId", c => c.Int());
            CreateIndex("dbo.PotentialOwners", "PreferenceId");
            AddForeignKey("dbo.PotentialOwners", "PreferenceId", "dbo.Preferences", "Id");
            DropColumn("dbo.Preferences", "PotentialOwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Preferences", "PotentialOwnerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PotentialOwners", "PreferenceId", "dbo.Preferences");
            DropIndex("dbo.PotentialOwners", new[] { "PreferenceId" });
            DropColumn("dbo.PotentialOwners", "PreferenceId");
            CreateIndex("dbo.Preferences", "PotentialOwnerId");
            AddForeignKey("dbo.Preferences", "PotentialOwnerId", "dbo.PotentialOwners", "Id", cascadeDelete: true);
        }
    }
}
