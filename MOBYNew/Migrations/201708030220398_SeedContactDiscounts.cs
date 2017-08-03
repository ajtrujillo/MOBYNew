namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedContactDiscounts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactTypes", "DiscountId", "dbo.Discounts");
            DropIndex("dbo.ContactTypes", new[] { "DiscountId" });
            DropPrimaryKey("dbo.Discounts");
            AddColumn("dbo.ContactTypes", "Discount_Id", c => c.Int());
            AddColumn("dbo.Discounts", "discountDurationInMonths", c => c.Int(nullable: false));
            AlterColumn("dbo.Discounts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Discounts", "Id");
            CreateIndex("dbo.ContactTypes", "Discount_Id");
            AddForeignKey("dbo.ContactTypes", "Discount_Id", "dbo.Discounts", "Id");
            DropColumn("dbo.Discounts", "discountDuration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Discounts", "discountDuration", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.ContactTypes", "Discount_Id", "dbo.Discounts");
            DropIndex("dbo.ContactTypes", new[] { "Discount_Id" });
            DropPrimaryKey("dbo.Discounts");
            AlterColumn("dbo.Discounts", "Id", c => c.Byte(nullable: false));
            DropColumn("dbo.Discounts", "discountDurationInMonths");
            DropColumn("dbo.ContactTypes", "Discount_Id");
            AddPrimaryKey("dbo.Discounts", "Id");
            CreateIndex("dbo.ContactTypes", "DiscountId");
            AddForeignKey("dbo.ContactTypes", "DiscountId", "dbo.Discounts", "Id", cascadeDelete: true);
        }
    }
}
