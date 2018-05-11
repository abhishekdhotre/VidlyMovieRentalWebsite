namespace VidlyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStockAvailabiltyInMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "StockAvailabilty", c => c.Int(nullable: false));
            Sql("UPDATE dbo.Movies SET StockAvailabilty = Stock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "StockAvailabilty");
        }
    }
}
