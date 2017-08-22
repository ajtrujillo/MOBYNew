namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToAccommodateVM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactStatus", "statusType", c => c.Int());
            AddColumn("dbo.ContactStatus", "ContactId", c => c.Int());
            CreateIndex("dbo.ContactStatus", "ContactId");
            AddForeignKey("dbo.ContactStatus", "ContactId", "dbo.Contacts", "Id");
            DropColumn("dbo.ContactStatus", "contactStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactStatus", "contactStatus", c => c.String());
            DropForeignKey("dbo.ContactStatus", "ContactId", "dbo.Contacts");
            DropIndex("dbo.ContactStatus", new[] { "ContactId" });
            DropColumn("dbo.ContactStatus", "ContactId");
            DropColumn("dbo.ContactStatus", "statusType");
        }
    }
}
