namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterContactTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "IsSubscribedToNewsletter", c => c.Boolean());
            AlterColumn("dbo.ContactTypes", "IsEligibleForDiscount", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactTypes", "IsEligibleForDiscount", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Contacts", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
    }
}
