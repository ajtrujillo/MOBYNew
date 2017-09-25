namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredStatusandTypeModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactStatus", "contactStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactStatus", "contactStatus");
        }
    }
}
