namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sizeupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sizes", "Height", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sizes", "Height");
        }
    }
}
