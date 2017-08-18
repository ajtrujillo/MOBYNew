namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewBoolFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false, defaultValue: false));
        }

        public override void Down()
        {
        }
    }
}
