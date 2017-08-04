namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedContactTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ContactTypes (Id, contactType) VALUES (1, 'Customer')");
        }
        
        public override void Down()
        {
        }
    }
}
