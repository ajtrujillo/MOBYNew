namespace MOBYNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUserRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4d2320ce-75e0-46b0-91fb-9625b1b91242', N'admin@moby.com', 0, N'AHd10U9ehl5NhhAxTLuGjqCHxDrhDPsTrYjSAV9+Oc6n15UzyE3LrhAx0bFGsAnJ/w==', N'78d18e91-9f95-4f7a-a808-022ceac63a14', NULL, 0, 0, NULL, 1, 0, N'admin@moby.com')

            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'98e7f238-ec87-4547-8c9e-4f0dd467b55a', N'guest@moby.com', 0, N'AH5zXmkARYv2JruqZZVfmLm85X9rqsBe4y56GhtLzQPirPzv16jk4tKxchGM7Bwjgg==', N'61d4ece3-0d25-424f-b7a9-3edce8cf1b87', NULL, 0, 0, NULL, 1, 0, N'guest@moby.com')

            INSERT INTO[dbo].[AspNetRoles]([Id], [Name]) VALUES(N'89f5a5f1-b301-467c-9838-f65860197583', N'CRUDOperations')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4d2320ce-75e0-46b0-91fb-9625b1b91242', N'89f5a5f1-b301-467c-9838-f65860197583')"
);
        }

        public override void Down()
        {
        }
    }
}
