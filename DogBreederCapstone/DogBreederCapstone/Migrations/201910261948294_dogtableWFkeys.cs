namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dogtableWFkeys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LitterId = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                        CollarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Collars", t => t.CollarId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.Litters", t => t.LitterId, cascadeDelete: true)
                .Index(t => t.LitterId)
                .Index(t => t.GenderId)
                .Index(t => t.CollarId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dogs", "LitterId", "dbo.Litters");
            DropForeignKey("dbo.Dogs", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Dogs", "CollarId", "dbo.Collars");
            DropIndex("dbo.Dogs", new[] { "CollarId" });
            DropIndex("dbo.Dogs", new[] { "GenderId" });
            DropIndex("dbo.Dogs", new[] { "LitterId" });
            DropTable("dbo.Genders");
            DropTable("dbo.Dogs");
            DropTable("dbo.Collars");
        }
    }
}
