namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToContactandTypeModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactTypes", "ContactTypeName", c => c.String());
            DropColumn("dbo.ContactTypes", "contactType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactTypes", "contactType", c => c.String());
            DropColumn("dbo.ContactTypes", "ContactTypeName");
        }
    }
}
