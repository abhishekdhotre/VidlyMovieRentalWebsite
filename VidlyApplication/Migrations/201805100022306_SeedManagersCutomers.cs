namespace VidlyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedManagersCutomers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e3114d58-ae00-4526-985d-8340f9a12df0', N'admin@vidly.com', 0, N'AFIdOwLcXCGk43icolnSmYZUyL7nWcDR0sgqHs6nNC6roMrc6n2FMjAlboP5phWOAw==', N'087b7628-211b-44a9-9e37-953c7378744f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e063ecfa-9346-4a38-8b0c-db2596ffb144', N'CanAccessMovies')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a0059c42-8d1b-40d5-b50e-738622bf3a71', N'CanManageCustomer')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e3114d58-ae00-4526-985d-8340f9a12df0', N'e063ecfa-9346-4a38-8b0c-db2596ffb144')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e3114d58-ae00-4526-985d-8340f9a12df0', N'a0059c42-8d1b-40d5-b50e-738622bf3a71')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
