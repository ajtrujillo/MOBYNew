namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJoinDatetoContacts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "JoinDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "JoinDate");
        }
    }
}
