namespace AssetTrackingSystem_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propertynamecorrectedformodelentity : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Models", new[] { "Manufacturer_Id" });
            RenameColumn(table: "dbo.Models", name: "Manufacturer_Id", newName: "ManufacturerId");
            AlterColumn("dbo.Models", "ManufacturerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Models", "ManufacturerId");
            DropColumn("dbo.Models", "ManufacuturerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "ManufacuturerId", c => c.Int(nullable: false));
            DropIndex("dbo.Models", new[] { "ManufacturerId" });
            AlterColumn("dbo.Models", "ManufacturerId", c => c.Int());
            RenameColumn(table: "dbo.Models", name: "ManufacturerId", newName: "Manufacturer_Id");
            CreateIndex("dbo.Models", "Manufacturer_Id");
        }
    }
}
