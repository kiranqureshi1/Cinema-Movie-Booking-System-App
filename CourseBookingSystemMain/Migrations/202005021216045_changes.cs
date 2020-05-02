namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "StudentStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "Bill", c => c.Single(nullable: false));
            AddColumn("dbo.Customers", "Disable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Movies", "TotalSeats", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Ticket", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "AgeRestriction", c => c.Boolean(nullable: false));
            AddColumn("dbo.Movies", "DisabilityResourcesRequirments", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DisabilityResourcesRequirments");
            DropColumn("dbo.Movies", "AgeRestriction");
            DropColumn("dbo.Movies", "Ticket");
            DropColumn("dbo.Movies", "TotalSeats");
            DropColumn("dbo.Customers", "Disable");
            DropColumn("dbo.Customers", "Bill");
            DropColumn("dbo.Customers", "StudentStatus");
            DropColumn("dbo.Customers", "Age");
        }
    }
}
