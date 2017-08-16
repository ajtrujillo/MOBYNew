namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoryCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "categoryCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "categoryCode");
        }
    }
}
