namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedtoItemModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "DateAdded");
        }
    }
}
