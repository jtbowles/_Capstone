namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        Date = c.DateTime(),
                        Time = c.DateTime(),
                        PotentialOwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PotentialOwners", t => t.PotentialOwnerId)
                .Index(t => t.PotentialOwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "PotentialOwnerId", "dbo.PotentialOwners");
            DropIndex("dbo.Appointments", new[] { "PotentialOwnerId" });
            DropTable("dbo.Appointments");
        }
    }
}
