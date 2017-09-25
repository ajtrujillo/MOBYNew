namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMoreItemstoDB : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Items (ReleaseDate, Price, GenreId, QtyInStock, CategoryId, ISBN13EAN, ItemName, ImagePath, ItemDescription) VALUES (1/1/2000, 19.99, 6, 5, 3, NULL, 'Dark Knight Returns TP New Ed', 'NOV150279.jpg', 'It is the thirtieth anniversary of THE DARK KNIGHT RETURNS, and now DC Comics presents this classic title in a newly redesigned edition! Ten years after an aging Batman retired, Gotham City has sunk deeper into decadence and lawlessness. Now, when his city needs him most, the Dark Knight returns in a blaze of glory. Joined by Carrie Kelly, a teenaged Robin, Batman takes to the streets to end the threat of the mutant gangs that have overrun the city. And after facing off against his two greatest enemies, the Joker and Two-Face, for the final time, Batman finds himself in mortal combat with his former ally, Superman. The original 4-issue miniseries is presented here in its entirety.')");

            Sql("INSERT INTO Items (ReleaseDate, Price, GenreId, QtyInStock, CategoryId, ISBN13EAN, ItemName, ImagePath, ItemDescription) VALUES (1/1/2000, 24.99, 1, 5, 3, NULL, 'Akira Kondansha Ed GN Vol 01', 'AUG090981.jpg', 'The post-apocalyptic science-fiction saga Akira, with its thought-provoking themes and kinetic artwork, introduced the world to the power of manga. Now available again, this classic adventure is ready to be discovered by a new generation of readers!')");

            Sql("INSERT INTO Items (ReleaseDate, Price, GenreId, QtyInStock, CategoryId, ISBN13EAN, ItemName, ImagePath, ItemDescription) VALUES (1/1/2000, 24.99, 1, 5, 3, NULL, 'X-Men Dark Phoenix Saga TP New Ptg', 'FEB120693.jpg', 'An Epic Tale Of Triumph And Tragedy! When The Dark Phoenix Rises, Suns Grow Cold And Universes Die! The X-Men Embark On An Adventure That Will Span The Cosmos As One Of Their Own, Jean Grey, Has Unwittingly Attained Power Beyond Conception - And Been Corrupted, Absolutely. The X-Men Must Decide: Is The Life Of The Woman They Cherish Worth The Existence Of An Entire Universe? This Touching Tale Of Ultimate Power And The Triumph Of The Human Spirit Has Been A Cornerstone Of The X-Men Mythos For More Than Three Decades. Now, Relive The Dark Phoenix Saga With This Deluxe Collection, Bursting At The Seams With Extra Stories That Illuminate New And Different Facets Of The World Of The Phoenix! Collecting X-Men (1963) #129-138, Phoenix: The Untold Story; And Material From Classic X-Men #43, Bizarre Adventures #27 And What If? (1977) #27.')");
        }
        
        public override void Down()
        {
        }
    }
}