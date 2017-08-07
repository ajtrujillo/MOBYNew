namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKAttributes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "ContactType_Id", "dbo.ContactTypes");
            DropForeignKey("dbo.ContactTypes", "ContactStatus_Id", "dbo.ContactStatus");
            DropForeignKey("dbo.ContactTypes", "Discount_Id", "dbo.Discounts");
            DropIndex("dbo.Contacts", new[] { "ContactType_Id" });
            DropIndex("dbo.ContactTypes", new[] { "ContactStatus_Id" });
            DropIndex("dbo.ContactTypes", new[] { "Discount_Id" });
            DropColumn("dbo.Contacts", "ContactTypeId");
            RenameColumn(table: "dbo.Contacts", name: "ContactType_Id", newName: "ContactTypeId");
            RenameColumn(table: "dbo.ContactTypes", name: "ContactStatus_Id", newName: "ContactStatusId");
            RenameColumn(table: "dbo.ContactTypes", name: "Discount_Id", newName: "DiscountId");
            AlterColumn("dbo.Contacts", "ContactTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Contacts", "ContactTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.ContactTypes", "ContactStatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.ContactTypes", "DiscountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "ContactTypeId");
            CreateIndex("dbo.ContactTypes", "DiscountId");
            CreateIndex("dbo.ContactTypes", "ContactStatusId");
            AddForeignKey("dbo.Contacts", "ContactTypeId", "dbo.ContactTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContactTypes", "ContactStatusId", "dbo.ContactStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContactTypes", "DiscountId", "dbo.Discounts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactTypes", "DiscountId", "dbo.Discounts");
            DropForeignKey("dbo.ContactTypes", "ContactStatusId", "dbo.ContactStatus");
            DropForeignKey("dbo.Contacts", "ContactTypeId", "dbo.ContactTypes");
            DropIndex("dbo.ContactTypes", new[] { "ContactStatusId" });
            DropIndex("dbo.ContactTypes", new[] { "DiscountId" });
            DropIndex("dbo.Contacts", new[] { "ContactTypeId" });
            AlterColumn("dbo.ContactTypes", "DiscountId", c => c.Int());
            AlterColumn("dbo.ContactTypes", "ContactStatusId", c => c.Int());
            AlterColumn("dbo.Contacts", "ContactTypeId", c => c.Int());
            AlterColumn("dbo.Contacts", "ContactTypeId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.ContactTypes", name: "DiscountId", newName: "Discount_Id");
            RenameColumn(table: "dbo.ContactTypes", name: "ContactStatusId", newName: "ContactStatus_Id");
            RenameColumn(table: "dbo.Contacts", name: "ContactTypeId", newName: "ContactType_Id");
            AddColumn("dbo.Contacts", "ContactTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.ContactTypes", "Discount_Id");
            CreateIndex("dbo.ContactTypes", "ContactStatus_Id");
            CreateIndex("dbo.Contacts", "ContactType_Id");
            AddForeignKey("dbo.ContactTypes", "Discount_Id", "dbo.Discounts", "Id");
            AddForeignKey("dbo.ContactTypes", "ContactStatus_Id", "dbo.ContactStatus", "Id");
            AddForeignKey("dbo.Contacts", "ContactType_Id", "dbo.ContactTypes", "Id");
        }
    }
}
