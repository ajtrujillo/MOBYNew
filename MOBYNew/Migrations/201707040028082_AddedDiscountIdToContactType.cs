namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDiscountIdToContactType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactTypes", "Discount_Id", "dbo.Discounts");
            DropIndex("dbo.ContactTypes", new[] { "Discount_Id" });
            RenameColumn(table: "dbo.ContactTypes", name: "Discount_Id", newName: "DiscountId");
            AlterColumn("dbo.ContactTypes", "DiscountId", c => c.Byte(nullable: false));
            CreateIndex("dbo.ContactTypes", "DiscountId");
            AddForeignKey("dbo.ContactTypes", "DiscountId", "dbo.Discounts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactTypes", "DiscountId", "dbo.Discounts");
            DropIndex("dbo.ContactTypes", new[] { "DiscountId" });
            AlterColumn("dbo.ContactTypes", "DiscountId", c => c.Byte());
            RenameColumn(table: "dbo.ContactTypes", name: "DiscountId", newName: "Discount_Id");
            CreateIndex("dbo.ContactTypes", "Discount_Id");
            AddForeignKey("dbo.ContactTypes", "Discount_Id", "dbo.Discounts", "Id");
        }
    }
}
