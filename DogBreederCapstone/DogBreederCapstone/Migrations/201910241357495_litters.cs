namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class litters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Litters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        SendHomeDate = c.DateTime(nullable: false),
                        CoatId = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coats", t => t.CoatId, cascadeDelete: true)
                .ForeignKey("dbo.Sizes", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.CoatId)
                .Index(t => t.SizeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Litters", "SizeId", "dbo.Sizes");
            DropForeignKey("dbo.Litters", "CoatId", "dbo.Coats");
            DropIndex("dbo.Litters", new[] { "SizeId" });
            DropIndex("dbo.Litters", new[] { "CoatId" });
            DropTable("dbo.Litters");
        }
    }
}
