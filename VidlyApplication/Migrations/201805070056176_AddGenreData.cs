namespace VidlyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES(Id, GenreName) VALUES (1, 'Action')");
            Sql("INSERT INTO GENRES(Id, GenreName) VALUES (2, 'Comedy')");
            Sql("INSERT INTO GENRES(Id, GenreName) VALUES (3, 'Romance')");
            Sql("INSERT INTO GENRES(Id, GenreName) VALUES (4, 'Family')");
        }
        
        public override void Down()
        {
        }
    }
}
