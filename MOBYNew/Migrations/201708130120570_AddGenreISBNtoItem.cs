namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreISBNtoItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        categoryName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Items", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "ISBN13EAN", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "CategoryId");
            AddForeignKey("dbo.Items", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropColumn("dbo.Items", "ISBN13EAN");
            DropColumn("dbo.Items", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
