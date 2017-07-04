namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompanyName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "CompanyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "CompanyName");
        }
    }
}
