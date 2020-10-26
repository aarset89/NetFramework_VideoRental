namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into dbo.Genres values('Comedy')");
            Sql("insert into dbo.Genres values('Romance')");
            Sql("insert into dbo.Genres values('Action')");
            Sql("insert into dbo.Genres values('Family')");
        }
        
        public override void Down()
        {
        }
    }
}
