namespace Projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        ZipCode = c.String(),
                        AddressNumber = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateHour = c.DateTime(nullable: false),
                        value = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Auction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Auctions", t => t.Auction_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Auction_Id);
            
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InitialDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        MinValue = c.Int(nullable: false),
                        ArtWork_Id = c.Int(),
                        AuctionState_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArtWorks", t => t.ArtWork_Id)
                .ForeignKey("dbo.AuctionStates", t => t.AuctionState_Id)
                .Index(t => t.ArtWork_Id)
                .Index(t => t.AuctionState_Id);
            
            CreateTable(
                "dbo.ArtWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Purpose = c.Int(nullable: false),
                        Title = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Image = c.String(),
                        Artist_Id = c.Int(),
                        Category_Id = c.Int(),
                        Finality_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Finalities", t => t.Finality_Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Finality_Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Finalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateHour = c.DateTime(nullable: false),
                        value = c.Int(nullable: false),
                        ArtWork_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArtWorks", t => t.ArtWork_Id)
                .Index(t => t.ArtWork_Id);
          /*  
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateHour = c.DateTime(nullable: false),
                        Address_AddressId = c.Int(),
                        AddressUser_AddressId = c.Int(),
                        PaymentMethod_Id = c.Int(),
                        State_Id = c.Int(),
                        Address_AddressId1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId)
                .ForeignKey("dbo.Addresses", t => t.AddressUser_AddressId)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethod_Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId1)
                .Index(t => t.Address_AddressId)
                .Index(t => t.AddressUser_AddressId)
                .Index(t => t.PaymentMethod_Id)
                .Index(t => t.State_Id)
                .Index(t => t.Address_AddressId1);
            */
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InsertionDate = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Artwork_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.ArtWorks", t => t.Artwork_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Artwork_Id);
            
            CreateTable(
                "dbo.AuctionStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            /*
            CreateTable(
                "dbo.PurchaseArtWorks",
                c => new
                    {
                        Purchase_PurchaseId = c.Int(nullable: false),
                        ArtWork_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Purchase_PurchaseId, t.ArtWork_Id })
                .ForeignKey("dbo.Purchases", t => t.Purchase_PurchaseId, cascadeDelete: true)
                .ForeignKey("dbo.ArtWorks", t => t.ArtWork_Id, cascadeDelete: true)
                .Index(t => t.Purchase_PurchaseId)
                .Index(t => t.ArtWork_Id);
            */
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            //DropForeignKey("dbo.Purchases", "Address_AddressId1", "dbo.Addresses");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bids", "Auction_Id", "dbo.Auctions");
            //DropForeignKey("dbo.Bids", "AuctionState_Id", "dbo.AuctionStates");
            DropForeignKey("dbo.Auctions", "AuctionState_Id", "dbo.AuctionStates");
            DropForeignKey("dbo.ShoppingCarts", "Artwork_Id", "dbo.ArtWorks");
            DropForeignKey("dbo.ShoppingCarts", "ApplicationUser_Id", "dbo.AspNetUsers");
            /*
            DropForeignKey("dbo.Purchases", "State_Id", "dbo.States");
            DropForeignKey("dbo.Purchases", "PaymentMethod_Id", "dbo.PaymentMethods");
            DropForeignKey("dbo.PurchaseArtWorks", "ArtWork_Id", "dbo.ArtWorks");
            DropForeignKey("dbo.PurchaseArtWorks", "Purchase_PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Purchases", "AddressUser_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Purchases", "Address_AddressId", "dbo.Addresses");
            */
            DropForeignKey("dbo.Prices", "ArtWork_Id", "dbo.ArtWorks");
            DropForeignKey("dbo.ArtWorks", "Finality_Id", "dbo.Finalities");
            DropForeignKey("dbo.ArtWorks", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Auctions", "ArtWork_Id", "dbo.ArtWorks");
            DropForeignKey("dbo.ArtWorks", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.Bids", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Addresses", "ApplicationUser_Id", "dbo.AspNetUsers");
            /*
            DropIndex("dbo.PurchaseArtWorks", new[] { "ArtWork_Id" });
            DropIndex("dbo.PurchaseArtWorks", new[] { "Purchase_PurchaseId" });
            */
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.ShoppingCarts", new[] { "Artwork_Id" });
            DropIndex("dbo.ShoppingCarts", new[] { "ApplicationUser_Id" });
            /*
            DropIndex("dbo.Purchases", new[] { "Address_AddressId1" });
            DropIndex("dbo.Purchases", new[] { "State_Id" });
            DropIndex("dbo.Purchases", new[] { "PaymentMethod_Id" });
            DropIndex("dbo.Purchases", new[] { "AddressUser_AddressId" });
            DropIndex("dbo.Purchases", new[] { "Address_AddressId" });
            */
            DropIndex("dbo.Prices", new[] { "ArtWork_Id" });
            DropIndex("dbo.ArtWorks", new[] { "Finality_Id" });
            DropIndex("dbo.ArtWorks", new[] { "Category_Id" });
            DropIndex("dbo.ArtWorks", new[] { "Artist_Id" });
            DropIndex("dbo.Auctions", new[] { "AuctionState_Id" });
            DropIndex("dbo.Auctions", new[] { "ArtWork_Id" });
            DropIndex("dbo.Bids", new[] { "Auction_Id" });
            //DropIndex("dbo.Bids", new[] { "AuctionState_Id" });
            DropIndex("dbo.Bids", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Addresses", new[] { "ApplicationUser_Id" });
            //DropTable("dbo.PurchaseArtWorks");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AuctionStates");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.States");
            DropTable("dbo.PaymentMethods");
            //DropTable("dbo.Purchases");
            DropTable("dbo.Prices");
            DropTable("dbo.Finalities");
            DropTable("dbo.Categories");
            DropTable("dbo.Artists");
            DropTable("dbo.ArtWorks");
            DropTable("dbo.Auctions");
            DropTable("dbo.Bids");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Addresses");
        }
    }
}
