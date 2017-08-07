namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedConTypes : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT ContactTypes ON");
            Sql("INSERT INTO ContactTypes (Id, contactType) VALUES (1,'Customer')");
            Sql("INSERT INTO ContactTypes (Id, contactType) VALUES (2,'Distributor')");
            Sql("INSERT INTO ContactTypes (Id, contactType) VALUES (3,'Publisher')");
        }
        
        public override void Down()
        {
        }
    }
}
