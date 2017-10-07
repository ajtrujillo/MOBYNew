namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        EntryOwner = c.Guid(nullable: false),
                        TRNContact_Id = c.Int(nullable: false),
                        TRNItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.TRNContact_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.TRNItem_Id)
                .Index(t => t.TRNContact_Id)
                .Index(t => t.TRNItem_Id);
            
            AddColumn("dbo.Items", "Transaction_Id", c => c.Int());
            CreateIndex("dbo.Items", "Transaction_Id");
            AddForeignKey("dbo.Items", "Transaction_Id", "dbo.Transactions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Transaction_Id", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "TRNItem_Id", "dbo.Items");
            DropForeignKey("dbo.Transactions", "TRNContact_Id", "dbo.Contacts");
            DropIndex("dbo.Transactions", new[] { "TRNItem_Id" });
            DropIndex("dbo.Transactions", new[] { "TRNContact_Id" });
            DropIndex("dbo.Items", new[] { "Transaction_Id" });
            DropColumn("dbo.Items", "Transaction_Id");
            DropTable("dbo.Transactions");
        }
    }
}
