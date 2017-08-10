namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedGenreStringfromItemCS : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Genre", c => c.String());
        }
    }
}
