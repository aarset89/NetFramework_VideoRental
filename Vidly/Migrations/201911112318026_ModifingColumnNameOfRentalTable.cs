namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifingColumnNameOfRentalTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            DropColumn("dbo.Rentals", "DateReturnet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "DateReturnet", c => c.DateTime());
            DropColumn("dbo.Rentals", "DateReturned");
        }
    }
}
