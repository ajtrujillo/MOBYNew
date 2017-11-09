namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredModelNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "ItemCategories");
            RenameTable(name: "dbo.Genres", newName: "ItemGenres");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ItemGenres", newName: "Genres");
            RenameTable(name: "dbo.ItemCategories", newName: "Categories");
        }
    }
}
