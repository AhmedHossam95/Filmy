namespace Filmy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Type) VALUES ('Action')");
            Sql("INSERT INTO Genres (Type) VALUES ('Drama')");
            Sql("INSERT INTO Genres (Type) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Type) VALUES ('Horror')");
            Sql("INSERT INTO Genres (Type) VALUES ('Fantasy')");

        }

        public override void Down()
        {
        }
    }
}
