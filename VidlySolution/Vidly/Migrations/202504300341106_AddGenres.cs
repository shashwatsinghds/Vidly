namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres Values (1,'Comedy')");
            Sql("Insert Into Genres Values (2,'Action')");
            Sql("Insert Into Genres Values (3,'Family')");
            Sql("Insert Into Genres Values (4,'Romance')");

        }

        public override void Down()
        {
        }
    }
}
