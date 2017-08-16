namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenreCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "genreCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Genres", "genreCode");
        }
    }
}
