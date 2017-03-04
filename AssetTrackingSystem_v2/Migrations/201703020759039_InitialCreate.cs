namespace AssetTrackingSystem_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ShortName = c.String(nullable: false),
                        Code = c.String(maxLength: 50),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId)
                .Index(t => t.Name, unique: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ShortName = c.String(nullable: false, maxLength: 50),
                        Location = c.String(maxLength: 200),
                        Description = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.ShortName, unique: true);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ShortName = c.String(nullable: false),
                        Code = c.String(),
                        Description = c.String(maxLength: 150),
                        GeneralCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeneralCategories", t => t.GeneralCategoryId)
                .Index(t => t.Name, unique: true)
                .Index(t => t.GeneralCategoryId);
            
            CreateTable(
                "dbo.GeneralCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ShortName = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ShortName, unique: true);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ShortName = c.String(nullable: false, maxLength: 150),
                        Code = c.String(maxLength: 150),
                        OrganizationId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId)
                .Index(t => t.ShortName, unique: true)
                .Index(t => t.OrganizationId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Code = c.String(nullable: false, maxLength: 3),
                        Description = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 150),
                        ManufacuturerId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Manufacturer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.Manufacturer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.Models", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Locations", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Locations", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Categories", "GeneralCategoryId", "dbo.GeneralCategories");
            DropForeignKey("dbo.Branches", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Models", new[] { "Manufacturer_Id" });
            DropIndex("dbo.Models", new[] { "CategoryId" });
            DropIndex("dbo.Manufacturers", new[] { "Name" });
            DropIndex("dbo.Locations", new[] { "BranchId" });
            DropIndex("dbo.Locations", new[] { "OrganizationId" });
            DropIndex("dbo.Locations", new[] { "ShortName" });
            DropIndex("dbo.GeneralCategories", new[] { "ShortName" });
            DropIndex("dbo.Categories", new[] { "GeneralCategoryId" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropIndex("dbo.Organizations", new[] { "ShortName" });
            DropIndex("dbo.Organizations", new[] { "Name" });
            DropIndex("dbo.Branches", new[] { "OrganizationId" });
            DropIndex("dbo.Branches", new[] { "Name" });
            DropTable("dbo.Models");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Locations");
            DropTable("dbo.GeneralCategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Organizations");
            DropTable("dbo.Branches");
        }
    }
}
