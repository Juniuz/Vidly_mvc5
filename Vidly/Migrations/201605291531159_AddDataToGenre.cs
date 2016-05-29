namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Documentary')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
