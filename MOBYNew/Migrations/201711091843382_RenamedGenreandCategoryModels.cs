namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedGenreandCategoryModels : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Items", name: "CategoryId", newName: "ItemCategoryId");
            RenameColumn(table: "dbo.Items", name: "GenreId", newName: "ItemGenreId");
            RenameIndex(table: "dbo.Items", name: "IX_GenreId", newName: "IX_ItemGenreId");
            RenameIndex(table: "dbo.Items", name: "IX_CategoryId", newName: "IX_ItemCategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Items", name: "IX_ItemCategoryId", newName: "IX_CategoryId");
            RenameIndex(table: "dbo.Items", name: "IX_ItemGenreId", newName: "IX_GenreId");
            RenameColumn(table: "dbo.Items", name: "ItemGenreId", newName: "GenreId");
            RenameColumn(table: "dbo.Items", name: "ItemCategoryId", newName: "CategoryId");
        }
    }
}
