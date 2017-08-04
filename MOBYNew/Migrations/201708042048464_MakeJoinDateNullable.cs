namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeJoinDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "JoinDate", c => c.DateTime(nullable: true));
        }

        public override void Down()
        {
        }
    }
}
