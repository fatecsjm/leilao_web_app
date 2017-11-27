namespace Projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBidsFromModelAuctionState : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bids", "AuctionState_Id", "dbo.AuctionStates");
            DropIndex("dbo.Bids", new[] { "AuctionState_Id" });
            //DropColumn("dbo.Bids", "AuctionState_Id");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Bids", "AuctionState_Id", c => c.Int());
            CreateIndex("dbo.Bids", "AuctionState_Id");
            AddForeignKey("dbo.Bids", "AuctionState_Id", "dbo.AuctionStates", "Id");
        }
    }
}
