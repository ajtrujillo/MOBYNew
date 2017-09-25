namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredCategoryCS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryDescription", c => c.String());
            AlterColumn("dbo.Categories", "CategoryCode", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryCode", c => c.Int(nullable: false));
            DropColumn("dbo.Categories", "CategoryDescription");
        }
    }
}
