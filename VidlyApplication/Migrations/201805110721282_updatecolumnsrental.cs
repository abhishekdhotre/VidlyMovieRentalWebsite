namespace VidlyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecolumnsrental : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "MovieId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
