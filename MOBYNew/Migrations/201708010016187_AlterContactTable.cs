namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterContactTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("Contacts", "CompanyName");
            DropColumn("Contacts", "DOB");
        }
        
        public override void Down()
        {
        }
    }
}
