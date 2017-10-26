namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReSeedContactTypesDB2 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE ContactTypes SET ContactTypeName = 'Publisher' WHERE Id=2");
            Sql("UPDATE ContactTypes SET ContactTypeName = 'Distributor' WHERE Id=3");
        }
        
        public override void Down()
        {
        }
    }
}
