namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class breederstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Breeders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Breeders", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.Breeders", new[] { "ApplicationId" });
            DropTable("dbo.Breeders");
        }
    }
}
