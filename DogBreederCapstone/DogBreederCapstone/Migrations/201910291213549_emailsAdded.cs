namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PotentialOwners", "EmailAddress", c => c.String());
            AddColumn("dbo.Breeders", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Breeders", "EmailAddress");
            DropColumn("dbo.PotentialOwners", "EmailAddress");
        }
    }
}
