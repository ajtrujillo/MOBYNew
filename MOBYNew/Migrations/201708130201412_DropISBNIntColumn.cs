namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropISBNIntColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "ISBN13EAN");
            AddColumn("dbo.Items", "ISBN13EAN", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
