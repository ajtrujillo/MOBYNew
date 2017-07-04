namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedContactTypeandIdtoContactClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        contactType = c.String(),
                        Discount_discountPercent = c.Int(nullable: false),
                        Discount_discountDuration = c.DateTime(nullable: false),
                        IsEligibleForDiscount = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contacts", "ContactTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Contacts", "ContactTypeId");
            AddForeignKey("dbo.Contacts", "ContactTypeId", "dbo.ContactTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "ContactTypeId", "dbo.ContactTypes");
            DropIndex("dbo.Contacts", new[] { "ContactTypeId" });
            DropColumn("dbo.Contacts", "ContactTypeId");
            DropTable("dbo.ContactTypes");
        }
    }
}
