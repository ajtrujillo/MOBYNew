namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedContactDiscount2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Discounts (discountName) VALUES ('Student')");
        }
        
        public override void Down()
        {
        }
    }
}
