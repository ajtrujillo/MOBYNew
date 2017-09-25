namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryAgainSeedCategoryDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Items (ReleaseDate, Price, GenreId, QtyInStock, CategoryId, ISBN13EAN, ItemName, ImagePath, ItemDescription) VALUES (1/1/2000, 19.99, 6, 5, 3, NULL, 'Watchmen TP New Ed', 'FEB140265.jpg', 'Dont miss this new edition of WATCHMEN! The story begins as a murder-mystery and quickly unfolds into a planet-altering conspiracy as these unlikely heroes - Rorschach, Nite Owl, Silk Spectre, Dr. Manhattan and Ozymandias - must test the limits of their convictions and ask themselves where the true line is between good and evil. The original, epic story is collected here with sketches, bonus material and an introduction by artist Dave Gibbons.')");
        }
        
        public override void Down()
        {
        }
    }
}
