namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createddiscountconstructor : DbMigration
    {
        public override void Up()
        {
           
            AddColumn("dbo.ContactTypes", "Discount_Id", c => c.Int());
            CreateIndex("dbo.ContactTypes", "Discount_Id");
            AddForeignKey("dbo.ContactTypes", "Discount_Id", "dbo.Discounts", "Id");
        }
        
        public override void Down()
        {

        }
    }
}
