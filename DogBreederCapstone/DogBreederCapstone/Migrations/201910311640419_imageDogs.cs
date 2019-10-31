namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageDogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Dogs", "ImageId", c => c.Int());
            CreateIndex("dbo.Dogs", "ImageId");
            AddForeignKey("dbo.Dogs", "ImageId", "dbo.Images", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dogs", "ImageId", "dbo.Images");
            DropIndex("dbo.Dogs", new[] { "ImageId" });
            DropColumn("dbo.Dogs", "ImageId");
            DropTable("dbo.Images");
        }
    }
}
