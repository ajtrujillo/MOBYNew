namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedContactDiscounts3 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Discounts(Id, discountName, discountPercent, discountDurationInMonths) VALUES (1,'Subscriber', 10, 1)");
            Sql("INSERT INTO Discounts(Id, discountName, discountPercent, discountDurationInMonths) VALUES (2,'Student', 10, 1)");

        }

        public override void Down()
        {
        }
    }
}
