namespace CourseBookingSystemMain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        IsSubscribedToNewsletter = c.Boolean(nullable: false),
                        CurrentMembershipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.MembershipTypes", t => t.CurrentMembershipTypeId, cascadeDelete: true)
                .Index(t => t.CurrentMembershipTypeId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SignupFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomersMovies",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.MovieId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomersMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.CustomersMovies", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CurrentMembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.CustomersMovies", new[] { "MovieId" });
            DropIndex("dbo.CustomersMovies", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "CurrentMembershipTypeId" });
            DropTable("dbo.CustomersMovies");
            DropTable("dbo.Movies");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
        }
    }
}
