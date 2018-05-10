namespace VidlyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2f4e810b-14a1-4f46-9ff7-fa33c1732be8', N'abhidhotre91@gmail.com', 0, N'AK4VVJLP/SZVILVQB7ymRU77rBi797whsH9ZmD96HB04eOmcHYcbhGtCN4a9xoI4bQ==', N'b4127c86-7549-4f09-8024-d69c4492ce03', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'e3114d58-ae00-4526-985d-8340f9a12df0', N'admin@vidly.com', 0, N'AFIdOwLcXCGk43icolnSmYZUyL7nWcDR0sgqHs6nNC6roMrc6n2FMjAlboP5phWOAw==', N'087b7628-211b-44a9-9e37-953c7378744f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e063ecfa-9346-4a38-8b0c-db2596ffb144', N'CanAccessMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e3114d58-ae00-4526-985d-8340f9a12df0', N'e063ecfa-9346-4a38-8b0c-db2596ffb144')
                        
                ");
        }
        
        public override void Down()
        {
        }
    }
}
