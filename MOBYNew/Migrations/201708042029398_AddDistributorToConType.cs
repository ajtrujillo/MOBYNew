namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDistributorToConType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ContactTypes (Id, contactType) VALUES (2, 'Distributor')");
        }
        
        public override void Down()
        {
        }
    }
}
