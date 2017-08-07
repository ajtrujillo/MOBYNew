namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedContactDiscount : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Discounts ON");
            Sql("INSERT INTO Discounts (Id, discountName) VALUES (1, 'Subscriber')");
        }
        
        public override void Down()
        {
        }
    }
}
