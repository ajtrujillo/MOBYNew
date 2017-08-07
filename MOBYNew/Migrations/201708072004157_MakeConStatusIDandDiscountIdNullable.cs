namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeConStatusIDandDiscountIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactTypes", "ContactStatusId", "dbo.ContactStatus");
            DropForeignKey("dbo.ContactTypes", "DiscountId", "dbo.Discounts");
            DropIndex("dbo.ContactTypes", new[] { "DiscountId" });
            DropIndex("dbo.ContactTypes", new[] { "ContactStatusId" });
            AlterColumn("dbo.ContactTypes", "DiscountId", c => c.Int());
            AlterColumn("dbo.ContactTypes", "ContactStatusId", c => c.Int());
            CreateIndex("dbo.ContactTypes", "DiscountId");
            CreateIndex("dbo.ContactTypes", "ContactStatusId");
            AddForeignKey("dbo.ContactTypes", "ContactStatusId", "dbo.ContactStatus", "Id");
            AddForeignKey("dbo.ContactTypes", "DiscountId", "dbo.Discounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactTypes", "DiscountId", "dbo.Discounts");
            DropForeignKey("dbo.ContactTypes", "ContactStatusId", "dbo.ContactStatus");
            DropIndex("dbo.ContactTypes", new[] { "ContactStatusId" });
            DropIndex("dbo.ContactTypes", new[] { "DiscountId" });
            AlterColumn("dbo.ContactTypes", "ContactStatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.ContactTypes", "DiscountId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContactTypes", "ContactStatusId");
            CreateIndex("dbo.ContactTypes", "DiscountId");
            AddForeignKey("dbo.ContactTypes", "DiscountId", "dbo.Discounts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContactTypes", "ContactStatusId", "dbo.ContactStatus", "Id", cascadeDelete: true);
        }
    }
}
