namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCategoryDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ItemDescription", c => c.String());
            AlterColumn("dbo.Items", "Price", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Price", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Items", "ItemDescription");
        }
    }
}
