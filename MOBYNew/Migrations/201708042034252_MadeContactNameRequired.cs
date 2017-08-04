namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeContactNameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Name", c => c.String());
        }
    }
}
