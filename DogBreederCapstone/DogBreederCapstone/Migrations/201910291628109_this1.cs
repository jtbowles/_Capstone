namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class this1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationForms", "Confirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "Confirmed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Appointments", "Reason", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "Reason", c => c.String());
            DropColumn("dbo.Appointments", "Confirmed");
            DropColumn("dbo.ApplicationForms", "Confirmed");
        }
    }
}
