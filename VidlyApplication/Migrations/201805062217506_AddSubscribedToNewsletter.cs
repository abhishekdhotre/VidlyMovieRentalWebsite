namespace VidlyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubscribedToNewsletter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "isSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "isSubscribedToNewsletter");
        }
    }
}
