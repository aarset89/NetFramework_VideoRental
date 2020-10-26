namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingAndPopulatingRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5797c3df-d6d5-46c1-8386-da6a7cd570eb', N'adasd@asdad.com', 0, N'AGRJ5wjRf/OqF+qIwz6uXubzVW++x7SMOohCwDzutGvKT0jG0CRGBaMZNJ52cUU6Sg==', N'0927cf9d-f4ed-4856-88d9-47c0d809714f', NULL, 0, 0, NULL, 1, 0, N'adasd@asdad.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'786a3c15-62d2-4e3e-8d0d-379d17f8ef2e', N'admin@asdad.com', 0, N'ACqfVSm1LnYzxdHB08pv7aG7pgIj4pGcnLOw00i82SfH6D0dlqH1n2c6LcA0XXaeXQ==', N'a4fed6e0-048d-421e-98cb-e8f0e3cd14a0', NULL, 0, 0, NULL, 1, 0, N'admin@asdad.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7e7f0f0a-1d78-449d-9f90-6ed420fc9d9a', N'guest@asd.com', 0, N'ANBCW6Nu4PMBog4SXYwydk3ziQ7PL9rYL286BdAJihOM5vo7wleMOA/rMkuQIXjJVA==', N'5ea360f8-b222-47cd-8738-8e09d8732b84', NULL, 0, 0, NULL, 1, 0, N'guest@asd.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bc3a4749-40b8-4fd8-87e0-b36a93d5076b', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'786a3c15-62d2-4e3e-8d0d-379d17f8ef2e', N'bc3a4749-40b8-4fd8-87e0-b36a93d5076b')

");
        }
        
        public override void Down()
        {
        }
    }
}
