namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReSeedContactTypesDB : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE ContactTypes SET ContactTypeName = 'Customer' WHERE Id =1");
        }
        
        public override void Down()
        {
        }
    }
}
