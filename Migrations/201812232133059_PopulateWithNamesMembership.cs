namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateWithNamesMembership : DbMigration
    {
        public override void Up()
        {
            Sql("update dbo.MembershipTypes set Name = 'Pay as You Go' where Id = 1");
            Sql("update dbo.MembershipTypes set Name = 'Monthly' where Id = 2");
            Sql("update dbo.MembershipTypes set Name = 'Quarterly' where Id = 3");
            Sql("update dbo.MembershipTypes set Name = 'Annual' where Id = 4");
        }

        public override void Down()
        {
        }
    }
}
