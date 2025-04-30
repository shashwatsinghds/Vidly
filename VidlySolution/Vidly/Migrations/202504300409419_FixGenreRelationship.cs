namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixGenreRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genres_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genres_Id" });
            RenameColumn(table: "dbo.Movies", name: "Genres_Id", newName: "GenreId");
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte());
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "Genres_Id");
            CreateIndex("dbo.Movies", "Genres_Id");
            AddForeignKey("dbo.Movies", "Genres_Id", "dbo.Genres", "Id");
        }
    }
}
