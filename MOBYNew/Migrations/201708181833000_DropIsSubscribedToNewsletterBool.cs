namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropIsSubscribedToNewsletterBool : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "IsSubscribedToNewsletter");
        }
        
        public override void Down()
        {
        }
    }
}
