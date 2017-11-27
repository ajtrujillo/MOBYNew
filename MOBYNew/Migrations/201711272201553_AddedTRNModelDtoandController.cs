namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTRNModelDtoandController : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "ItemId", "dbo.Items");
            DropIndex("dbo.CartItems", new[] { "ItemId" });
            AddColumn("dbo.Transactions", "TRNDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "TRNOwner", c => c.Guid(nullable: false));
            DropColumn("dbo.Transactions", "EntryDate");
            DropColumn("dbo.Transactions", "EntryOwner");
            DropTable("dbo.CartItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        CartItemId = c.String(nullable: false, maxLength: 128),
                        CartId = c.String(),
                        Quantity = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemId);
            
            AddColumn("dbo.Transactions", "EntryOwner", c => c.Guid(nullable: false));
            AddColumn("dbo.Transactions", "EntryDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transactions", "TRNOwner");
            DropColumn("dbo.Transactions", "TRNDate");
            CreateIndex("dbo.CartItems", "ItemId");
            AddForeignKey("dbo.CartItems", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
        }
    }
}
