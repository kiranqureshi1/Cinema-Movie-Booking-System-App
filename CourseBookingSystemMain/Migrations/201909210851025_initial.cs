namespace CourseBookingSystemMain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsSubscribedToNewsletter = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CustomerId = c.Int(nullable: false),
                        MembershipTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignupFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MembershipTypeId", "dbo.MembershipTypes");
            DropForeignKey("dbo.Movies", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Movies", new[] { "MembershipTypeId" });
            DropIndex("dbo.Movies", new[] { "CustomerId" });
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Movies");
            DropTable("dbo.Customers");
        }
    }
}
