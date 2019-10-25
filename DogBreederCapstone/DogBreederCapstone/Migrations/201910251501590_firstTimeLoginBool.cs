namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstTimeLoginBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstTimeLogin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FirstTimeLogin");
        }
    }
}
