namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewColumnAvailableMoviesInMovieTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableMovies", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AvailableMovies");
        }
    }
}
