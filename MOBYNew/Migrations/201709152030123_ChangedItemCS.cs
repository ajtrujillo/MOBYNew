namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedItemCS : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "CategoryId" });
            AddColumn("dbo.Items", "ItemName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Items", "ImagePath", c => c.String());
            AlterColumn("dbo.Items", "CategoryId", c => c.Int());
            AlterColumn("dbo.Items", "Price", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Items", "ISBN13EAN", c => c.Double());
            AlterColumn("dbo.Items", "QtyInStock", c => c.Int());
            CreateIndex("dbo.Items", "CategoryId");
            AddForeignKey("dbo.Items", "CategoryId", "dbo.Categories", "Id");
            DropColumn("dbo.Items", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Name", c => c.String());
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "CategoryId" });
            AlterColumn("dbo.Items", "QtyInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "ISBN13EAN", c => c.Double(nullable: false));
            AlterColumn("dbo.Items", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Items", "CategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "ImagePath");
            DropColumn("dbo.Items", "ItemName");
            CreateIndex("dbo.Items", "CategoryId");
            AddForeignKey("dbo.Items", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
