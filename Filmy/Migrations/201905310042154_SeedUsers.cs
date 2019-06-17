namespace Filmy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8d2a8970-af53-4e5b-bdd7-a218a6a0d389', N'ahmed_hossam_eldeen@outlook.com', 0, N'AMrloVNGLVX76/4DkUOObZfkedbrBPAqjxTWy/5AYDOnkUnOncmcVsKrwxWKwmvWSQ==', N'ce294fe2-3b91-4d7a-91a3-50911971d240', NULL, 0, 0, NULL, 1, 0, N'ahmed_hossam_eldeen@outlook.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9420402c-c9f4-4ded-ad55-2532df8939b0', N'admin@vidly.com', 0, N'ABO9jTaA2yd/+q7rT1lkthgrd66x7eMaD//8hudApr5cmhJwSu1lVVQSHKbowD38Tw==', N'48d6f1de-340a-4859-b9cb-305cb552803b', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9d7e82ce-88ee-4c96-8465-dfc467f91a05', N'guest@vidly.com', 0, N'AA+ebCRSp3QFlp1ax9CF7yfivmUCl4dSaovKYLHYtFPPQuw2ywfV9AILabBYhZ2hoQ==', N'ce3ea66d-a0f9-4a45-b92f-87afb83840fd', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0b3076af-2b2f-4d05-8b41-339f3c60969a', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8d2a8970-af53-4e5b-bdd7-a218a6a0d389', N'0b3076af-2b2f-4d05-8b41-339f3c60969a')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9420402c-c9f4-4ded-ad55-2532df8939b0', N'0b3076af-2b2f-4d05-8b41-339f3c60969a')
");
        }
        
        public override void Down()
        {
        }
    }
}
