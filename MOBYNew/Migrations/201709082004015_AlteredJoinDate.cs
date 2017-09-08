namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredJoinDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "JoinDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "JoinDate");
        }
    }
}
