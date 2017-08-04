namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReseedContactStatus : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT ContactStatus ON");
            Sql("INSERT INTO ContactStatus (Id, contactStatus) VALUES (1, 'Active')");
            Sql("INSERT INTO ContactStatus (Id, contactStatus) VALUES (2, 'Inactive')");
        }
        
        public override void Down()
        {
        }
    }
}
