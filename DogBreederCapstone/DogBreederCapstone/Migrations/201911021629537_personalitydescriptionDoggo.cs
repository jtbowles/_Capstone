namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personalitydescriptionDoggo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dogs", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dogs", "Description");
        }
    }
}
