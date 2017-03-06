namespace AssetTrackingSystem_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Branchnamenotunique : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Branches", new[] { "Name" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Branches", "Name", unique: true);
        }
    }
}
