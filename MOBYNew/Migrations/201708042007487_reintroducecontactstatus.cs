namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reintroducecontactstatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        contactStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ContactTypes", "ContactStatus_Id", c => c.Int());
            CreateIndex("dbo.ContactTypes", "ContactStatus_Id");
            AddForeignKey("dbo.ContactTypes", "ContactStatus_Id", "dbo.ContactStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactTypes", "ContactStatus_Id", "dbo.ContactStatus");
            DropIndex("dbo.ContactTypes", new[] { "ContactStatus_Id" });
            DropColumn("dbo.ContactTypes", "ContactStatus_Id");
            DropTable("dbo.ContactStatus");
        }
    }
}
