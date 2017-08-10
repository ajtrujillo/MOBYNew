namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenreFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "GenreId");
            AddForeignKey("dbo.Items", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "GenreId", "dbo.Genres");
            DropIndex("dbo.Items", new[] { "GenreId" });
            DropColumn("dbo.Items", "GenreId");
        }
    }
}
