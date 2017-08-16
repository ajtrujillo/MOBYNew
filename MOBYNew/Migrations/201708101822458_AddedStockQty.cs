namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStockQty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "QtyInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "QtyInStock");
        }
    }
}
