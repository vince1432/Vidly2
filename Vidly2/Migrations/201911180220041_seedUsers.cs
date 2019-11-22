namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0bcc74d1-0bdb-41ca-8a13-8709628928e3', N'guest@vidly.com', 0, N'ALaj+ErhleECE9Sy5IfT2QLRkmiFNCotlrGcZGjRgL7tEtGy6sqojkgDK/+1gkc/LQ==', N'3d366d83-ebf4-48e2-abc7-823dd074f1c9', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'93a63e87-28d6-4149-a052-ac501bc62a18', N'admin@me.com', 0, N'AD/0gtJ619x+NMq1x5Bl0CVmtYqma/4HcPvXlHvMErIZ8H8+qv2yBKAWX3uPHYI0Cw==', N'a501dbc7-e631-41a2-9344-01f986e108a4', NULL, 0, 0, NULL, 1, 0, N'admin@me.com')
                    
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4f038380-6a26-4172-9d4b-b4dd3dea090c', N'CanManageMovies')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'93a63e87-28d6-4149-a052-ac501bc62a18', N'4f038380-6a26-4172-9d4b-b4dd3dea090c')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
