namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactStatustoContactType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        contactStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ContactTypes", "ContactStatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.ContactTypes", "ContactStatusId");
            AddForeignKey("dbo.ContactTypes", "ContactStatusId", "dbo.ContactStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactTypes", "ContactStatusId", "dbo.ContactStatus");
            DropIndex("dbo.ContactTypes", new[] { "ContactStatusId" });
            DropColumn("dbo.ContactTypes", "ContactStatusId");
            DropTable("dbo.ContactStatus");
        }
    }
}
