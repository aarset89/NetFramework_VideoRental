namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBirthdateToCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("update dbo.Customers set Birthdate = '1980/1/1' where Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
