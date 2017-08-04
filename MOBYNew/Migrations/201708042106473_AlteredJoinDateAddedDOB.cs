namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredJoinDateAddedDOB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "DOB", c => c.DateTime());
            DropColumn("dbo.Contacts", "JoinDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "JoinDate", c => c.DateTime(nullable: true));
            DropColumn("dbo.Contacts", "DOB");
        }
    }
}
