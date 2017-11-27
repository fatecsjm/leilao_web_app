namespace Projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1', N'b@b.b', 0, N'ACH0kgzpS/tYa6xTxc9WU6p38kaxUAmhGUO6CskMYPjaVob0pAW2C8UmRmmFeSvZTg==', N'83c73f43-b8fb-4e52-8f8b-ff1389ce2a92', NULL, 0, 0, NULL, 1, 0, N'b@b.b')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1ac5fa82-3515-4c08-a5fd-b310aadc5280', N'g@g.g', 0, N'ADyFbf2PrcXlDjAh5anNCLciQWaJ/Y2l9r2M9cfIOA2S4AKE5cKOWk93/3liu/wgHg==', N'642abe2b-4444-4633-b8e3-cbfd76a10d28', NULL, 0, 0, NULL, 1, 0, N'g@g.g')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2', N'c@c.c', 0, N'AHqsV4TgSMS7p0V06xK71FMuSvfmaZgVxWEQVNt8EjEkJ+4zLyKJafNKT9LPpdMRtg==', N'5ee786f5-3740-4547-9b6c-6147a3bb42d5', NULL, 0, 0, NULL, 1, 0, N'c@c.c')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3', N'd@d.d', 0, N'AJEoSZjyIz+XgAww4atos7+PHkafKtUXYfK4RvYwb9EG7ZArWFDAma2CA64VkHixLQ==', N'454320bd-165b-478b-acd2-6f28783eb3b6', NULL, 0, 0, NULL, 1, 0, N'd@d.d')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4', N'e@e.e', 0, N'AOe+23Ty3/iUUnYm9GbXrmnW5ZBB/PVRgc2cKqHGtK5/ZYHqfi9p1JPuvTKVLL48UA==', N'9b5014ce-8fba-4b4c-8542-15d63c6a094d', NULL, 0, 0, NULL, 1, 0, N'e@e.e')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c0014fe1-f789-4a14-a15e-a0d9a43a91bd', N'a@a.a', 0, N'AInMeArEIe5CenMJnq9TInaTtVfFatKjRCU/LSqZzjTeiWUxnBw9SFrVbz60269K+A==', N'49186a8f-8f91-41e1-a24f-5a386c11a35b', NULL, 0, 0, NULL, 1, 0, N'a@a.a')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'ab3db7c8-138d-4cf5-9c7f-f6e7ab30abc3', N'Rambo', N'IdentityRole')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1ac5fa82-3515-4c08-a5fd-b310aadc5280', N'ab3db7c8-138d-4cf5-9c7f-f6e7ab30abc3')


");
        }
        
        public override void Down()
        {
        }
    }
}
