namespace Projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsConstraintsUpdate : DbMigration
    {
        public override void Up()
        {
            /*
            DropForeignKey("dbo.Purchases", "AddressUser_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Purchases", "Address_AddressId1", "dbo.Addresses");
            */
            DropForeignKey("dbo.Auctions", "ArtWork_Id", "dbo.ArtWorks");
            DropForeignKey("dbo.Auctions", "AuctionState_Id", "dbo.AuctionStates");
            DropForeignKey("dbo.ArtWorks", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.ArtWorks", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.ArtWorks", "Finality_Id", "dbo.Finalities");
            /*
            DropForeignKey("dbo.Purchases", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Purchases", "PaymentMethod_Id", "dbo.PaymentMethods");
            DropForeignKey("dbo.Purchases", "State_Id", "dbo.States");
            */
            DropIndex("dbo.Auctions", new[] { "ArtWork_Id" });
            DropIndex("dbo.Auctions", new[] { "AuctionState_Id" });
            DropIndex("dbo.ArtWorks", new[] { "Artist_Id" });
            DropIndex("dbo.ArtWorks", new[] { "Category_Id" });
            DropIndex("dbo.ArtWorks", new[] { "Finality_Id" });
            /*
            DropIndex("dbo.Purchases", new[] { "Address_AddressId" });
            DropIndex("dbo.Purchases", new[] { "AddressUser_AddressId" });
            DropIndex("dbo.Purchases", new[] { "PaymentMethod_Id" });
            DropIndex("dbo.Purchases", new[] { "State_Id" });
            DropIndex("dbo.Purchases", new[] { "Address_AddressId1" });
            DropColumn("dbo.Purchases", "Address_AddressId");
            RenameColumn(table: "dbo.Purchases", name: "Address_AddressId1", newName: "Address_AddressId");
            AddColumn("dbo.Purchases", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            */
            AlterColumn("dbo.Addresses", "Line1", c => c.String(nullable: false));
            AlterColumn("dbo.Bids", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Auctions", "ArtWork_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Auctions", "AuctionState_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ArtWorks", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.ArtWorks", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.ArtWorks", "Artist_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ArtWorks", "Category_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ArtWorks", "Finality_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Artists", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Finalities", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Prices", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            /*
            AlterColumn("dbo.Purchases", "Address_AddressId", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "PaymentMethod_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "State_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "Address_AddressId", c => c.Int(nullable: false));
            */
            AlterColumn("dbo.PaymentMethods", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.States", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AuctionStates", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Auctions", "ArtWork_Id");
            CreateIndex("dbo.Auctions", "AuctionState_Id");
            CreateIndex("dbo.ArtWorks", "Artist_Id");
            CreateIndex("dbo.ArtWorks", "Category_Id");
            CreateIndex("dbo.ArtWorks", "Finality_Id");
            /*
            CreateIndex("dbo.Purchases", "Address_AddressId");
            CreateIndex("dbo.Purchases", "ApplicationUser_Id");
            CreateIndex("dbo.Purchases", "PaymentMethod_Id");
            CreateIndex("dbo.Purchases", "State_Id");
            AddForeignKey("dbo.Purchases", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "Address_AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
            */
            AddForeignKey("dbo.Auctions", "ArtWork_Id", "dbo.ArtWorks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Auctions", "AuctionState_Id", "dbo.AuctionStates", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ArtWorks", "Artist_Id", "dbo.Artists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ArtWorks", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ArtWorks", "Finality_Id", "dbo.Finalities", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Purchases", "PaymentMethod_Id", "dbo.PaymentMethods", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Purchases", "State_Id", "dbo.States", "Id", cascadeDelete: true);
            DropColumn("dbo.ArtWorks", "Purpose");
            //DropColumn("dbo.Purchases", "AddressUser_AddressId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Purchases", "AddressUser_AddressId", c => c.Int());
            AddColumn("dbo.ArtWorks", "Purpose", c => c.Int(nullable: false));
            //DropForeignKey("dbo.Purchases", "State_Id", "dbo.States");
            //DropForeignKey("dbo.Purchases", "PaymentMethod_Id", "dbo.PaymentMethods");
            DropForeignKey("dbo.ArtWorks", "Finality_Id", "dbo.Finalities");
            DropForeignKey("dbo.ArtWorks", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.ArtWorks", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.Auctions", "AuctionState_Id", "dbo.AuctionStates");
            DropForeignKey("dbo.Auctions", "ArtWork_Id", "dbo.ArtWorks");
            /*
            DropForeignKey("dbo.Purchases", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Purchases", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Purchases", new[] { "State_Id" });
            DropIndex("dbo.Purchases", new[] { "PaymentMethod_Id" });
            DropIndex("dbo.Purchases", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Purchases", new[] { "Address_AddressId" });
            */
            DropIndex("dbo.ArtWorks", new[] { "Finality_Id" });
            DropIndex("dbo.ArtWorks", new[] { "Category_Id" });
            DropIndex("dbo.ArtWorks", new[] { "Artist_Id" });
            DropIndex("dbo.Auctions", new[] { "AuctionState_Id" });
            DropIndex("dbo.Auctions", new[] { "ArtWork_Id" });
            AlterColumn("dbo.AuctionStates", "Name", c => c.String());
            AlterColumn("dbo.States", "Name", c => c.String());
            AlterColumn("dbo.PaymentMethods", "Name", c => c.String());
            /*
            AlterColumn("dbo.Purchases", "Address_AddressId", c => c.Int());
            AlterColumn("dbo.Purchases", "State_Id", c => c.Int());
            AlterColumn("dbo.Purchases", "PaymentMethod_Id", c => c.Int());
            AlterColumn("dbo.Purchases", "Address_AddressId", c => c.Int());
            */
            AlterColumn("dbo.Prices", "Value", c => c.Int(nullable: false));
            AlterColumn("dbo.Finalities", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Artists", "Name", c => c.String());
            AlterColumn("dbo.ArtWorks", "Finality_Id", c => c.Int());
            AlterColumn("dbo.ArtWorks", "Category_Id", c => c.Int());
            AlterColumn("dbo.ArtWorks", "Artist_Id", c => c.Int());
            AlterColumn("dbo.ArtWorks", "Description", c => c.String());
            AlterColumn("dbo.ArtWorks", "Title", c => c.String());
            AlterColumn("dbo.Auctions", "AuctionState_Id", c => c.Int());
            AlterColumn("dbo.Auctions", "ArtWork_Id", c => c.Int());
            AlterColumn("dbo.Bids", "Value", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "Line1", c => c.String());
            /*
            DropColumn("dbo.Purchases", "ApplicationUser_Id");
            RenameColumn(table: "dbo.Purchases", name: "Address_AddressId", newName: "Address_AddressId1");
            AddColumn("dbo.Purchases", "Address_AddressId", c => c.Int());
            CreateIndex("dbo.Purchases", "Address_AddressId1");
            CreateIndex("dbo.Purchases", "State_Id");
            CreateIndex("dbo.Purchases", "PaymentMethod_Id");
            CreateIndex("dbo.Purchases", "AddressUser_AddressId");
            CreateIndex("dbo.Purchases", "Address_AddressId");
            */
            CreateIndex("dbo.ArtWorks", "Finality_Id");
            CreateIndex("dbo.ArtWorks", "Category_Id");
            CreateIndex("dbo.ArtWorks", "Artist_Id");
            CreateIndex("dbo.Auctions", "AuctionState_Id");
            CreateIndex("dbo.Auctions", "ArtWork_Id");
            /*
            AddForeignKey("dbo.Purchases", "State_Id", "dbo.States", "Id");
            AddForeignKey("dbo.Purchases", "PaymentMethod_Id", "dbo.PaymentMethods", "Id");
            AddForeignKey("dbo.Purchases", "Address_AddressId", "dbo.Addresses", "AddressId");
            */
            AddForeignKey("dbo.ArtWorks", "Finality_Id", "dbo.Finalities", "Id");
            AddForeignKey("dbo.ArtWorks", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.ArtWorks", "Artist_Id", "dbo.Artists", "Id");
            AddForeignKey("dbo.Auctions", "AuctionState_Id", "dbo.AuctionStates", "Id");
            AddForeignKey("dbo.Auctions", "ArtWork_Id", "dbo.ArtWorks", "Id");
            //AddForeignKey("dbo.Purchases", "Address_AddressId1", "dbo.Addresses", "AddressId");
            //AddForeignKey("dbo.Purchases", "AddressUser_AddressId", "dbo.Addresses", "AddressId");
        }
    }
}
