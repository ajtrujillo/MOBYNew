namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIdtoDiscountClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        discountPercent = c.Int(nullable: false),
                        discountDuration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ContactTypes", "Discount_Id", c => c.Byte());
            CreateIndex("dbo.ContactTypes", "Discount_Id");
            AddForeignKey("dbo.ContactTypes", "Discount_Id", "dbo.Discounts", "Id");
            DropColumn("dbo.ContactTypes", "Discount_discountPercent");
            DropColumn("dbo.ContactTypes", "Discount_discountDuration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactTypes", "Discount_discountDuration", c => c.DateTime(nullable: false));
            AddColumn("dbo.ContactTypes", "Discount_discountPercent", c => c.Int(nullable: false));
            DropForeignKey("dbo.ContactTypes", "Discount_Id", "dbo.Discounts");
            DropIndex("dbo.ContactTypes", new[] { "Discount_Id" });
            DropColumn("dbo.ContactTypes", "Discount_Id");
            DropTable("dbo.Discounts");
        }
    }
}
