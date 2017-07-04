namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDOB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "DOB", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "DOB");
        }
    }
}
